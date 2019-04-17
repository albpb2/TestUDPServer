using System;
using System.Collections.Generic;
using System.Linq;
using XsBattleCommon;

namespace XsBattleServer.Model
{
    public class Board
    {
        private const int MaxPlayers = 50;
        
        private Cell[,] _cells;
        private List<PlayerCharacter> _players;
        private Dictionary<int, PlayerCharacter> _playersById;
        private Dictionary<Direction, Func<Cell, Cell>> _movementTargets;

        private Board()
        {
            _players = new List<PlayerCharacter>(MaxPlayers);
            _playersById = new Dictionary<int, PlayerCharacter>();
            
            _movementTargets = new Dictionary<Direction, Func<Cell, Cell>>
            {
                [Direction.Up] = cell => new Cell(cell.Y + 1, cell.X),
                [Direction.Down] = cell => new Cell(cell.Y - 1, cell.X),
                [Direction.Left] = cell => new Cell(cell.Y, cell.X + 1),
                [Direction.Right] = cell => new Cell(cell.Y, cell.X - 1),
            };
        }

        public static Board CreateBoard(int verticalLength, int horizontalLength)
        {
            var board = new Board();
            board.InitializeCells(verticalLength, horizontalLength);
            return board;
        }

        public int VerticalSize => _cells.GetLength(0);
        
        public int HorizontalSize => _cells.GetLength(1);

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

        public void AddPlayer(PlayerCharacter player)
        {
            if (_players.Count >= MaxPlayers)
            {
                throw new InvalidOperationException("The number of players is full");
            }
            
            _players.Add(player);
            _playersById.Add(player.PlayerId, player);
        }

        public bool IsCellFree(Cell cell)
        {
            return !_players.Any(p => p.IsOccupyingCell(cell));
        }

        public Cell GetCellFromCurrent(Cell cell, Direction movementDirection)
        {
            var newCell = _movementTargets[movementDirection](cell);
            return CellIsInBoard(newCell) ? newCell : null;
        }

        public bool CellIsInBoard(Cell cell)
        {
            return
                cell.Y >= 0
                && cell.Y < VerticalSize
                && cell.X >= 0
                && cell.X < HorizontalSize;
        }

        public PlayerCharacter GetPlayerCharacter(int playerId) => _playersById[playerId];
    }
}