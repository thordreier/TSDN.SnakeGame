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
    /// Area class
    /// </summary>
    [Serializable]
    public class Area : IArea
    {

        #region Private Variables

        private Coordinate topLeft, bottomRight;

        #endregion


        #region Constructors

        /// <summary>
        /// Default constructor
        /// Don't call functions before you have called ChangeSize to initialize the object
        /// </summary>
        public Area()
        {
        }

        /// <summary>
        /// Constructor
        /// Initializes object from top left and bottom right coordinate
        /// </summary>
        /// <param name="topLeft">Top left coordinate</param>
        /// <param name="bottomRight">Bottom right coordinate</param>
        public Area(Coordinate topLeft, Coordinate bottomRight)
        {
            ChangeSize(topLeft, bottomRight);
        }

        /// <summary>
        /// Constructor
        /// Initializes object from top left X and Y coordinate and bottom right X and Y coordinate
        /// </summary>
        /// <param name="x1">Top left X coordinate</param>
        /// <param name="y1">Top left Y coordinate</param>
        /// <param name="x2">Bottom right X coordinate</param>
        /// <param name="y2">Bottom right Y coordinate</param>
        public Area(int x1, int y1, int x2, int y2)
            : this(new Coordinate(x1, y1), new Coordinate(x2, y2))
        {
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the top left coordinate
        /// </summary>
        public Coordinate TopLeft
        {
            get { return topLeft; }
        }

        /// <summary>
        /// Gets the bottom right coordinate
        /// </summary>
        public Coordinate BottomRight
        {
            get { return bottomRight; }
        }

        #endregion


        #region Public Methods

        #region ChangeSize
        /// <summary>
        /// Change the size/place of an area
        /// </summary>
        /// <param name="topLeft">The new top left coordinate</param>
        /// <param name="bottomRight">the new bottom right coordinate</param>
        public void ChangeSize(Coordinate topLeft, Coordinate bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        /// <summary>
        /// Change the size/place of an area
        /// </summary>
        /// <param name="area">An area with the same size/place as the area should have</param>
        public void ChangeSize(IArea area)
        {
            ChangeSize(area.X1, area.Y1, area.X2, area.Y2);
        }

        /// <summary>
        /// Change the size/place of an area
        /// </summary>
        /// <param name="x1">The new top left X coordinate</param>
        /// <param name="y1">The new top left Y coordinate</param>
        /// <param name="x2">The new bottom right X coordinate</param>
        /// <param name="y2">The new bottom right Y coordinate</param>
        public void ChangeSize(int x1, int y1, int x2, int y2)
        {
            ChangeSize(new Coordinate(x1, y1), new Coordinate(x2, y2));
        }
        #endregion

        #region InArea
        /// <summary>
        /// Is this area inside the bounds of an area
        /// </summary>
        /// <param name="area">The area to test</param>
        /// <returns>True if this area is inside area, else False</returns>
        public bool InArea(Area area)
        {
            if (topLeft.InArea(area) && bottomRight.InArea(area))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #endregion


        #region IArea Members
        /// <summary>
        /// Get top left X coordinate
        /// </summary>
        public int X1
        {
            get { return TopLeft.X; }
        }

        /// <summary>
        /// Get bottom right X coordinate
        /// </summary>
        public int X2
        {
            get { return BottomRight.X; }
        }

        /// <summary>
        /// Get top left Y coordinate
        /// </summary>
        public int Y1
        {
            get { return TopLeft.Y; }
        }

        /// <summary>
        /// Get bottom right Y coordinate
        /// </summary>
        public int Y2
        {
            get { return BottomRight.Y; }
        }
        #endregion

    }


}
