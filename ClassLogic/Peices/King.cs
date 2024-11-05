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

        private static bool IsUnmovedRook(Position pos, Board board)
        {
            if(board.IsEmpty(pos))
            {
                return false;
            }
            Piece piece = board[pos];
            return piece.Type == PieceType.rook && !piece.Hasmoved;
        }
        private static bool AllEmpty(IEnumerable<Position> positions, Board board)
        {
            return positions.All(pos=> board.IsEmpty(pos));
        }
        private bool CanCastleKingSide(Position from, Board board)
        {
            if (Hasmoved)
            {
                return false;
            }
            Position rookPos = new Position(from.Raw, 7);
            Position[] betweenPositions = new Position[] { new(from.Raw, 5), new(from.Raw, 6) };

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board); 
        }
        private bool CanCastleQueenSide(Position from, Board board)
        {
            if (Hasmoved)
            {
                return false;
            }
            Position rookPos = new Position(from.Raw, 0);
            Position[] betweenPositions = new Position[] { new(from.Raw, 1), new(from.Raw, 2), new(from.Raw, 3) };
            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }
        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.Hasmoved = Hasmoved;
            return copy;
        }
        private IEnumerable<Position> MovePositions(Position from, Board board)
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

        public override IEnumerable<Move> GetMoves(Position from, Board board)
        {
            foreach (Position to in MovePositions(from, board))
            {
               yield return new Normal(from, to);
            }
            if(CanCastleKingSide(from, board))
            {
                yield return new Castle(MovingWay.CastleKS, from);
            }
            if (CanCastleQueenSide(from, board))
            {
                yield return new Castle(MovingWay.CastleQS, from);
            }
        }
        public override bool CanCaptureOpponentKing(Position from, Board board)
        {
            return MovePositions(from, board).Any(to =>
            {
                Piece piece = board[to];
                return piece != null && piece.Type == PieceType.king;
            });
        }

    }
}
