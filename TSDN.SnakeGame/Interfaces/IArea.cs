//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\
// This is a "classic" snakegame with multiplayer support.             \\
// Copyright (C) 2007  Thor Dreier <thor@dreier.nu>                     \\
//                                                                       \\
// This program is free software; you can redistribute it and/or          \\
// modify it under the terms of the GNU General Public License as          \\
// published by the Free Software Foundation; version 2 of the License.     \\
//                                                                           \\
// This program is distributed in the hope that it will be useful,            \\
// but WITHOUT ANY WARRANTY; without even the implied warranty of              \\
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                \\
// GNU General Public License for more details.                                  \\
//                                                                                \\
// You should have received a copy of the GNU General Public License               \\
// along with this program; if not, write to the Free Software                      \\
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.   \\
//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\//\\


using System;
using System.Collections.Generic;
using System.Text;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// Interface to get corners of an area
    /// </summary>
    public interface IArea
    {

        #region Properties
        /// <summary>
        /// Get top left X coordinate
        /// </summary>
        int X1
        {
            get;
        }

        /// <summary>
        /// Get bottom right X coordinate
        /// </summary>
        int X2
        {
            get;
        }

        /// <summary>
        /// Get top left Y coordinate
        /// </summary>
        int Y1
        {
            get;
        }

        /// <summary>
        /// Get bottom right Y coordinate
        /// </summary>
        int Y2
        {
            get;
        }
        #endregion

    }


}
