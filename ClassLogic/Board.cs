﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChessLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        private readonly Dictionary<Player, Position> pawnSkipPositions = new Dictionary<Player, Position>
        {
            {Player.White, null },
            {Player.Black, null }
        };
        public Piece this[int raw, int col]
        {
            get
            {
                return pieces[raw, col];
            }
            set
            {
                pieces[raw, col] = value;
            }
        }
        public Piece this[Position pos]
        {
            get {return this[pos.Raw , pos.Column]; }
            set { this[pos.Raw, pos.Column]= value; }
        }
        public Position GetPawnSkipPosition(Player player)
        {
            return pawnSkipPositions[player];
        }
        public void SetPawnSkipPosition(Player player, Position pos)
        {
            pawnSkipPositions[player] = pos;
        }

        public static Board Initial()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }
        public void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4]  = new King(Player.Black);
            this[0, 5]  = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);

            for (int i = 0; i < 8; i++)
            {
                this[1, i] = new Pawn(Player.Black);
                this[6, i] = new Pawn(Player.White);
            }
        }
        public static bool IsInside(Position pos)
        {
            return pos.Raw >=0 && pos.Raw <8 && pos.Column >=0 && pos.Column <8;
        }
        public  bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }
        public IEnumerable<Position> PiecePosition()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Position pos = new Position(r, c);
                    if (!IsEmpty(pos))
                    {
                        yield return pos;
                    }
                }
            }
        }
        public IEnumerable<Position> PiecePositionsFor(Player player)
        {
            return PiecePosition().Where(pos => this[pos].Color == player);
        }
        public bool IsInCheck(Player player)
        {
            return PiecePositionsFor(player.Opponent()).Any(pos =>
            {
                Piece piece = this[pos];
                return piece.CanCaptureOpponentKing(pos, this);
            });
        }
        public Board Copy()
        {
            Board copy = new Board();
            foreach (Position pos in PiecePosition())
            {
                copy[pos]= this[pos].Copy();
            }
            return copy;
        }
        public Counting CountPieces()
        {
            Counting counting = new Counting();
            foreach (Position pos in PiecePosition())
            {
                Piece piece = this[pos];
                counting.Increment(piece.Color, piece.Type);
            }
            return counting;
        }
        public bool InsufficientMaterial()
        {
            Counting counting=  CountPieces();
            return IsKingVKing(counting)||IsKingBishopVKing(counting)|| IsKingKnightVKing(counting) || IsKingBishopVKingBishop(counting);
        }
        private static bool IsKingVKing(Counting counting)
        {
            return counting.TotalCount == 2;
        }
        private static bool IsKingBishopVKing(Counting counting)
        {
            return counting.TotalCount == 3 && (counting.White(PieceType.bishop) == 1 || counting.Black(PieceType.bishop) == 1 );
        }
        private static bool IsKingKnightVKing(Counting counting)
        {
            return counting.TotalCount == 3 && (counting.White(PieceType.knight) == 1 || counting.Black(PieceType.knight) == 1);
        }
        private  bool IsKingBishopVKingBishop(Counting counting)
        {
            if (counting.TotalCount != 4)
            {
                return false;
            }
            if (counting.White(PieceType.bishop) != 1 || counting.Black(PieceType.bishop) != 1)
            {
               return false ;
            }
            Position wBishopPos = FindPiece(Player.White, PieceType.bishop);
            Position bBishopPos = FindPiece(Player.Black, PieceType.bishop);

            return wBishopPos.Squarecolor() == bBishopPos.Squarecolor();
        }
        private Position FindPiece(Player color, PieceType type)
        {
            return PiecePositionsFor(color).First(pos => this[pos].Type == type);
        }
    }
}
