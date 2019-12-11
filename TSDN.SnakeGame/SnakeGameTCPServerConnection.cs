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
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// Class responsible for a connection to a client
    /// </summary>
    public class SnakeGameTCPServerConnection
    {

        #region Private Variables

        private SnakeGame snakeGame;
        private SnakeGameDraw draw;

        private BinaryFormatter formatter = new BinaryFormatter();
        private Socket socket;
        private NetworkStream stream;
        private Thread reciever;
        private SnakeGameDraw.DrawHook drawHook;
        private Snake[] snakes;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snakeGame">SnakeGame object</param>
        /// <param name="socket">Socket to send to/recieve from</param>
        public SnakeGameTCPServerConnection(SnakeGame snakeGame, Socket socket)
        {
            this.snakeGame = snakeGame;
            this.socket = socket;
            this.draw = snakeGame.SnakeGameDraw;

            drawHook = new SnakeGameDraw.DrawHook(DrawHook);

            reciever = new Thread(new ThreadStart(RecieveLoop));
            reciever.Start();
        }

        #endregion


        #region Privat Methods

        #region RecieveLoop
        /// <summary>
        /// Method containing thread recieving data from client
        /// </summary>
        private void RecieveLoop()
        {

            while (true)
            {
                if (socket.Connected)
                {
                    stream = new NetworkStream(socket);

                    while (true)
                    {
                        try
                        {
                            Object o = formatter.Deserialize(stream);

                            if (o is SnakeGameTCPPacketInit)
                            {
                                SnakeGameTCPPacketInit packet = (SnakeGameTCPPacketInit)o;
                                snakes = new Snake[packet.NumSnakes];
                                for (int i = 0; i < packet.NumSnakes; i++)
                                {
                                    snakes[i] = snakeGame.CreateSnake();
                                }
                                SendPacket(new SnakeGameTCPPacketInitResponse(snakeGame.Field));
                                draw.DrawAllToHook(drawHook);
                                draw.DrawHooks += drawHook;
                            }
                            else if (o is SnakeGameTCPPacketDirection)
                            {
                                SnakeGameTCPPacketDirection packet = (SnakeGameTCPPacketDirection)o;
                                if (snakes != null && snakes[packet.SnakeID] != null)
                                {
                                    snakes[packet.SnakeID].SnakeDirection = packet.Direction;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Stop();
                        }
                    }
                }
                else
                {
                    Stop();
                }
            }
        }
        #endregion

        #region DrawHook
        /// <summary>
        /// Method to hook into draw object
        /// </summary>
        /// <param name="drawUpdate">List of elements to draw</param>
        private void DrawHook(List<AreaColor> drawUpdate)
        {
            SendPacket(new SnakeGameTCPPacketDraw(drawUpdate));
        }
        #endregion

        #region SendPacket
        /// <summary>
        /// Send packet to Client
        /// </summary>
        /// <param name="o">Object to send (should implement serialize)</param>
        private void SendPacket(object o)
        {
            try
            {
                formatter.Serialize(stream, o);
                stream.Flush();
            }
            catch (Exception)
            {
                Stop();
            }
        }
        #endregion

        #endregion


        #region Public Methods

        #region Stop
        /// <summary>
        /// Stops the connection to the client
        /// </summary>
        public void Stop()
        {
            reciever.Abort();
            draw.DrawHooks -= drawHook;
            socket.Close();
            foreach (Snake snake in snakes)
            {
                snake.Stop();
            }
        }
        #endregion

        #endregion

    }


}
