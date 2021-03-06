﻿// ======================================================================
// DIGIMON MASTERS ONLINE ADVANCED LAUNCHER
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

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using AdvancedLauncher.Environment.Containers;
using DMOLibrary;
using MahApps.Metro;

namespace AdvancedLauncher.Environment {

    public static class LauncherEnv {
        private static string _AppPath = null;
        private const string SETTINGS_FILE = "Settings.xml";
        private const string LOCALE_DIR = "Languages";
        private const string RESOURCE_DIR = "Resources";
        public const string KBLC_SERVICE_EXECUTABLE = "KBLCService.exe";
        public static Settings Settings;

        public const string REMOTE_VERSION_FILE = "https://raw.githubusercontent.com/GoldRenard/DMOAdvancedLauncher/master/version.xml";
        public const string COMMUNITY_IMAGE_REMOTE_FORMAT = "https://raw.githubusercontent.com/GoldRenard/DMOAdvancedLauncher/master/AdvancedLauncher/Resources/Community/{0}.png";
        public const string DIGIROTATION_IMAGE_REMOTE_FORMAT = "https://raw.githubusercontent.com/GoldRenard/DMOAdvancedLauncher/master/AdvancedLauncher/Resources/DigiRotation/{0}.png";

        public static string AppPath {
            get {
                return _AppPath;
            }
        }

        public static string AppDataPath {
            get {
                return InitFolder(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                    Path.Combine("GoldRenard", "AdvancedLauncher"));
            }
        }

        public static void Load() {
            _AppPath = System.IO.Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDataPath);
            if (File.Exists(GetSettingsFile())) {
                Settings = DeSerialize(GetSettingsFile());
            }
            if (Settings == null) {
                Settings = new Settings();
            }

            ApplyProxySettings(Settings);
            Settings.ConfigurationChanged += Settings_ConfigurationChanged;

            if (string.IsNullOrEmpty(Settings.LanguageFile)) {
                if (LanguageEnv.Load(CultureInfo.CurrentCulture.Name)) {
                    LauncherEnv.Settings.LanguageFile = CultureInfo.CurrentCulture.Name;
                } else {
                    LanguageEnv.Load(LanguageEnv.DefaultName);
                    LauncherEnv.Settings.LanguageFile = LanguageEnv.DefaultName;
                }
            } else {
                if (!LanguageEnv.Load(Settings.LanguageFile)) {
                    LanguageEnv.Load(LanguageEnv.DefaultName);
                    LauncherEnv.Settings.LanguageFile = LanguageEnv.DefaultName;
                }
            }

            if (Settings.Profiles == null || Settings.Profiles.Count == 0) {
                Settings.Profiles = new ObservableCollection<Profile>();
                Settings.Profiles.Add(new Profile());
            }

            if (!File.Exists(GetSettingsFile())) {
                Save();
            }
        }

        private static void Settings_ConfigurationChanged(object sender, EventArgs args) {
            ApplyProxySettings((Settings)sender);
        }

        private static void ApplyProxySettings(Settings settings) {
            ProxySetting proxy = settings.Proxy;
            if (!proxy.IsEnabled) {
                WebClientEx.ProxyConfig = null;
                return;
            }
            ProxyConfiguration.ProxyMode mode = (ProxyConfiguration.ProxyMode)proxy.Mode;
            if (proxy.Authentication && proxy.Credentials.IsCorrect) {
                WebClientEx.ProxyConfig = new ProxyConfiguration(mode, proxy.Host, proxy.Port,
                    proxy.Credentials.User, proxy.Credentials.SecurePassword);
            } else {
                WebClientEx.ProxyConfig = new ProxyConfiguration(mode, proxy.Host, proxy.Port);
            }
        }

        public static void LoadTheme() {
            Tuple<AppTheme, Accent> currentTheme = ThemeManager.DetectAppStyle(Application.Current);
            if (currentTheme == null) {
                return;
            }
            AppTheme appTheme = null;
            Accent themeAccent = null;
            if (Settings.AppTheme != null) {
                appTheme = ThemeManager.GetAppTheme(Settings.AppTheme);
            }
            if (appTheme == null) {
                appTheme = currentTheme.Item1;
            }
            if (Settings.ThemeAccent != null) {
                themeAccent = ThemeManager.GetAccent(Settings.ThemeAccent);
            }
            if (themeAccent == null) {
                themeAccent = currentTheme.Item2;
            }
            Settings.AppTheme = appTheme.Name;
            Settings.ThemeAccent = themeAccent.Name;
            ThemeManager.ChangeAppStyle(Application.Current, themeAccent, appTheme);
        }

        public static Settings DeSerialize(string filepath) {
            Settings db = new Settings();
            if (File.Exists(filepath)) {
                XmlSerializer reader = new XmlSerializer(typeof(Settings));
                using (var file = new StreamReader(filepath)) {
                    db = (Settings)reader.Deserialize(file);
                }
            }
            return db;
        }

        public static void Save() {
            XmlSerializer writer = new XmlSerializer(typeof(Settings));
            using (var file = new StreamWriter(GetSettingsFile())) {
                writer.Serialize(file, Settings);
            }
        }

        public static string GetSettingsFile() {
            return Path.Combine(AppDataPath, SETTINGS_FILE);
        }

        public static string GetKBLCFile() {
            return Path.Combine(AppPath, KBLC_SERVICE_EXECUTABLE);
        }

        public static string GetLangsPath() {
            return InitFolder(AppPath, LOCALE_DIR);
        }

        public static string Get3rdResourcesPath() {
            return InitFolder(AppDataPath, RESOURCE_DIR);
        }

        public static string GetResourcesPath() {
            return InitFolder(AppPath, RESOURCE_DIR);
        }

        public static string InitFolder(string root, string name) {
            string folder = Path.Combine(root, name);
            if (!Directory.Exists(folder)) {
                Directory.CreateDirectory(folder);
            }
            return folder;
        }
    }
}