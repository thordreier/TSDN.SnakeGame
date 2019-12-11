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

using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// TCP client
    /// </summary>
    public class SnakeGameTCPClient
    {

        #region Private Variables

        private SnakeGame snakeGame;
        private String hostname;
        private int port;
        private SnakeGameDraw draw;

        private TcpClient tcpClient;
        private NetworkStream stream;

        private BinaryFormatter formatter = new BinaryFormatter();
        private int numSnakes;

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snakeGame">SnakeGame object</param>
        /// <param name="hostname">The hostname to connect to</param>
        /// <param name="port">The TCP port to connect to</param>
        public SnakeGameTCPClient(SnakeGame snakeGame, String hostname, int port)
        {
            this.snakeGame = snakeGame;
            this.hostname = hostname;
            this.port = port;
            this.draw = snakeGame.SnakeGameDraw;
        }

        #endregion


        #region Private Methods

        #region ConnectThread
        /// <summary>
        /// Method containing thread recieving data from server
        /// </summary>
        private void ConnectThread()
        {
            try
            {
                tcpClient = new TcpClient();
                tcpClient.Connect(hostname, port);
                stream = tcpClient.GetStream();
                SendPacket(new SnakeGameTCPPacketInit(numSnakes));

                while(true)
                {
                    Object o = formatter.Deserialize(stream);
                    if (o is SnakeGameTCPPacketInitResponse)
                    {
                        SnakeGameTCPPacketInitResponse packet = (SnakeGameTCPPacketInitResponse)o;
                        snakeGame.Field = packet.Field;
                        draw.DrawAll();
                    }
                    else if (o is SnakeGameTCPPacketDraw)
                    {
                        SnakeGameTCPPacketDraw packet = (SnakeGameTCPPacketDraw)o;
                        draw.Draw(packet.DrawUpdate);
                        draw.DrawUpdate();
                    }
                }

            }
            catch (Exception)
            {
                Stop();
                System.Windows.Forms.MessageBox.Show("Connection lost to server");
            }
        }
        #endregion

        #endregion


        #region Public Methods

        #region Connect
        /// <summary>
        /// Connect to server
        /// </summary>
        /// <param name="numSnakes">Number of snakes this client is responsible for</param>
        public void Connect(int numSnakes)
        {
            this.numSnakes = numSnakes;
            Thread th = new Thread(new ThreadStart(ConnectThread));
            th.Start();
        }
        #endregion

        #region Stop
        /// <summary>
        /// Closes the connection
        /// </summary>
        public void Stop()
        {
            tcpClient.Close();
        }
        #endregion

        #region SendPacket
        /// <summary>
        /// Sends a packet to server
        /// </summary>
        /// <param name="o">Object to send (should implement serialize)</param>
        public void SendPacket(object o)
        {
            formatter.Serialize(stream, o);
            stream.Flush();
        }
        #endregion

        #endregion

    }


}
