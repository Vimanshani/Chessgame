using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public enum Player
    {
        None,
        White,
        Black
    }
    public static class Playerextension
    {
     public static Player Opponent(Player player)
        {
            switch (player)
            {
                case Player.Black: return  Player.White;
                case Player.White: return Player.Black;
                default: return Player.None;
            }
        }
    }
}
