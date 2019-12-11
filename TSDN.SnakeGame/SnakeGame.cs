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
using System.Threading;
using System.Windows.Forms;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// Class controlling the logic about a snake game
    /// </summary>
    public class SnakeGame
    {

        #region Nested Enums

        /// <summary>
        /// Enum containing key combos to control a snake
        /// </summary>
        private enum HandlerKeys
        {
            Arrow = 0,
            WASD = 1,
            Numeric = 2,
            IJKL = 3
        }

        #endregion


        #region Private Variables

        private frmPlayGround form;
        private Area field;
        private SnakeGameDraw draw;
        private List<Snake> allSnakes = new List<Snake>();
        private ISnakeController[] handlerKeys = new ISnakeController[4];
        private GameType gameType;
        private int speed;
        private bool respawn;

        private Graphics[] canvas = new Graphics[2];

        private System.Windows.Forms.Timer timer;
        private int snakeID = 0;
        private SnakeFood[] snakeFood;

        private SnakeGameTCPServer tcpServer;
        private SnakeGameTCPClient tcpClient;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="form">The window to draw in</param>
        /// <param name="gameType">The type of game</param>
        /// <param name="playerArrow">True if player controlling with arrow keys is playing</param>
        /// <param name="playerWASD">True if player controlling with W, A, S and D is playing</param>
        /// <param name="playerNumeric">True if player controlling with numeric keys is playing</param>
        /// <param name="playerIJKL">True if player controlling with I, J, K, L is playing</param>
        /// <param name="hostname">The hostname to connect to if game type is client</param>
        /// <param name="pixelSize">The width of a "game pixel" measured in "screen pixels"</param>
        /// <param name="xWidth">The width (X) of the playfield. Not used if game type is client</param>
        /// <param name="yHeight">The height (Y) of the playfield. Not used if game type is client</param>
        /// <param name="speed">The speed of the game, lower is faster. Not used if game type is client</param>
        /// <param name="tcpPort">The TCP port used to connect to/listen on. Not used if game type is standalone</param>
        /// <param name="respawn">Should snakes respawn when they dies. Not used if game type is client</param>
        /// <param name="foodMin">The minimum size of a piece of food. Not used if game type is client</param>
        /// <param name="foodMax">The maximum size of a piece of food. Not used if game type is client</param>
        /// <param name="foodCount">Number of foo pieces. Not used if game type is client</param>
        public SnakeGame(frmPlayGround form, GameType gameType,
            bool playerArrow, bool playerWASD, bool playerNumeric, bool playerIJKL,
            String hostname,
            //advanced options:
            int pixelSize, int xWidth, int yHeight,
            int speed, int tcpPort, bool respawn,
            int foodMin, int foodMax, int foodCount
            )
        {

            this.gameType = gameType;
            this.form = form;

            field = new Area();
            this.draw = new SnakeGameDraw(canvas, pixelSize, field);

            if (gameType == GameType.Standalone || gameType == GameType.Server)
            {

                Field = new Area(0, 0, xWidth - 1, yHeight - 1); ;

                //Create the timer used to set the speed
                this.speed = speed;
                this.timer = new System.Windows.Forms.Timer();
                this.timer.Interval = speed;
                this.timer.Tick += new System.EventHandler(this.MoveStuff);

                this.respawn = respawn;

                //Create the food objects
                snakeFood = new SnakeFood[foodCount];
                for (int i = 0; i < foodCount; i++)
                {
                    snakeFood[i] = new SnakeFood(draw, allSnakes, field, foodMin, foodMax);
                }

                #region Snake creation
                if (playerArrow == true)
                {
                    Snake snake = CreateSnake();
                    handlerKeys[(int)HandlerKeys.Arrow] = snake;
                }
                if (playerWASD == true)
                {
                    Snake snake = CreateSnake();
                    handlerKeys[(int)HandlerKeys.WASD] = snake;
                }
                if (playerNumeric == true)
                {
                    Snake snake = CreateSnake();
                    handlerKeys[(int)HandlerKeys.Numeric] = snake;
                }
                if (playerIJKL == true)
                {
                    Snake snake = CreateSnake();
                    handlerKeys[(int)HandlerKeys.IJKL] = snake;
                }

                if (gameType == GameType.Server)
                {
                    tcpServer = new SnakeGameTCPServer(this, tcpPort);
                }
                #endregion

                draw.DrawAll();
                timer.Enabled = true;
            }
            else if (gameType == GameType.Client)
            {

                tcpClient = new SnakeGameTCPClient(this, hostname, tcpPort);

                #region Snake controller creation
                if (playerArrow == true)
                {
                    SnakeTCPController snake = new SnakeTCPController(snakeID++, tcpClient);
                    handlerKeys[(int)HandlerKeys.Arrow] = snake;
                }
                if (playerWASD == true)
                {
                    SnakeTCPController snake = new SnakeTCPController(snakeID++, tcpClient);
                    handlerKeys[(int)HandlerKeys.WASD] = snake;
                }
                if (playerNumeric == true)
                {
                    SnakeTCPController snake = new SnakeTCPController(snakeID++, tcpClient);
                    handlerKeys[(int)HandlerKeys.Numeric] = snake;
                }
                if (playerIJKL == true)
                {
                    SnakeTCPController snake = new SnakeTCPController(snakeID++, tcpClient);
                    handlerKeys[(int)HandlerKeys.IJKL] = snake;
                }
                #endregion

                tcpClient.Connect(snakeID);
            }

        }

        #endregion


        #region Public Properties

        /// <summary>
        /// Gets the drawing object
        /// </summary>
        public SnakeGameDraw SnakeGameDraw
        {
            get { return draw; }
        }

        /// <summary>
        /// Gets/sets the area of the playfield
        /// </summary>
        public Area Field
        {
            get { return field; }

            set
            {
                //Change the size of the area
                field.ChangeSize(value);

                //Resize the window (thread safe)
                MethodInvoker methodInvoker = new MethodInvoker(delegate
                {
                    form.ResizeForm(draw.Rectangle.Size);
                });
                if (form.InvokeRequired)
                {
                    form.Invoke(methodInvoker);
                }
                else
                {
                    methodInvoker.Invoke();
                }

                //Change the direct/buffered Graphics object to the new window size
                canvas[0] = form.CreateGraphics();
                canvas[1] = form.canvasBuffer;
            }
        }

        #endregion


        #region Public Methods

        #region Stop
        /// <summary>
        /// Stop the game
        /// </summary>
        public void Stop()
        {
            if (timer != null)
            {
                timer.Enabled = false;
            }
            if (tcpClient != null)
            {
                tcpClient.Stop();
            }
            if (tcpServer != null)
            {
                tcpServer.Stop();
            }
        }
        #endregion

        #region CreateSnake
        /// <summary>
        /// Creates a snake with incremantal ID
        /// </summary>
        /// <returns></returns>
        public Snake CreateSnake()
        {
            Snake snake = new Snake(snakeID++, draw, field, allSnakes, snakeFood, respawn);
            allSnakes.Add(snake);
            return snake;
        }
        #endregion

        #region KeyboardHandler
        /// <summary>
        /// Handles keypresses
        /// </summary>
        /// <param name="e">The eventhandler containing the pressed key</param>
        public void KeyboardHandler(KeyEventArgs e)
        {
            ISnakeController snake;
            switch (e.KeyData)
            {
                #region Pause
                case Keys.P:
                    if (timer != null)
                    {
                        timer.Enabled = !timer.Enabled;
                    }
                    break;
                #endregion

                #region Arrow
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    snake = handlerKeys[(int)HandlerKeys.Arrow];
                    if (snake != null)
                    {
                        switch (e.KeyData)
                        {
                            case Keys.Up:
                                snake.SnakeDirection = Direction.Up;
                                break;
                            case Keys.Down:
                                snake.SnakeDirection = Direction.Down;
                                break;
                            case Keys.Left:
                                snake.SnakeDirection = Direction.Left;
                                break;
                            case Keys.Right:
                                snake.SnakeDirection = Direction.Right;
                                break;
                        }
                    }
                    break;
                #endregion

                #region WASD
                case Keys.W:
                case Keys.A:
                case Keys.S:
                case Keys.D:
                    snake = handlerKeys[(int)HandlerKeys.WASD];
                    if (snake != null)
                    {
                        switch (e.KeyData)
                        {
                            case Keys.W:
                                snake.SnakeDirection = Direction.Up;
                                break;
                            case Keys.S:
                                snake.SnakeDirection = Direction.Down;
                                break;
                            case Keys.A:
                                snake.SnakeDirection = Direction.Left;
                                break;
                            case Keys.D:
                                snake.SnakeDirection = Direction.Right;
                                break;
                        }
                    }
                    break;
                #endregion

                #region Numeric
                case Keys.NumPad8:
                case Keys.NumPad4:
                case Keys.NumPad5:
                case Keys.NumPad6:
                    snake = handlerKeys[(int)HandlerKeys.Numeric];
                    if (snake != null)
                    {
                        switch (e.KeyData)
                        {
                            case Keys.NumPad8:
                                snake.SnakeDirection = Direction.Up;
                                break;
                            case Keys.NumPad5:
                                snake.SnakeDirection = Direction.Down;
                                break;
                            case Keys.NumPad4:
                                snake.SnakeDirection = Direction.Left;
                                break;
                            case Keys.NumPad6:
                                snake.SnakeDirection = Direction.Right;
                                break;
                        }
                    }
                    break;
                #endregion

                #region IJKL
                case Keys.I:
                case Keys.J:
                case Keys.K:
                case Keys.L:
                    snake = handlerKeys[(int)HandlerKeys.IJKL];
                    if (snake != null)
                    {
                        switch (e.KeyData)
                        {
                            case Keys.I:
                                snake.SnakeDirection = Direction.Up;
                                break;
                            case Keys.K:
                                snake.SnakeDirection = Direction.Down;
                                break;
                            case Keys.J:
                                snake.SnakeDirection = Direction.Left;
                                break;
                            case Keys.L:
                                snake.SnakeDirection = Direction.Right;
                                break;
                        }
                    }
                    break;
                #endregion

            }
        }
        #endregion

        #region MoveStuff
        /// <summary>
        /// Moves all the snakes (and indirectly food)
        /// </summary>
        /// <param name="sender">Required by Timer.Tick, not used</param>
        /// <param name="e">Required by Timer.Tick, not used</param>
        public void MoveStuff(object sender, EventArgs e)
        {
            foreach (Snake snake in allSnakes)
            {
                snake.MoveSnake();
            }

            //Draw for real
            draw.DrawUpdate();
        }
        #endregion

        #endregion

    }


}
