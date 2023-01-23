using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rectangles
{
    class GridManager
    {
        private RectangleItem Grid { get; set; }
        private List<RectangleItem> Rectangles { get; set; }

        public GridManager()
        {
            Grid = new RectangleItem();
            Rectangles = new List<RectangleItem>();
        }

        public void setSize(Coordinate i)
        {
            this.Grid.initialize(i.X, i.Y, 0, 0);
        }

        public void render()
        {
            for (var coordY = 0; coordY < Grid.SizeY; coordY++)
            {
                if (coordY == 0)
                {
                    for (var coordX = 0; coordX < Grid.SizeX; coordX++)
                    {
                        if(coordX == 0 && coordY == 0) Console.Write("   ");
                        if (coordX < 10) Console.Write(" ");
                        Console.Write(coordX.ToString() + " ");

                    }
                    Console.Write("\n");

                }


                for (var coordX = 0; coordX < Grid.SizeX;coordX++)
                {
                

                    if(coordX == 0)
                    {
                        if (coordY < 10) Console.Write(" ");
                        Console.Write(coordY.ToString() + " ");
                    }

                    var foundItem = this.findRectangle(coordX, coordY);
                    if (foundItem == null)
                        Console.Write("-- ");
                    else
                        Console.Write((foundItem.index < 10 ? " " : "") + foundItem.index.ToString() + " ");
                }
                Console.Write("\n");
            }
        }


        private RectangleItem findRectangle(int coordX, int coordY)
        {
            return Rectangles.Find(x => coordX >= x.PosX && coordX < (x.PosX + x.SizeX) && coordY >= x.PosY && coordY < (x.PosY + x.SizeY));
        }

        public Coordinate getCoordinates(bool withinGrid = true)
        {
            do
            {
                Console.Write(" (X,Y) or enter 'c' to cancel: ");
                var coordString = Console.ReadLine();
                if (coordString == "c") return null;

                var coordinates = coordString.Split(',');

                if (coordinates.Length != 2)
                {
                    Console.WriteLine("Invalid input format, try again!");
                    continue;
                }

                int coordX = -1, coordY = -1;

                int.TryParse(coordinates[0], out coordX);
                int.TryParse(coordinates[1], out coordY);

                if (coordX == -1 || coordY == -1)
                {
                    Console.WriteLine("Invalid input format, try again!");
                    continue;
                }
                var newCoord = new Coordinate()
                {
                    X = coordX,
                    Y = coordY
                };
                if (withinGrid && !newCoord.isWithingrid(this.Grid))
                {
                    Console.WriteLine("invalid coordinate, try again!");
                    continue;
                }

                return newCoord;
            } while (true);
          
        }

        public void clear()
        {
            this.Rectangles.Clear();
        }

        public void addRectangle(Coordinate startPos, Coordinate rectSize)
        {

            if (!startPos.isWithingrid(this.Grid))
            {
                Console.WriteLine("Invalid starting position!");
                Console.ReadKey();
                return;
            }

            var endPoint = new Coordinate()
            {
                X = startPos.X + rectSize.X - 1,
                Y = startPos.Y + rectSize.Y - 1
            };

            if (!endPoint.isWithingrid(this.Grid))
            {
                Console.WriteLine("Rectangle size going out of bounds.");
                Console.ReadKey();
                return;
            }


            for (var coordX = startPos.X; coordX < startPos.X + rectSize.X; coordX++)
            {
                for (var coordY = startPos.Y; coordY < startPos.Y + rectSize.Y; coordY++)
                {
                    var existingRect = this.findRectangle(coordX, coordY);
                    if (existingRect != null)
                    {
                        Console.WriteLine("Rectangle is going to overlap Rectangle " + existingRect.index.ToString());
                        Console.ReadKey();
                        return;
                    }
                }
            }

            this.Rectangles.Add(new RectangleItem()
            {
                index = this.Rectangles.Count + 1,
                PosX = startPos.X,
                PosY = startPos.Y,
                SizeX = rectSize.X,
                SizeY = rectSize.Y
            });


            Console.WriteLine("Rectangle Added!");
            Console.ReadKey();
            return;
        }

        public void findRectanglePrompt(Coordinate target)
        {

            if (!target.isWithingrid(this.Grid))
            {
                Console.WriteLine("Invalid Target Coordinate!");
                Console.ReadKey();
                return;
            }

            var rectangleFind = this.findRectangle(target.X, target.Y);

            if (rectangleFind == null)
            {
                Console.WriteLine("No rectangle found");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("You found rectangle " + rectangleFind.index.ToString());
            Console.ReadKey();
        }


        public void removeRectangle(Coordinate target)
        {
            if (!target.isWithingrid(this.Grid))
            {
                Console.WriteLine("Invalid Target Coordinate!");
                Console.ReadKey();
                return;
            }

            var rectangleRemove = this.findRectangle(target.X, target.Y);

            if (rectangleRemove == null)
            {
                Console.WriteLine("No rectangle found");
                Console.ReadKey();
                return;
            }

            this.Rectangles = this.Rectangles.Where(x => x.index != rectangleRemove.index).ToList();

            Console.WriteLine("Rectangle " + rectangleRemove.index.ToString() + " removed.");
            Console.ReadKey();
        }
    }
}
