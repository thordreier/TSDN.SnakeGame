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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TSDN.SnakeGame
{
    public partial class frmSetup : Form
    {

        public frmSetup()
        {
            InitializeComponent();
            radioGameType_CheckedChanged(this, new EventArgs());
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Form playground = new frmPlayGround();
            GameType gameType;
            if(radioStandalone.Checked == true)
            {
                gameType = GameType.Standalone;
            }
            else if(radioServer.Checked == true)
            {
                gameType = GameType.Server;
            }
            else //radioClient.Checked == true
            {
                gameType = GameType.Client;
            }

            SnakeGame snakeGame = new SnakeGame((frmPlayGround)playground, gameType,
                chkboxPlayerArrow.Checked, chkboxPlayerWASD.Checked,
                chkboxPlayer8456.Checked, chkboxPlayerIJKL.Checked,
                textHostname.Text, (int)numPixel.Value, (int)numX.Value, (int)numY.Value,
                (int)numSpeed.Value, (int)numTCPport.Value, chkboxRespawn.Checked,
                (int)numFoodMin.Value, (int)numFoodMax.Value, (int)numFoodCount.Value);

            ((frmPlayGround)playground).snakeGame = snakeGame;
            this.Visible = false;

            playground.Show();
        }

        private void numFoodMax_ValueChanged(object sender, EventArgs e)
        {
            if (numFoodMax.Value < numFoodMin.Value)
            {
                numFoodMin.Value = numFoodMax.Value;
            }
        }

        private void numFoodMin_ValueChanged(object sender, EventArgs e)
        {
            if (numFoodMin.Value > numFoodMax.Value)
            {
                numFoodMax.Value = numFoodMin.Value;
            }
        }

        private void radioGameType_CheckedChanged(object sender, EventArgs e)
        {
            if (radioStandalone.Checked || radioServer.Checked)
            {
                lblHostname.Visible = false;
                textHostname.Visible = false;

                lblXwidth.Visible = true;
                numX.Visible = true;
                lblYhight.Visible = true;
                numY.Visible = true;

                grboxSnakeFood.Visible = true;

                grboxGameplay.Visible = true;
            }
            else // radioClient.Checked
            {
                lblHostname.Visible = true;
                textHostname.Visible = true;

                lblXwidth.Visible = false;
                numX.Visible = false;
                lblYhight.Visible = false;
                numY.Visible = false;

                grboxSnakeFood.Visible = false;

                grboxGameplay.Visible = false;
            }

            if (radioStandalone.Checked)
            {
                grboxNetworkSettings.Visible = false;
            }
            else //radioServer.Checked || radioClient.Checked
            {
                grboxNetworkSettings.Visible = true;
            }
        }

        private void frmSetup_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


    }
}