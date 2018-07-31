using System.Collections.Generic;
using System.Linq;

namespace GameOfLifeKata.Tests
{
    public class Grid
    {
        private readonly ICollection<Cell> liveCells = new List<Cell>();


        public void AddCell(Cell cell)
        {
            liveCells.Add(cell);
        }

        public IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            return liveCells.Where(c => c.NeigboursWith(cell));
        }

        public bool IsAlive(Cell cell)
        {
            return liveCells.Contains(cell);
        }

        public Grid NextGenerationGrid()
        {
            var grid = new Grid();
            foreach (var liveCell in liveCells)
                if (ShouldPreserve(liveCell))
                    grid.AddCell(liveCell);
 
            foreach (var cell in CellsToBeReborn())
                grid.AddCell(cell);
 
            return grid;
        }

        private IEnumerable<Cell> CellsToBeReborn()
        {
            return liveCells
                .SelectMany(DeadNeigboursOf)
                .Where(cell => GetNeighbours(cell).Count() == 3);
        }

        private IEnumerable<Cell> DeadNeigboursOf(Cell cell)
        {
            return cell.MyNeighbours().Where(IsDead);
        }

        private bool IsDead(Cell cell)
        {
            return !IsAlive(cell);
        }

        private bool ShouldPreserve(Cell liveCell)
        {
            var numberOfNeighbours = GetNeighbours(liveCell).Count();
            return numberOfNeighbours == 2 || numberOfNeighbours == 3;
        }
    }
}