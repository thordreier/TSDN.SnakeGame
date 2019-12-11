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
    /// Packet to send information about a snake changing direction
    /// Direction: Client -> Server
    /// </summary>
    [Serializable]
    public class SnakeGameTCPPacketDirection
    {

        #region Private Variables

        private int snakeID;
        private Direction direction;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snakeID">The ID of the snake</param>
        /// <param name="direction">The direction the snake is going</param>
        public SnakeGameTCPPacketDirection(int snakeID, Direction direction)
        {
            this.snakeID = snakeID;
            this.direction = direction;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the snake ID
        /// </summary>
        public int SnakeID
        {
            get { return snakeID; }
        }

        /// <summary>
        /// Gets the direction
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
        }

        #endregion

    }


}
