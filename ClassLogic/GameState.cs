﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public  class GameState
    {
        private Player white;
        private Board board;

        public Board Board
        {
            get;
        }
        public Player CurrentPlayer 
        { 
            get;
            private set;
        }
        public Result Result { get; private set; }= null;
        public GameState(Board board, Player player)
        {
           Board = board;
           CurrentPlayer = player;
        }

        public GameState(Player white, Board board)
        {
            this.white = white;
            this.board = board;
        }

        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                  return Enumerable.Empty<Move>();
            }
            Piece piece= Board[pos];
            IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        public void MakeMove(Move move)
        {
            Board.SetPawnSkipPosition(CurrentPlayer, null);
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
            CheckForGameOver();
        }
        public IEnumerable<Move> AllLegalMovesFor(Player player)
        {
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });
            return moveCandidates.Where(move => move.IsLegal(Board));
        }
        private void CheckForGameOver()
        {
            if(!AllLegalMovesFor(CurrentPlayer).Any())
            {
                Result = Result.Win(CurrentPlayer.Opponent());
            }
            else
            {
                Result = Result.Draw(EndReason.Stalemate);
            }
        }
        public bool IsGameOver()
        {
            return Result != null;
        }
    }
}
