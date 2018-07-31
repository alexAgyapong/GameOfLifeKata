using System.Linq;
using NUnit.Framework;

namespace GameOfLifeKata.Tests
{
    [TestFixture]
    public class GridShould
    {
        [Test]
        public void Return_neighours_for_cell_with_no_neighbours()
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);

            grid.AddCell(cell);
            grid.AddCell(new Cell(1, 3));

            var neighbours = grid.GetNeighbours(cell);
            Assert.That(neighbours.Count, Is.EqualTo(0));
        }

        [TestCase(0, 1)]
        [TestCase(2, 1)]
        [TestCase(1, 2)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        [TestCase(2, 2)]
        [TestCase(0, 2)]
        [TestCase(2, 0)]
        public void Return_neighours_for_cell_with_1_neighbour(int x, int y)
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);

            grid.AddCell(cell);
            grid.AddCell(new Cell(x, y));

            var neighbours = grid.GetNeighbours(cell);
            Assert.That(neighbours.Count, Is.EqualTo(1));
            CollectionAssert.Contains(neighbours, new Cell(x, y));
        }

        [Test]
        public void Return_8_neighbours_for_a_cell_surrounded_by_live_cells()
        {
            var grid = new Grid();
            for (var x = 0; x < 5; x++)
                for (var y = 0; y < 5; y++)
                    grid.AddCell(new Cell(x, y));

            Assert.That(grid.GetNeighbours(new Cell(1, 1)).Count(), Is.EqualTo(8));
        }
        [TestCase(1, -1)]
        [TestCase(3, 1)]
        [TestCase(1, 3)]
        [TestCase(-1, 1)]
        public void Return_neighours_for_cell_with_no_neighbours(int x, int y)
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);

            grid.AddCell(cell);
            grid.AddCell(new Cell(x, y));

            var neighbours = grid.GetNeighbours(cell);
            Assert.That(neighbours.Count, Is.EqualTo(0));
        }

        [Test]
        public void Report_when_cell_is_dead()
        {
            var grid = new Grid();
            var livingCell = new Cell(1, 1);
            var celltoTest = new Cell(0, 0);

            grid.AddCell(livingCell);

            Assert.IsFalse(grid.IsAlive(celltoTest));
        }

        [Test]
        public void Report_when_cell_is_alive()
        {
            var grid = new Grid();
            var livingCell = new Cell(0, 0);
            var celltoTest = new Cell(0, 0);

            grid.AddCell(livingCell);

            Assert.IsTrue(grid.IsAlive(celltoTest));
        }

    }
}