using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        private int size;
        public int Size 
        {
            get { return size; }
        }
        public override bool Exist(Point p)
        {
            if (p.X >= 0 && p.Y >= 0 && p.X <= Size - 1 && p.Y <= Size - 1)
                return true;
            return false;
        }

        public override Point Next(Point p, Direction d)
        {
            int x=p.X, y=p.Y;
            var nextpoint = p.Next(d);
            if (Exist(nextpoint))
                return nextpoint;
            if (nextpoint.X >= size || nextpoint.X < 0)
                x = (nextpoint.X+size)%size;
            if (nextpoint.Y >= size || nextpoint.Y < 0)
                y = (nextpoint.Y + size) % size;
            Point result = new Point(x, y);
            return result;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            int x = p.X, y = p.Y;
            var nextpoint = p.NextDiagonal(d);

            if (Exist(nextpoint))
                return nextpoint;
            if (nextpoint.X >= size || nextpoint.X < 0)
                x = (nextpoint.X + size) % size;
            else x = nextpoint.X;
            if (nextpoint.Y >= size || nextpoint.Y < 0)
                y = (nextpoint.Y + size) % size;
            else y = nextpoint.Y;
            Point result = new Point(x, y);
            return result;
        }

        public SmallTorusMap(int MapSize) 
        {
            if(MapSize<5 || MapSize >20)
                throw new ArgumentOutOfRangeException("Rozmiar mapy musi zawierać się w przedziale [5,20]");
            size= MapSize;
        }
    }
}
