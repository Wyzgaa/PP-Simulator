using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public int size { get; }
        public SmallTorusMap(int Size) : base(Size, Size)
        {
            size = Size;
        }
        public override bool Exist(Point p)
        {
            if (p.X >= 0 && p.Y >= 0 && p.X <= SizeX - 1 && p.Y <= SizeY - 1)
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

    }
}
