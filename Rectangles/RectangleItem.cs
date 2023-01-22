using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangles
{
    public class RectangleItem
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public int index { get; set; }
        
        public void initialize(int sx, int sy, int px, int py)
        {
            this.SizeX = sx;
            this.SizeY = sy;
            this.PosX = px;
            this.PosY = py;
        }
    }
}
