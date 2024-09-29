﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Queen:Piece
    {
        public override PieceType Type => PieceType.queen;
        public override Player Color
        {
            get;
        }
        public  Queen (Player color)
        {
            Color = color;
        }
        public override Piece Copy()
        {
            Queen copy = new Queen (Color);
            copy.Hasmooved = Hasmooved;
            return copy;
        }
    }
}
