﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class DoublePawn: Move
    {
        public override MovingWay Way => MovingWay.DoublePawn;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly Position skippedPos;

        public DoublePawn(Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
            skippedPos = new Position((from.Raw + to.Raw)/2,from.Column);
        }
        public override bool Execute (Board board)
        {
            Player player = board[FromPos].Color;
            board.SetPawnSkipPosition(player,skippedPos);
            new Normal(FromPos,ToPos).Execute(board);

            return true;
        }
    }
}
