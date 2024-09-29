using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Position
    {
        public int Raw
        {
            get; 
        }
        public int Column
        {
            get;  
        }
        public  Position(int raw, int column)
        {
            Raw = raw;
            Column = column;
        }
        public Player Squarecolor()
        {
            if((Raw + Column) % 2 == 0)
            {
                return Player.White;
            }
            else
            {
                return Player.Black;
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Raw == position.Raw &&
                   Column == position.Column;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Raw, Column);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
        public static Position operator +(Position pos, Direction dir)
        {
            return new Position(pos.Raw + dir.Rawdelta, pos.Column + dir.Columndelta);
        }
    }
}
