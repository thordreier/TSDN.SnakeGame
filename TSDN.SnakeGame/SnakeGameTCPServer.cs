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

using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace TSDN.SnakeGame
{


    /// <summary>
    /// TCP server
    /// </summary>
    public class SnakeGameTCPServer
    {

        #region Private Variables

        private SnakeGame snakeGame;
        private int port;

        private TcpListener tcpListener;
        private Thread listener;
        private List<SnakeGameTCPServerConnection> connections = new List<SnakeGameTCPServerConnection>();

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="snakeGame">SnakeGame object</param>
        /// <param name="port">TCP port to listen on</param>
        public SnakeGameTCPServer(SnakeGame snakeGame, int port)
        {
            this.snakeGame = snakeGame;
            this.port = port;

            listener = new Thread(new ThreadStart(Listener));
            listener.Start();
        }

        #endregion


        #region Private Methods

        #region Listener
        /// <summary>
        /// Method containing thread listening for clients
        /// </summary>
        private void Listener()
        {
            //start listing on the given port
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();

            while (!tcpListener.Pending())
            {
                Thread.Sleep(200);
                SnakeGameTCPServerConnection connection = new SnakeGameTCPServerConnection(snakeGame, tcpListener.AcceptSocket());
                connections.Add(connection);
            }
        }
        #endregion

        #endregion


        #region Public Methods

        #region Stop
        /// <summary>
        /// Stop the listener and closes all connections
        /// </summary>
        public void Stop()
        {
            listener.Abort();
            foreach(SnakeGameTCPServerConnection connection in connections)
            {
                connection.Stop();
            }
            tcpListener.Stop();
        }
        #endregion

        #endregion

    }


}
