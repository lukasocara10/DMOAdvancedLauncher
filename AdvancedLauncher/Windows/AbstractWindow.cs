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
using System.Windows;
using System.Windows.Controls;
using AdvancedLauncher.Environment;

namespace AdvancedLauncher.Windows {

    public abstract class AbstractWindow : UserControl {

        public delegate void CloseEventHandler(object sender, EventArgs e);

        public event CloseEventHandler WindowClosed;

        public AbstractWindow() {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject())) {
                LanguageEnv.LanguageChanged += (s, e) => {
                    this.DataContext = LanguageEnv.Strings;
                };
            }
        }

        public virtual void Show() {
            this.Visibility = Visibility.Visible;
        }

        public virtual void Close() {
            if (WindowClosed != null) {
                WindowClosed(this, new EventArgs());
            }
        }

        protected virtual void OnCloseClick(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}