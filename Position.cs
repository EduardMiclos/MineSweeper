using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Position
    {
        public int x, y;

        public Position()
        {
            this.x = -1;
            this.y = -1;
        }
        public Position(int _x, int _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public static bool operator == (Position p1, Object p2)
        {
            return p1.x == ((Position)p2).x && p1.y == ((Position)p2).y;
        }

        public static bool operator !=(Position p1, Object p2)
        {
            if(p1 == null || p2 == null)
            {
                return true;
            }
            return p1.x != ((Position)p2).x || p1.y != ((Position)p2).y;
        }

        public override bool Equals(Object p)
        {
            return this == (Position)p;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
