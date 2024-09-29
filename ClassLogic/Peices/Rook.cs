﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Rook: Piece
    {
        public override PieceType Type => PieceType.rook;
        public override Player Color
        {
            get;
        }
        public Rook (Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Rook copy = new Rook(Color);
            copy.Hasmooved = Hasmooved;
            return copy;
        }
    }
}
