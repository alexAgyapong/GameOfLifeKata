using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeKata.Tests
{
    public struct Cell
    {
        private readonly int x;
        private readonly int y;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"Cell: {x},{y}";
        }

        // (x-1, y-1) (x, y-1) (x+1, y-1)
        // (x-1, y)            (x+1, y)
        // (x-1, y+1) (x, y+1) (x+1, y+1)

        public IEnumerable<Cell> MyNeighbours()
        {
            for (var offsetX = -1; offsetX <= 1; offsetX++)
                for (var offsetY = -1; offsetY <= 1; offsetY++)
                    if (!(offsetX == 0 && offsetY == 0))
                        yield return new Cell(x + offsetX, y + offsetY);

        }

        public bool NeigboursWith(Cell cell)
        {
            return MyNeighbours().Any(neighbour => neighbour.Equals(cell));
        }
    }
}