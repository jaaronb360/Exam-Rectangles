using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rectangles.Tests
{

    class AddRectangleTests
    {
        GridManager grid = new Rectangles.GridManager();


        [SetUp]
        public void Setup()
        {
            grid.setSize(new Coordinate() { X = 10, Y = 10 });
        }

        [Test]
        public void AddRectangle()
        {
            grid.clear();

            var result = grid.addRectangle(
                new Coordinate() { X = 2, Y = 2 },
                new Coordinate() { X = 2, Y = 2 }
                );

            Assert.IsTrue(result);
        }


        [Test]
        public void AddRectangleOffBounds()
        {
            grid.clear();

            try
            {
                var result = grid.addRectangle(
                  new Coordinate() { X = 9, Y = 2 },
                  new Coordinate() { X = 10, Y = 2 }
                  );

            } catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToLower().Contains("out of bounds"));
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void AddRectangleOverlapping()
        {
            grid.clear();

            try
            {
                var result1 = grid.addRectangle(
                  new Coordinate() { X = 2, Y = 2 },
                  new Coordinate() { X = 5, Y = 5 }
                  );
                var result2 = grid.addRectangle(
                    new Coordinate() { X = 5, Y = 5 },
                    new Coordinate() { X = 2, Y = 2 }
                    );

            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.ToLower().Contains("overlap"));
                return;
            }

            Assert.Fail();
        }
    }
}
