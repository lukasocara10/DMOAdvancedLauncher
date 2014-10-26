﻿// ======================================================================
// DMOLibrary
// Copyright (C) 2013 Ilya Egorov (goldrenard@gmail.com)

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

using System;
using System.Security;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using Ookii.Dialogs.Wpf;
using Microsoft.Win32;
using HtmlAgilityPack;
using System.Runtime.InteropServices;

namespace DMOLibrary.Profiles
{
    public abstract class DMOProfile
    {
        protected System.Windows.Threading.Dispatcher owner_dispatcher = null;

        protected string TYPE_NAME;
        protected string DATABASE_NAME = string.Empty;
        private string DATABASES_FOLDER = "{0}\\Databases";
        protected bool _IsLoginRequired = false;

        public DMOProfile()
        {
            string dir = string.Format(DATABASES_FOLDER, System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory));
            if (!Directory.Exists(dir))
            {
                try { Directory.CreateDirectory(dir); }
                catch { }
            }
        }

        public string GetTypeName() { return TYPE_NAME; }

        #region Game start
        protected string UserId;
        protected SecureString Password;
        protected int login_try, start_try = 0, last_error = -1;
        protected System.Windows.Forms.WebBrowser wb = new System.Windows.Forms.WebBrowser() { ScriptErrorsSuppressed = true };

        public abstract void TryLogin(string UserId, SecureString Password);

        public delegate void LoginCompleteHandler(object sender, LoginCode code, string result);
        public event LoginCompleteHandler LoginCompleted;
        public delegate void LoginStateHandler(object sender, LoginState state, int try_num, int last_error);
        public event LoginStateHandler LoginStateChanged;

        protected virtual void OnCompleted(LoginCode code, string result)
        {
            if (LoginCompleted != null)
            {
                if (owner_dispatcher != null && !owner_dispatcher.CheckAccess())
                {
                    owner_dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new LoginCompleteHandler((sender, code_, result_) =>
                    {
                        LoginCompleted(sender, code_, result_);
                    }), this, code, result);
                }
                else
                    LoginCompleted(this, code, result);
            }
        }

        protected virtual void OnChanged(LoginState state)
        {
            if (LoginStateChanged != null)
            {
                if (owner_dispatcher != null && !owner_dispatcher.CheckAccess())
                {
                    owner_dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new LoginStateHandler((sender_, state_, try_num_, last_error_) =>
                    {
                        LoginStateChanged(sender_, state_, try_num_, last_error_);
                    }), this, state, start_try + 1, last_error);
                }
                else
                    LoginStateChanged(this, state, start_try + 1, last_error);
            }
        }

        protected void TryParseInfo(string content)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(content);
            string result_text = doc.DocumentNode.SelectSingleNode("//body").InnerText;

            result_text = result_text.Replace("\r\n-\r\n", "");
            result_text = result_text.Replace("\r\n", "");
            result_text = System.Net.WebUtility.HtmlDecode(result_text);

            HtmlDocument result = new HtmlDocument();
            result.LoadHtml(result_text);

            int res_code = Convert.ToInt32(result.DocumentNode.SelectSingleNode("//result").Attributes["value"].Value);
            string Args = string.Empty;
            if (res_code == 0)
            {
                foreach (HtmlNode node in result.DocumentNode.SelectNodes("//param"))
                {
                    try { Args += node.Attributes["value"].Value + " "; }
                    catch { };
                }
                OnCompleted(LoginCode.SUCCESS, Args);
            }
            else
            {
                last_error = res_code;
                start_try++;
                TryLogin(UserId, Password);
            }
        }
        #endregion Game start

        #region Database Section
        public string GetDatabasePath()
        {
            if (DATABASE_NAME != string.Empty)
                return string.Format(DATABASES_FOLDER + "\\{1}.sqlite", System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), DATABASE_NAME);
            return string.Format(DATABASES_FOLDER + "\\{1}.sqlite", System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory), TYPE_NAME);
        }

        public server GetServerById(int sId)
        {
            foreach (server s in _ServerList)
                if (s.Id == sId)
                    return s;
            return null;
        }

        protected DMOWebProfile _WebProfile = null;
        protected DMONewsProfile _NewsProfile = null;
        public DMOWebProfile WebProfile { set { } get { return _WebProfile; } }
        public DMONewsProfile NewsProfile { set { } get { return _NewsProfile; } }

        public DMODatabase Database;
        protected ObservableCollection<server> _ServerList;
        public ObservableCollection<server> ServerList
        {
            set { }
            get { return _ServerList; }
        }

        public bool IsWebAvailable
        {
            set { }
            get { return _WebProfile != null; }
        }

        public bool IsNewsAvailable
        {
            set { }
            get { return _NewsProfile != null; }
        }

        public bool IsLoginRequired
        {
            set { }
            get { return _IsLoginRequired; }
        }
        #endregion

        #region Service

        public abstract string GetGameStartArgs(string args);
        public abstract string GetLauncherStartArgs(string args);

        #endregion
    }
}