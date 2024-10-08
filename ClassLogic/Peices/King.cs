using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class King: Piece
    {
        public override PieceType Type => PieceType.king;
        public override Player Color
        {
            get;
        }
        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.East,
            Direction.West,
            Direction.North,
            Direction.South,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest,
            Direction.NorthEast,
        };
        public King (Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.Hasmoved = Hasmoved;
            return copy;
        }
        private IEnumerable<Position> MovePosition(Position from, Board board)
        {
           foreach (Direction dir in dirs)
            {
                Position to = from + dir;
                if (!Board.IsInside(to))
                {
                    continue;
                }
                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move>

    }
}
