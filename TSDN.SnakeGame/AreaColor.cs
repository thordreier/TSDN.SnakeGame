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

using System.Drawing;


namespace TSDN.SnakeGame
{

    
    /// <summary>
    /// Struct combining an area with a color
    /// </summary>
    [Serializable]
    public struct AreaColor
    {

        #region Private Variables

        private IArea area;
        private Color color;

        #endregion


        #region Constructors
        public AreaColor(IArea area, Color color)
        {
            this.area = area;
            this.color = color;
        }
        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the area
        /// </summary>
        public IArea Area
        {
            get { return area; }
        }

        /// <summary>
        /// Gets the color
        /// </summary>
        public Color Color
        {
            get { return color; }
        }

        #endregion

    }


}
