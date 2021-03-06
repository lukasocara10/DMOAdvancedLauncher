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
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using AdvancedLauncher.Environment;

namespace AdvancedLauncher.Controls {

    public partial class RotationElement : UserControl, INotifyPropertyChanged {

        public RotationElement() {
            InitializeComponent();
            (this.Content as FrameworkElement).DataContext = this;
            LanguageEnv.LanguageChanged += (s, e) => {
                NotifyPropertyChanged("LevelText");
            };
        }

        private string _DType;

        public string DType {
            get {
                return _DType;
            }
            set {
                if (value != _DType) {
                    _DType = value;
                    NotifyPropertyChanged("DType");
                }
            }
        }

        private int _Level;

        public int Level {
            get {
                return _Level;
            }
            set {
                if (value != _Level) {
                    _Level = value;
                    NotifyPropertyChanged("Level");
                }
            }
        }

        public string LevelText {
            get {
                return LanguageEnv.Strings.RotationLevelText;
            }
            set {
            }
        }

        private string _TName;

        public string TName {
            get {
                return _TName;
            }
            set {
                if (value != _TName) {
                    _TName = value;
                    NotifyPropertyChanged("TName");
                }
            }
        }

        private int _TLevel;

        public int TLevel {
            get {
                return _TLevel;
            }
            set {
                if (value != _TLevel) {
                    _TLevel = value;
                    NotifyPropertyChanged("TLevel");
                }
            }
        }

        public bool IsUnknownImage {
            get {
                return _Image == null;
            }
        }

        private ImageSource _Image;

        public ImageSource Image {
            get {
                return _Image;
            }
            set {
                if (value != _Image) {
                    _Image = value;
                    NotifyPropertyChanged("Image");
                    NotifyPropertyChanged("IsUnknownImage");
                }
            }
        }

        private Brush _Medal = new SolidColorBrush(Color.FromRgb(255, 255, 255));

        public Brush Medal {
            get {
                return _Medal;
            }
            set {
                if (value != _Medal) {
                    _Medal = value;
                    NotifyPropertyChanged("Medal");
                }
            }
        }

        private bool _ShowInfo = true;

        public bool ShowInfo {
            get {
                return _ShowInfo;
            }
            set {
                if (value != _ShowInfo) {
                    _ShowInfo = value;
                    NotifyPropertyChanged("ShowInfo");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}