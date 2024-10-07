using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public  class Pawn: Piece
    {
        public override PieceType Type => PieceType.pawn;
        public override Player Color
        {
            get;
        }

        private readonly Direction forward; 
        public Pawn(Player color)
        {
            Color = color;
            if (color == Player.White)
            {
                forward = Direction.North;
            }else if (color == Player.Black)
            {
                forward = Direction.South;
            }
        }
        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.Hasmoved = Hasmoved;
            return copy;
        }
        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }
        private bool CanCaptureAt(Position pos, Board board)
        {
            if (!Board.IsInside(pos) || board.IsEmpty(pos))
            {
                return false;
            }
            return board[pos].Color != Color;
        }
        private IEnumerable<Move> ForwardMoves(Position from, Board board)
        {
            Position oneMovePos = from + forward;
            if(CanMoveTo(oneMovePos, board))
            {
                yield return new Normal(from,oneMovePos);
                Position twoMovePos = oneMovePos + forward;
                if(!Hasmoved && CanMoveTo(twoMovePos,board))
                {
                    yield return new Normal(from,twoMovePos);
                }
            }
        }
    }
}
