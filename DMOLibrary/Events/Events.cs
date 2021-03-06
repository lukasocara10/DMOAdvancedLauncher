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

namespace DMOLibrary.Events {

    /// <summary>
    /// Login complete event handler
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event arguments</param>
    public delegate void LoginCompleteEventHandler(object sender, LoginCompleteEventArgs e);

    /// <summary>
    /// Login state event handler
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event arguments</param>
    public delegate void LoginStateEventHandler(object sender, LoginStateEventArgs e);

    /// <summary>
    /// WebProfile Download Complete event handler
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event arguments</param>
    public delegate void DownloadCompleteEventHandler(object sender, DownloadCompleteEventArgs e);

    /// <summary>
    /// WebProfile Download status changed event handler
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event arguments</param>
    public delegate void DownloadStatusChangedEventHandler(object sender, DownloadStatusEventArgs e);

    /// <summary>
    /// DMO File System Write status change event handler
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Event arguments</param>
    public delegate void WriteStatusChangedEventHandler(object sender, WriteDirectoryEventArgs e);
}