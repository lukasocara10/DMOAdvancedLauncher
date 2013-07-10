﻿// ======================================================================
// DIGIMON MASTERS ONLINE ADVANCED LAUNCHER
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
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Controls;
using System.Reflection;
using DMOLibrary.DMOFileSystem;
using System.Windows.Shell;

using DMOLibrary;
using DMOLibrary.Profiles;
using DMOLibrary.Profiles.Aeria;
using DMOLibrary.Profiles.Joymax;

namespace AdvancedLauncher
{
    public partial class MainWindow : Window
    {
        MainWindow_DC DContext = new MainWindow_DC();
        Gallery Gallery_tab = null;
        Personalization Personalization_tab = null;
        Community Community_tab = null;
        About About_Window = null;
        Settings Settings_Window = null;
        int current_tab = 0;

        public MainWindow()
        {
            InitializeComponent();
            LayoutRoot.DataContext = DContext;
            this.Title += string.Format(" [{0} - {1}]", App.DMOProfile.GetTypeName(), App.DMOProfile.GetProfileName());

            #if DEBUG
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            this.Title += " (development build " + version.ToString() + ")";
            #endif

            if (!App.DMOProfile.IsWebSupported)
                NavCommunity.Visibility = Visibility.Collapsed;
        }

        private void NavControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //Prevent handling over changing inside tab item
            if (current_tab == NavControl.SelectedIndex)
                return;

            string Header = (string)((TabItem)NavControl.SelectedValue).Header;
            if (Header == LanguageProvider.strings.MAIN_NEWS_TAB)
            {
                MainPage_.Activate();
                current_tab = NavControl.SelectedIndex;
            }
            else if (Header == LanguageProvider.strings.MAIN_GALLERY_TAB)
            {
                if (Gallery_tab == null)
                {
                    Gallery_tab = new Gallery();
                    NavGallery.Content = Gallery_tab;
                }
                Gallery_tab.Activate();
                current_tab = NavControl.SelectedIndex;
            }
            else if (Header == LanguageProvider.strings.MAIN_COMMUNITY_TAB)
            {
                if (Community_tab == null)
                {
                    Community_tab = new Community();
                    NavCommunity.Content = Community_tab;
                }
                Community_tab.Activate();
                current_tab = NavControl.SelectedIndex;
            }
            else if (Header == LanguageProvider.strings.MAIN_CUSTOMIZATION_TAB)
            {
                if (Personalization_tab == null)
                {
                    Personalization_tab = new Personalization();
                    NavPersonalization.Content = Personalization_tab;
                }
                if (Personalization_tab.Activate())
                    current_tab = NavControl.SelectedIndex;
                else
                    NavControl.SelectedIndex = current_tab;
            }

            ((TabItem)NavControl.Items[current_tab]).Focus();
        }

        private void bnt_about_Click_1(object sender, RoutedEventArgs e)
        {
            byte[] t = new byte[5];
            t[10] = 1;
            if (About_Window == null)
            {
                About_Window = new About();
                LayoutRoot.Children.Add(About_Window);
            }
            About_Window.Show(true);
        }

        private void btn_settings_Click_1(object sender, RoutedEventArgs e)
        {
            if (Settings_Window == null)
            {
                Settings_Window = new Settings();
                LayoutRoot.Children.Add(Settings_Window);
            }
            Settings_Window.Show(true);
        }
    }
}
