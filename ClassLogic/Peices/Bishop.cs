using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Bishop: Piece
    {
        public override PieceType Type => PieceType.bishop;
        public override Player Color
        {
            get;
        }
        public Bishop(Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Bishop copy = new Bishop(Color);
            copy.Hasmooved = Hasmooved;
            return copy;
        }
    }
}
