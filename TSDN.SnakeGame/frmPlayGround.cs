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
    public partial class frmPlayGround : Form
    {


        public SnakeGame snakeGame;
        private Bitmap canvasBitmap;
        public Graphics canvasBuffer;


        public frmPlayGround()
        {
            InitializeComponent();
            InitializeSurface();
        }

        private void PlayGround_KeyDown(object sender, KeyEventArgs e)
        {
            snakeGame.KeyboardHandler(e);
        }

        private void InitializeSurface()
        {
            // Create a drawing surface with the same dimensions as the client
            // area of the form.
            canvasBitmap = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            // Create a Graphics object that references the bitmap and clear it.
            canvasBuffer = Graphics.FromImage(canvasBitmap);
            canvasBuffer.Clear(SystemColors.Control);
        }

        private void frmPlayGround_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics canvas = e.Graphics)
            {
                canvas.DrawImage(canvasBitmap, 0, 0,
                   canvasBitmap.Width,
                 canvasBitmap.Height);
            }
        }

        public void ResizeForm(Size size)
        {
            ClientSize = size;
            InitializeSurface();
        }

        private void frmPlayGround_FormClosed(object sender, FormClosedEventArgs e)
        {
            snakeGame.Stop();
            Application.Exit();
        }

    
    }
}