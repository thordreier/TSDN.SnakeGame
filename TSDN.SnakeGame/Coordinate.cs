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
using System.Collections;
using System.Collections.Generic;
using System.Text;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// Single coordinate
    /// </summary>
    [Serializable]
    public class Coordinate : IArea
    {

        #region Static Private Variables

        static private Random rnd = new Random();

        #endregion


        #region Privat Variables

        private int x, y;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// Initializes object from X and Y coordinate
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Constructor
        /// Initialises object with a random coordinate in an area
        /// </summary>
        /// <param name="area">The area where the coordinate should be in</param>
        public Coordinate(Area area)
        {
            this.x = rnd.Next(area.X1, area.X2);
            this.y = rnd.Next(area.Y1, area.Y2);
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Get X coordinate
        /// </summary>
        public int X
        {
            get { return x; }
        }

        /// <summary>
        /// Get Y coordinate
        /// </summary>
        public int Y
        {
            get { return y; }
        }

        #endregion


        #region Public Methods

        #region Neighbour
        /// <summary>
        /// Get a neighbour coordinate
        /// </summary>
        /// <param name="direction">Get the neighbour in this direction</param>
        /// <returns>Coordinate of the neighbour</returns>
        public Coordinate GetNeighbour(Direction direction)
        {
            if (direction == Direction.Up)
            {
                return new Coordinate(X, Y - 1);
            }
            else if (direction == Direction.Down)
            {
                return new Coordinate(X, Y + 1);
            }
            else if (direction == Direction.Left)
            {
                return new Coordinate(X - 1, Y);
            }
            else //Right
            {
                return new Coordinate(X + 1, Y);
            }
        }
        #endregion

        #region Equals
        /// <summary>
        /// Is the coordinte equal to another coordinate
        /// </summary>
        /// <param name="coordinate">The coordinate to test</param>
        /// <returns>True if equal, else False</returns>
        public bool Equals(Coordinate coordinate)
        {
            if (coordinate.X == X && coordinate.Y == Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is coordinate present in a list of coordinates
        /// FIXME: function should be renamed to something else than Equals
        /// </summary>
        /// <param name="coordinates">List of coordinates</param>
        /// <returns>True if coordinate is in list, else False</returns>
        public bool Equals(List<IArea> coordinates)
        {
            foreach (Coordinate coordinate in coordinates)
            {
                if (Equals(coordinate))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region In area
        /// <summary>
        /// Is this coordinate inside the bounds of an area
        /// </summary>
        /// <param name="area">The area to test</param>
        /// <returns>True if coordinate is in area, else False</returns>
        public bool InArea(Area area)
        {
            if (X >= area.X1 && X <= area.X2 && Y >= area.Y1 && Y <= area.Y2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Is coordinate in the top of an area
        /// </summary>
        /// <param name="area">The area to test</param>
        /// <returns>True if coordinate is in upper end of the area, else False</returns>
        public bool IsInTop(Area area)
        {
            if (X >= area.X1 && X <= area.X2 && Y >= area.Y1 && Y <= (area.Y2/2))
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
        /// Get top left X coordinate (same as bottom right (it's only a coordinate, not an area))
        /// </summary>
        int IArea.X1
        {
            get { return x; }
        }

        /// <summary>
        /// Get bottom right X coordinate (same as top left (it's only a coordinate, not an area))
        /// </summary>
        int IArea.X2
        {
            get { return x; }
        }

        /// <summary>
        /// Get top left Y coordinate (same as bottom right (it's only a coordinate, not an area))
        /// </summary>
        int IArea.Y1
        {
            get { return y; }
        }

        /// <summary>
        /// Get bottom right Y coordinate (same as top left (it's only a coordinate, not an area))
        /// </summary>
        int IArea.Y2
        {
            get { return y; }
        }
        #endregion

    }


}
