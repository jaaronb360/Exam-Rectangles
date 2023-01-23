using NUnit.Framework;
using Rectangles;
using System;

namespace Rectangles.Tests
{
    public class GridTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SetGridSize1()
        {
            var grid = new Rectangles.GridManager();
            grid.setSize(new Coordinate() { X = 5, Y = 10 });
            Assert.Pass();
        }

        [Test]
        public void SetGridSize2()
        {
            var grid = new Rectangles.GridManager();
            try
            {
                grid.setSize(new Coordinate() { X = 3, Y = 10 });
            }
            catch (Exception e)
            {
                Assert.Pass();
                return;
            }

            Assert.Fail();
        }

        [Test]
        public void SetGridSize3()
        {
            var grid = new Rectangles.GridManager();
            grid.setSize(new Coordinate() { X = 24, Y = 20 });
            Assert.Pass();
        }


    }
}