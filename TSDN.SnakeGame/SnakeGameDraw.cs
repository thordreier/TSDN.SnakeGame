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


namespace TSDN.SnakeGame
{


    /// <summary>
    /// Snake game drawing class
    /// </summary>
    public class SnakeGameDraw
    {

        #region Private Methods

        private Graphics[] canvas;
        private int pixelSize;
        private Area field;
        private Color[] colors;
        private Dictionary<IArea, Color> allElements = new Dictionary<IArea, Color>();
        private List<AreaColor> drawUpdate = new List<AreaColor>();

        #endregion


        #region Public Delegate Stuff

        public delegate void DrawHook(List<AreaColor> drawUpdate);
        public event DrawHook DrawHooks; //fixme private

        #endregion


        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="canvas">List of Graphics objects to draw to</param>
        /// <param name="pixelSize">The width of a "game pixel" measured in "screen pixels"</param>
        /// <param name="field">The game field</param>
        public SnakeGameDraw(Graphics[] canvas, int pixelSize, Area field)
        {
            this.canvas = canvas;
            this.pixelSize = pixelSize;
            this.field = field;
            SetColors();
        }

        #endregion


        #region Private Methods

        #region Color Methods
        /// <summary>
        /// Sets all the colors of the different objects
        /// </summary>
        private void SetColors()
        {
            colors = new Color[] {
                Color.Gray,   //Background
                Color.Yellow, //SnakeFood
                Color.Blue,   //Snake 1
                Color.Red,    //Snake 2
                Color.Pink,   //Snake 3
                Color.Green,  //Snake 4
                Color.Black,  //Snake 5
                Color.Beige,  //Snake 6
                Color.Cyan,   //Snake 7
                Color.Orange, //Snake 8
            };
        }

        /// <summary>
        /// Gets the color of an element
        /// </summary>
        /// <param name="element">Element</param>
        /// <returns>Color of element</returns>
        private Color GetColor(Elements element)
        {
            return colors[(int)element];
        }

        /// <summary>
        /// Gets the color of a snake
        /// </summary>
        /// <param name="snakeID">The ID of the snake</param>
        /// <returns>Color of the snake</returns>
        private Color GetColor(int snakeID)
        {
            return colors[(snakeID % (colors.Length - (int)Elements.Snake)) + (int)Elements.Snake];
        }
        #endregion

        #region Rectangle Methods
        /// <summary>
        /// Gets the rectangle an area is covering
        /// </summary>
        /// <param name="area">The area</param>
        /// <returns>Rectangle</returns>
        private Rectangle GetRectangle(IArea area)
        {
            return new Rectangle(pixelSize * area.X1, pixelSize * area.Y1,
                pixelSize * (area.X2 - area.X1 + 1), pixelSize * (area.Y2 - area.Y1 + 1));
        }

        /// <summary>
        /// Gets the rectangle the playfield is covering
        /// </summary>
        public Rectangle Rectangle
        {
            get { return GetRectangle(field); }
        }
        #endregion

        #region AllElements
        /// <summary>
        /// Add/remove area/color to/from the list of all elements
        /// </summary>
        /// <param name="area">Area to add/remove</param>
        /// <param name="color">Color of the area to add/remove</param>
        private void AllElements(IArea area, Color color)
        {
            //If the color is background color remove the object from the list
            if (color == GetColor(Elements.Background))
            {
                allElements.Remove(area);
            }
            //else add the object to the list
            else
            {
                allElements.Add(area, color);
            }
        }

        /// <summary>
        /// Add/remove area/color to/from the list of all elements
        /// </summary>
        /// <param name="areaColor">Area/color to add/remove</param>
        private void AllElements(AreaColor areaColor)
        {
            AllElements(areaColor.Area, areaColor.Color);
        }

        /// <summary>
        /// Add/remove area/color to/from the list of all elements
        /// </summary>
        /// <param name="areaColors">List of area/color to add/remove</param>
        private void AllElements(List<AreaColor> areaColors)
        {
            foreach (AreaColor areaColor in areaColors)
            {
                AllElements(areaColor);
            }
        }
        #endregion

        #region DrawToHooks
        /// <summary>
        /// Send drawing to all delegates
        /// </summary>
        private void DrawToHooks()
        {
            if (DrawHooks != null)
            {
                DrawHooks(drawUpdate);
            }
        }
        #endregion

        #region DrawToCanvas
        /// <summary>
        /// Draw element to all Graphics objects
        /// </summary>
        /// <param name="rectangle">The rectangle to draw</param>
        /// <param name="color">The color of the rectangle</param>
        private void DrawToCanvas(Rectangle rectangle, Color color)
        {
            foreach (Graphics graphics in canvas)
            {
                graphics.FillRectangle(new SolidBrush(color), rectangle);
            }
        }

        /// <summary>
        /// Draw element to all Graphics objects
        /// </summary>
        /// <param name="area">The area to draw</param>
        /// <param name="color">The color of the area</param>
        private void DrawToCanvas(IArea area, Color color)
        {
            DrawToCanvas(GetRectangle(area), color);
        }

        /// <summary>
        /// Draw element to all Graphics objects
        /// </summary>
        /// <param name="areaColor">The area/color to draw</param>
        private void DrawToCanvas(AreaColor areaColor)
        {
            DrawToCanvas(areaColor.Area, areaColor.Color);
        }
        #endregion

        #endregion


        #region Public Methods

        #region DrawAllToHook
        /// <summary>
        /// Draw evererything to delegate
        /// </summary>
        /// <param name="drawHook">Delegate method</param>
        public void DrawAllToHook(DrawHook drawHook)
        {
            List<AreaColor> areaColors = new List<AreaColor>();
            foreach (KeyValuePair<IArea, Color> kvp in allElements)
            {
                areaColors.Add(new AreaColor(kvp.Key, kvp.Value));
            }
            drawHook(areaColors);
        }
        #endregion

        #region Draw for real methods
        /// <summary>
        /// Draw all elements
        /// </summary>
        public void DrawAll()
        {
            DrawToCanvas(field, GetColor(Elements.Background));
            foreach(KeyValuePair<IArea, Color> kvp in allElements)
            {
                DrawToCanvas(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Draw all elements changed since last draw
        /// </summary>
        public void DrawUpdate()
        {
            DrawToHooks();
            foreach (AreaColor areaColor in drawUpdate)
            {
                DrawToCanvas(areaColor);
            }
            drawUpdate.Clear();
        }
        #endregion


        #region Draw color
        /// <summary>
        /// Draw to buffer
        /// </summary>
        /// <param name="areaColor">Area/color to put in draw buffer</param>
        public void Draw(AreaColor areaColor)
        {
            drawUpdate.Add(areaColor);
            AllElements(areaColor);
        }

        /// <summary>
        /// Draw to buffer
        /// </summary>
        /// <param name="areaColors">List of area/color to put in draw buffer</param>
        public void Draw(List<AreaColor> areaColors)
        {
            drawUpdate.AddRange(areaColors);
            AllElements(areaColors);
        }
        #endregion

        #region Draw element
        /// <summary>
        /// Draw to buffer
        /// </summary>
        /// <param name="area">Area to draw to buffer</param>
        /// <param name="element">Element type the area is representing</param>
        public void Draw(IArea area, Elements element)
        {
            Draw(new AreaColor(area, GetColor(element)));
        }

        /// <summary>
        /// Draw to buffer
        /// </summary>
        /// <param name="areas">List of areas to draw to buffer</param>
        /// <param name="element">Element type the areas are representing</param>
        public void Draw(List<IArea> areas, Elements element)
        {
            foreach (IArea area in areas)
            {
                Draw(area, element);
            }
        }
        #endregion

        #region Draw snakeID
        /// <summary>
        /// Draw to buffer
        /// </summary>
        /// <param name="area">Area to draw to buffer</param>
        /// <param name="snakeID">Snake ID the area is representing</param>
        public void Draw(IArea area, int snakeID)
        {
            Draw(new AreaColor(area, GetColor(snakeID)));
        }

        /// <summary>
        /// Draw to buffer
        /// </summary>
        /// <param name="areas">List of areas to draw to buffer</param>
        /// <param name="snakeID">Snake ID the area are representing</param>
        public void Draw(List<IArea> areas, int snakeID)
        {
            foreach (IArea area in areas)
            {
                Draw(area, snakeID);
            }
        }
        #endregion

        #endregion

    }


}
