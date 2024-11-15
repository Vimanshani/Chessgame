﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class EnPassant: Move
    {
        public override MovingWay Way => MovingWay.EnPassant;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly Position capturePos;

        public EnPassant (Position from, Position to)
        {
            FromPos = from;
            ToPos = to;
            capturePos = new Position(from.Raw ,to.Column) ;
        }

        public override void Execute(Board board)
        {
            new Normal(FromPos, ToPos).Execute(board);
            board[capturePos] = null;
        }
    }
}
