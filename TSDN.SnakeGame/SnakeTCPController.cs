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
    /// Gets input about snake direction and sends it to server
    /// </summary>
    public class SnakeTCPController : ISnakeController
    {

        #region Private Variables

        private int snakeID;
        private SnakeGameTCPClient tcpClient;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snakeID">The local snake ID</param>
        /// <param name="tcpClient">TCP client to send to</param>
        public SnakeTCPController(int snakeID, SnakeGameTCPClient tcpClient)
        {
            this.snakeID = snakeID;
            this.tcpClient = tcpClient;
        }

        #endregion


        #region ISnakeController Members

        /// <summary>
        /// Sets the direction
        /// </summary>
        public Direction SnakeDirection
        {
            set
            {
                tcpClient.SendPacket(new SnakeGameTCPPacketDirection(snakeID, value));
            }
        }

        #endregion

    }


}
