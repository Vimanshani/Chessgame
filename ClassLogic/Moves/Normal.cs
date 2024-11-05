using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Normal:Move
    {
        private Direction rookFromPos;
        private Direction rookToPos;

        public override MovingWay Way => MovingWay.Normal;
        public override Position FromPos { get; }
        public override Position ToPos { get; }
        public Normal(Position From , Position To) 
        {
            FromPos = From;
            ToPos = To;
        }

        public Normal(Direction rookFromPos, Direction rookToPos)
        {
            this.rookFromPos = rookFromPos;
            this.rookToPos = rookToPos;
        }

        public override void Execute(Board board)
        {
            Piece piece = board[FromPos];
            board[ToPos] = piece;
            board[FromPos] = null;
            piece.Hasmoved = true;
        }

    }
}
