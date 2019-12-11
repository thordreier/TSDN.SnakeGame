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
    /// Class holding some food ;-)
    /// </summary>
    public class SnakeFood
    {

        #region Private Static Variables

        private static Random rnd = new Random();

        #endregion


        #region Private Variables

        private SnakeGameDraw draw;
        private List<Snake> allSnakes;
        private Area field;
        private int minSize, maxSize;
        private Area area;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="draw">Drawing object</param>
        /// <param name="allSnakes">A list with all the snakes in the game</param>
        /// <param name="field">The playfield</param>
        /// <param name="minSize">The minimum size of a piece of food</param>
        /// <param name="maxSize">The maximum size of a piece of food</param>
        public SnakeFood(SnakeGameDraw draw, List<Snake> allSnakes, Area field, int minSize, int maxSize)
        {
            this.draw = draw;
            this.allSnakes = allSnakes;
            this.field = field;
            this.minSize = minSize;
            this.maxSize = maxSize;
            Move();
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the area the food is
        /// </summary>
        public Area Area
        {
            get { return area; }
        }

        #endregion


        #region Public Methods

        #region Move
        /// <summary>
        /// Move the food to a new location
        /// </summary>
        public void Move()
        {
            //Undraw the old area
            if (area != null)
            {
                draw.Draw(area, Elements.Background);
            }

            //Get an random area
            int size = rnd.Next(minSize - 1, maxSize - 1);

            //Shrink the area if it's bigger than the playfield
            Coordinate topLeft = new Coordinate(field);
            for (int i = 0; i <= size; i++)
            {
                Coordinate bottomRight = new Coordinate(topLeft.X + i, topLeft.Y + i);
                Area tmpArea = new Area(topLeft, bottomRight);
                if (tmpArea.InArea(field)) //[FIXME] check for snakebodyS
                {
                    area = tmpArea;
                }
                else
                {
                    break;
                }
            }

            //Draw the new area
            draw.Draw(area, Elements.SnakeFood);
        }
        #endregion

        #endregion

    }


}
