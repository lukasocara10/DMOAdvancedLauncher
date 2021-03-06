﻿// ======================================================================
// DMOLibrary
// Copyright (C) 2015 Ilya Egorov (goldrenard@gmail.com)

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.
// ======================================================================

using System.Security;
using System.Web;
using DMOLibrary.Database.Entity;
using DMOLibrary.Events;

namespace DMOLibrary.Profiles.Aeria {

    public class DMOAeria : DMOProfile {
        private static readonly log4net.ILog LOGGER = log4net.LogManager.GetLogger(typeof(DMOAeria));

        public DMOAeria()
            : base(Server.ServerType.ADMO, "Aeria") {
        }

        #region Getting user login commandline

        private void LoginDocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e) {
            LOGGER.InfoFormat("Document requested: {0}", e.Url.OriginalString);
            switch (e.Url.AbsolutePath) {
                //loginning
                case "/dialog/oauth": {
                        if (LoginTryNum >= 1) {
                            OnCompleted(LoginCode.WRONG_USER, string.Empty);
                            return;
                        }
                        LoginTryNum++;

                        bool isFound = true;
                        try {
                            wb.Document.GetElementById("edit-id").SetAttribute("value", UserId);
                            wb.Document.GetElementById("edit-pass").SetAttribute("value", SecureStringConverter.ConvertToUnsecureString(Password));
                        } catch {
                            isFound = false;
                        }

                        if (isFound) {
                            System.Windows.Forms.HtmlElement form = wb.Document.GetElementById("account_login");
                            if (form != null) {
                                form.InvokeMember("submit");
                            }
                        } else {
                            OnCompleted(LoginCode.WRONG_PAGE, string.Empty);
                            return;
                        }
                        break;
                    }
                case "/dialog/oauth/authorize": {
                        System.Windows.Forms.HtmlElementCollection links = wb.Document.GetElementsByTagName("a");
                        foreach (System.Windows.Forms.HtmlElement link in links) {
                            if (link.InnerText.Trim().ToLower().Equals("authorize")) {
                                link.InvokeMember("click");
                                break;
                            }
                        }
                        OnCompleted(LoginCode.UNKNOWN_URL, string.Empty);
                        break;
                    }
                //logged
                case "/code2token.html": {
                        OnCompleted(LoginCode.SUCCESS, string.Format("{0} {1} {2}", "Aeria", HttpUtility.ParseQueryString(e.Url.Query).Get("code"), UserId));
                        break;
                    }
                default: {
                        if (!e.Url.Host.Contains("facebook")) {
                            OnCompleted(LoginCode.UNKNOWN_URL, string.Empty);
                        }
                        break;
                    }
            }
        }

        public override void TryLogin(string UserId, SecureString Password) {
            this.UserId = UserId;
            this.Password = Password;
            if (UserId.Length == 0 || Password.Length == 0) {
                OnCompleted(LoginCode.WRONG_USER, string.Empty);
                return;
            }

            LoginTryNum = 0;
            wb.DocumentCompleted += LoginDocumentCompleted;
            wb.Navigate("http://www.aeriagames.com/dialog/oauth?response_type=code&client_id=f24233f2506681f0ba2022418e6a5b44050b5216f&https://agoa-dmo.joymax.com/code2token.html&&state=xyz");
            OnChanged(LoginState.LOGINNING);
        }

        #endregion Getting user login commandline

        public override bool IsLoginRequired {
            get {
                return true;
            }
        }

        public override string GetGameStartArgs(string args) {
            return args;
        }

        public override string GetLauncherStartArgs(string args) {
            return string.Empty;
        }
    }
}