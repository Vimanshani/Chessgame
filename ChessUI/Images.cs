using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ChessLogic;

namespace ChessUI
{
    public static class Images
    {
        private static readonly Dictionary<PieceType, ImageSource> whiteSources = new()
        {
            {PieceType.pawn, LoadImage("Assests/PawnW.png") },
            {PieceType.bishop, LoadImage("Assests/BishopW.png") },
            {PieceType.knight, LoadImage("Assests/KnightW.png")},
            {PieceType.rook, LoadImage("Assests/RookW.png")},
            {PieceType.king, LoadImage("Assests/KingW.png")},
            {PieceType.queen, LoadImage("Assests/QueenW.png")},
        };
        private static readonly Dictionary<PieceType, ImageSource> blackSources = new()
        {
            {PieceType.pawn, LoadImage("Assests/PawnB.png") },
            {PieceType.bishop, LoadImage("Assests/BishopB.png") },
            {PieceType.knight, LoadImage("Assests/KnightB.png")},
            {PieceType.rook, LoadImage("Assests/RookB.png")},
            {PieceType.king, LoadImage("Assests/KingB.png")},
            {PieceType.queen, LoadImage("Assests/QueenB.png")},
        };
        public static ImageSource LoadImage(string filepath)
        {
            return new BitmapImage(new Uri(filepath, UriKind.Relative));
        }

        public static ImageSource GetImage(Player color, PieceType type)
        {
            return color switch
            {
                Player.White => whiteSources[type],
                Player.Black => blackSources[type],
                _ => null
            };
        }
        public static ImageSource GetImage(Piece piece)
        {
            if (piece == null)
            {
                return null;
            }
            return GetImage(piece.Color, piece.Type);
        }
    }
}
