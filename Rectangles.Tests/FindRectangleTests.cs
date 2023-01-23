using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangles.Tests
{
    class FindRectangleTests
    {
        GridManager grid = new Rectangles.GridManager();


        [SetUp]
        public void Setup()
        {
            grid.setSize(new Coordinate() { X = 10, Y = 10 });
        }


        [Test]
        public void Find1()
        {
            grid.clear();
            try
            {
                var result1 = grid.addRectangle(
                   new Coordinate() { X = 2, Y = 2 },
                   new Coordinate() { X = 2, Y = 2 }
                   );
                var result2 = grid.findRectanglePrompt(
                  new Coordinate() { X = 2, Y = 2 }
                  );
                Assert.IsTrue(result2 != null);
            }
            catch (Exception e)
            {
                Assert.Fail();
            }
        }

        [Test]
        public void FindNone()
        {
            grid.clear();
            try
            {
                var result1 = grid.addRectangle(
                   new Coordinate() { X = 2, Y = 2 },
                   new Coordinate() { X = 2, Y = 2 }
                   );
                var result2 = grid.findRectanglePrompt(
                  new Coordinate() { X = 8, Y = 8 }
                  );
                Assert.Fail();
            }
            catch (Exception e)
            {
                Assert.Pass();
            }
        }
    }
}
