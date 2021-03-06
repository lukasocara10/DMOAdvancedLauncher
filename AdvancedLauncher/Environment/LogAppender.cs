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

using AdvancedLauncher.Windows;
using log4net.Appender;
using log4net.Core;

namespace AdvancedLauncher.Environment {

    public class LogAppender : AppenderSkeleton {

        protected override void Append(LoggingEvent loggingEvent) {
            if (Logger.IsInstanceInitialized) {
                lock (this) {
                    Logger.Instance.AddEntry(loggingEvent);
                }
            }
        }
    }
}