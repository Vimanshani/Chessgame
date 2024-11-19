using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class PawnPromotion :  Move
    {
        public override MovingWay Way => MovingWay.PawnPromotion;
        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly PieceType newType;

        public PawnPromotion (Position from, Position to,PieceType newType)
        {
            FromPos = from;
            ToPos = to;
            this.newType = newType;
        }

        private Piece CreatePromotionPiece(Player color)
        {
            return newType switch
            {
                PieceType.knight => new Knight(color),
                PieceType.bishop => new Bishop(color),
                PieceType.rook => new Rook(color),
                _ => new Queen(color)
            };
        }

        public override bool Execute (Board board)
        {
            Piece pawn = board[FromPos];
            board[FromPos] = null;

            Piece promotionPiece = CreatePromotionPiece(pawn.Color);
            promotionPiece.Hasmoved = true;
            board[ToPos] = promotionPiece;

            return true;
        }
    }
}
