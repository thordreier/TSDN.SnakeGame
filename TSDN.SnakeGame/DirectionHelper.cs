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
    /// Static class with functions relating to Direction
    /// </summary>
    public static class DirectionHelper
    {

        #region Public Static Methods

        /// <summary>
        /// Get the opposit direction
        /// </summary>
        /// <param name="firstDirection">Direction</param>
        /// <returns>The opposit direction</returns>
        public static Direction GetOppositDirection(Direction firstDirection)
        {
            switch (firstDirection)
            {
                case Direction.Up:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Up;
                case Direction.Left:
                    return Direction.Right;
                default: //Direction.Right
                    return Direction.Left;
            }
        }

        /// <summary>
        /// Get a random direction
        /// </summary>
        /// <returns>A random direction</returns>
        public static Direction GetRandomDirection()
        {
            Random rnd = new Random();
            return (Direction)rnd.Next(0, 4);
        }

        #endregion

    }


}
