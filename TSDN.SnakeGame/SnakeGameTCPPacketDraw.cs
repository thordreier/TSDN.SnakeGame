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
    /// Packet to send information about what to draw to client
    /// Direction: Server -> Client
    /// </summary>
    [Serializable]
    public class SnakeGameTCPPacketDraw
    {

        #region Private Variables

        private List<AreaColor> drawUpdate;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="drawUpdate">List containing what to draw</param>
        public SnakeGameTCPPacketDraw(List<AreaColor> drawUpdate)
        {
            this.drawUpdate = drawUpdate;
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets list containing what to draw
        /// </summary>
        public List<AreaColor> DrawUpdate
        {
            get { return drawUpdate; }
        }

        #endregion

    }


}
