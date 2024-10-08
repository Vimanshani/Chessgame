using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Queen:Piece
    {
        public override PieceType Type => PieceType.queen;
        public override Player Color
        {
            get;
        }
        private static readonly Direction[] dirs = new Direction[]
        {
             Direction.East,
             Direction.South,
             Direction.West,
             Direction.North,
             Direction.SouthWest,
             Direction.SouthEast,
             Direction.NorthWest,
             Direction.NorthEast,
        };
        public  Queen (Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Queen copy = new Queen (Color);
            copy.Hasmoved = Hasmoved;
            return copy;
        }
        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            return MovePositionsInDirs(from, board, dirs).Select(to => new Normal(from, to));
        }
    }
}
