using System;

namespace XsBattleServer.Model
{
    public class Board
    {
        private Cell[,] _cells;

        public static Board CreateBoard(int verticalLength, int horizontalLength)
        {
            var board = new Board();
            board.InitializeCells(verticalLength, horizontalLength);
            return board;
        }

        private void InitializeCells(int verticalLength, int horizontalLength)
        {
            if (_cells != null)
            {
                throw new InvalidOperationException("Cells already initialized");
            }
            
            _cells = new Cell[verticalLength, horizontalLength];
            for (var y = 0; y < verticalLength; y++)
            {
                for (int x = 0; x < horizontalLength; x++)
                {
                    _cells[y, x] = new Cell(y, x);
                }
            }
        }
    }
}