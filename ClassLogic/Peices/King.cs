﻿using System;
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
