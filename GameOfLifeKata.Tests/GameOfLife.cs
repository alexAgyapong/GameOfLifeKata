using System.Collections.Generic;

namespace GameOfLifeKata.Tests
{
    public class GameOfLife
    {
        private Grid grid;

        public GameOfLife(Grid grid)
        {
            this.grid = grid;
        }

        public Grid Evolve()
        {
            grid = grid.NextGenerationGrid();
            return grid;
        }
    }
}