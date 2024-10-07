using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type 
        { 
            get; 
        }
        public abstract Player Color 
        { 
            get;
        }
        public bool Hasmoved 
        { 
            get; 
            set; 
        }= false;
        public abstract Piece Copy();
        public abstract IEnumerable<Move> GetMoves(Position From, Board board);
        protected IEnumerable<Position> MovePositionInDir(Position From, Board board, Direction dir) 
        {
            for (Position pos = From + dir; Board.IsInside(pos); pos += dir)
            {
                if (board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }
                Piece piece = board[pos];
                if (piece.Color != Color)
                {
                    yield return pos;
                }
                yield break;
            }
        }

        protected IEnumerable<Position> MovePositionsInDirs(Position From, Board board, Direction[] dirs)
        {
            return dirs.SelectMany(dir => MovePositionInDir(From, board, dir));
        }


    }
}
