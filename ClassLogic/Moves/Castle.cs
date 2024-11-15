using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Castle : Move
    {
        public override MovingWay Way { get; }
        public override Position FromPos { get; }
        public override Position ToPos { get; }
        private readonly Direction kingMoveDir;
        private readonly Direction rookFromPos;
        private readonly Direction rookToPos;
        public Castle(MovingWay way, Position kingPos)
        {
            Way = way;
            FromPos = kingPos;
            if(way == MovingWay.CastleKS)
            {
                kingMoveDir = Direction.East;
                ToPos = new Position(kingPos.Raw, 6);
                rookFromPos = new Position(kingPos.Raw, 7);
                rookToPos = new Position(kingPos.Raw, 5);
            }
            else if(way == MovingWay.CastleQS)
            {
                kingMoveDir = Direction.West;
                ToPos = new Position(kingPos.Raw, 2);
                rookFromPos = new Position(kingPos.Raw, 0);
                rookToPos = new Position(kingPos.Raw, 3);
            }
           
        }
        public override void Execute(Board board)
        {
            new Normal(FromPos, ToPos).Execute(board);
            new Normal(rookFromPos,rookToPos).Execute(board);

        }
        public override bool IsLegal(Board board)
        {
            Player player = board[FromPos].Color;
            if(board.IsInCheck(player))
            {
                return false;
            }
            Board copy = board.Copy();
            Position kingPosInCopy = FromPos;

            for (int i=0;i<2;i++)
            {
                new Normal(kingPosInCopy,kingPosInCopy + kingMoveDir).Execute(copy);
                kingPosInCopy += kingMoveDir;

                if(copy.IsInCheck(player))
                {
                    return false;
                }
            }
            return true;  
        }

    }
}
