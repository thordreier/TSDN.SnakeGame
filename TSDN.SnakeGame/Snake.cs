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

using System.Windows.Forms;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// Snake class
    /// This is where all the logic about snake movement i kept
    /// </summary>
    public class Snake : ISnakeController
    {

        #region Private Variables

        // From constructor parameters
        private int iD;
        private SnakeGameDraw draw;
        private Area field;
        private List<Snake> allSnakes;
        private SnakeFood[] snakeFood;
        private bool respawn;

        private Direction direction;
        private List<IArea> snakeBody = new List<IArea>();
        private bool isDead;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="iD">The ID of the snake</param>
        /// <param name="draw">Drawing object</param>
        /// <param name="field">The playfield</param>
        /// <param name="allSnakes">A list with all the snakes in the game</param>
        /// <param name="snakeFood">A list with all the food</param>
        /// <param name="respawn">should the snake respawn when it dies</param>
        public Snake(int iD, SnakeGameDraw draw, Area field, List<Snake> allSnakes, SnakeFood[] snakeFood, bool respawn)
        {
            this.iD = iD;
            this.draw = draw;
            this.field = field;
            this.allSnakes = allSnakes;
            this.snakeFood = snakeFood;
            this.respawn = respawn;
            CreateSnake();
        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the ID of the snake
        /// </summary>
        public int ID
        {
            get { return iD; }
        }

        /// <summary>
        /// Gets the list of coordinates that makes up the snake body
        /// </summary>
        public List<IArea> SnakeBody
        {
            get { return snakeBody; }
        }

        /// <summary>
        /// Gets/sets the direction the snake is going
        /// </summary>
        public Direction SnakeDirection
        {
            get { return direction; }

            //ISnakeController Member
            set
            {
                if (DirectionHelper.GetOppositDirection(value) != direction)
                {
                    direction = value;
                }
            }
        }

        #endregion


        #region Private Methods

        #region CreateSnake
        /// <summary>
        /// Creates the snake
        /// This is called every time the snake should (re)spawn
        /// </summary>
        private void CreateSnake()
        {
            isDead = false;
            Coordinate startCoordinate = new Coordinate(field);

            //If the snake is in the top of the field, move down, else move up
            if (startCoordinate.IsInTop(field))
            {
                this.direction = Direction.Down;
            }
            else
            {
                this.direction = Direction.Up;
            }

            snakeBody.Add(startCoordinate);
            draw.Draw(snakeBody, Elements.Snake);
        }
        #endregion

        #region SnakeCrash
        /// <summary>
        /// Checks if the snake has crashed into the bounds of the playfield
        /// or another snake (or it's own tail)
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        private bool SnakeCrash(Coordinate head)
        {
            if (head.InArea(field))
            {
                foreach (Snake snake in allSnakes)
                {
                    if (head.Equals(snake.SnakeBody))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region RemoveTail
        /// <summary>
        /// Removes the last bit of the tail
        /// </summary>
        private void RemoveTail()
        {
            Coordinate tail = (Coordinate)snakeBody[snakeBody.Count - 1];
            snakeBody.RemoveAt(snakeBody.Count - 1);
            draw.Draw(tail, Elements.Background);
        }
        #endregion

        #endregion


        #region Public Methods

        #region Stop
        /// <summary>
        /// Kill's the snake and don't make it respawn
        /// </summary>
        public void Stop()
        {
            respawn = false;
            isDead = true;
        }
        #endregion

        #region MoveSnake
        /// <summary>
        /// Moves the snake
        /// </summary>
        public void MoveSnake()
        {
            //Respawn the snake if the length is 0
            if (snakeBody.Count == 0)
            {
                if (respawn == true)
                {
                    CreateSnake();
                }
            }
            //else check what to do
            else
            {
                Coordinate head = (Coordinate)snakeBody[0];
                Coordinate newHead = head.GetNeighbour(direction);

                //If the snake is dead or has crashed, kill it and remove the tail
                if (SnakeCrash(newHead) || isDead == true)
                {
                    isDead = true;
                    RemoveTail();
                }
                //else check what to do
                else
                {
                    bool grow = false;

                    //Check if snake has eaten some snake food
                    foreach (SnakeFood food in snakeFood)
                    {
                        //If snake has eaten som snake food,
                        //grow the snake and move the food to another coordinate
                        if (newHead.InArea(food.Area))
                        {
                            food.Move();
                            grow = true;
                        }
                    }

                    //Remove the tail unless the snake should grow
                    if (grow == false)
                    {
                        RemoveTail();
                    }

                    //Insert the new head in the snake body and draw it
                    snakeBody.Insert(0, newHead);
                    draw.Draw(newHead, iD);
                }
            }
        }
        #endregion

        #endregion

    }


}
