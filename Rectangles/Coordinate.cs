using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangles
{
    public class Coordinate
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;

        public bool isWithingrid(Coordinate g)
        {
            if (X < 0 || Y < 0 || X >= g.X || Y >= g.Y)
            {
                return false;
            }

            return true;
        }
        public bool isWithingrid(RectangleItem Grid)
        {
            return isWithingrid(new Coordinate() { X = Grid.SizeX, Y = Grid.SizeY });
        }
    }
}
