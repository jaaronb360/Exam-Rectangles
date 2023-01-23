using System;
using System.Collections.Generic;
using System.Linq;

namespace Rectangles
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensionLabel = new List<string>() { "Size X", "Size Y" };
            var dimensions = new List<int>();
            var grid = new GridManager();
            var gridSize = new Coordinate();
            do
            {
                Console.Write("Input size (X,Y) from 5 to 25:");
                gridSize = grid.getCoordinates(false);
                if (gridSize == null)
                    return;

                try
                {
                    grid.setSize(gridSize);
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
              
             
                break;

            } while (true);

         

            do
            {
                Console.Clear();
                Console.WriteLine("===========================================================");
                Console.WriteLine($"==========     GRID - {gridSize.X}x{gridSize.Y} Starting Index: 0  =============");
                Console.WriteLine("===========================================================\n");
                grid.render();
                Console.WriteLine("\n============================================\n");
                Console.WriteLine("1. Add Rectangle");
                Console.WriteLine("2. Find a rectangle (from X and Y)");
                Console.WriteLine("3. Remove rectangle (from X and Y)");
                Console.WriteLine("4. Clear grid");
                Console.WriteLine("5. Unit Testing");
                Console.WriteLine("6. Exit");
                Console.Write("Enter a choice (1-4): ");
                var choice = Console.ReadKey();
                Console.Write("\n");

                switch (choice.KeyChar)
                {
                    case '1':
                        Console.Write("Enter starting position ");
                        var startPos = grid.getCoordinates();
                        if (startPos == null) continue;

                        Console.Write("Enter Rectangle size ");
                        var rectSize = grid.getCoordinates();
                        if (rectSize == null) continue;

                        try
                        {
                            var result = grid.addRectangle(startPos, rectSize);
                            if (result)
                            {
                                Console.WriteLine("Rectangle Added!");
                                Console.ReadKey();
                            }
                        } catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                     
                      
                        break;
                    case '2':
                        Console.Write("Enter Target Coordinate ");
                        var startPosFind = grid.getCoordinates();
                        if (startPosFind == null) continue;

                        try
                        {
                            var resultfind = grid.findRectanglePrompt(startPosFind);
                            if (resultfind != null)
                            {
                                Console.WriteLine($"Rectangle {resultfind.index.ToString()} found!");
                                Console.ReadKey();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case '3':
                        Console.Write("Enter Target Coordinate ");
                        var startPosRemove = grid.getCoordinates();
                        if (startPosRemove == null) continue;

                        try
                        {
                            var resultrem = grid.removeRectangle(startPosRemove);
                            if (resultrem)
                            {
                                Console.WriteLine("Rectangle removed!");
                                Console.ReadKey();
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                        }
                        break;
                    case '4':
                        grid.clear();
                        Console.WriteLine("All Rectangles removed.");
                        Console.ReadKey();
                        continue;
                        break;
                    case '5':
                        grid.addRectangle(new Coordinate() { X = 2, Y = 2 }, new Coordinate() { X = 3, Y = 3 });
                        grid.addRectangle(new Coordinate() { X = 5, Y = 1 }, new Coordinate() { X = 2, Y = 2 });
                        grid.addRectangle(new Coordinate() { X = 5, Y = 3 }, new Coordinate() { X = 2, Y = 2 });
                        grid.addRectangle(new Coordinate() { X = 5, Y = 3 }, new Coordinate() { X = 1, Y = 1 });

                        break;
                    case '6':
                        return;
                        break;
                    default:
                        Console.Write("\nInvalid choice");
                        Console.ReadKey();
                        break;
                }

            } while (true);
        }

 
    }
}
