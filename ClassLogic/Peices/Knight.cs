using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Knight: Piece
    {
        public override PieceType Type => PieceType.knight;
        public override Player Color
        {
            get;
        }
        public Knight (Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.Hasmooved = Hasmooved;
            return copy;
        }
    }
}
