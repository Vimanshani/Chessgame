using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Direction
    {
        public readonly static Direction North = new Direction(-1, 0);
        public readonly static Direction South = new Direction(1, 0);
        public readonly static Direction East = new Direction(0, 1);
        public readonly static Direction West = new Direction(0, -1);
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;
        public readonly static Direction SouthEast = South + East;
        public readonly static Direction SouthWest = South + West;

        public int Rawdelta
        {
            get;
        }
        public int Columndelta
        {
            get;
        }
        public Direction(int rawdelta, int columndelta)
        {
           Rawdelta = rawdelta;
           Columndelta = columndelta;
        }
        public static Direction operator +(Direction a, Direction b) 
        {
            return new Direction(a.Rawdelta + b.Rawdelta, a.Columndelta + b.Columndelta);
        }
        public static Direction operator *(int scalar, Direction dir)
        {
            return new Direction(scalar * dir.Rawdelta, scalar * dir.Columndelta);
        }
    }
}
