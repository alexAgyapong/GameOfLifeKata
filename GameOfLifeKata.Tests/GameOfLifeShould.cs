using NUnit.Framework;

namespace GameOfLifeKata.Tests
{
    [TestFixture]
    public class GameOfLifeShould
    {
        [Test]
        public void Kill_a_liveCell_with_no_neighbours()
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);
            var game = new GameOfLife(grid);

            var nextGeneration = game.Evolve();
            Assert.IsFalse(nextGeneration.IsAlive(cell));
        }

        [Test]
        public void Preserve_a_liveCell_with_two_neighbours()
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);
            grid.AddCell(cell);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 2));
            var game = new GameOfLife(grid);

            var nextGeneration = game.Evolve();
            Assert.IsTrue(nextGeneration.IsAlive(cell));
        }

        [Test]
        public void Preserve_a_liveCell_with_three_neighbours()
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);
            grid.AddCell(cell);
            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 0));
            var game = new GameOfLife(grid);

            var nextGeneration = game.Evolve();
            Assert.IsTrue(nextGeneration.IsAlive(cell));
        }

        [Test]
        public void Kill_a_liveCell_with_more_than_three_neighbours()
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);
            grid.AddCell(cell);

            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 0));
            grid.AddCell(new Cell(2, 0));
            var game = new GameOfLife(grid);

            var nextGeneration = game.Evolve();
            Assert.IsFalse(nextGeneration.IsAlive(cell));
        }

        [Test]
        public void Revive_a_deadcell_with_exactly_three_live_neighbours()
        {
            var grid = new Grid();
            var cell = new Cell(1, 1);

            grid.AddCell(new Cell(0, 1));
            grid.AddCell(new Cell(0, 2));
            grid.AddCell(new Cell(0, 0));
            var game = new GameOfLife(grid);

            var nextGeneration = game.Evolve();
            Assert.IsTrue(nextGeneration.IsAlive(cell));
        }

    }
}
