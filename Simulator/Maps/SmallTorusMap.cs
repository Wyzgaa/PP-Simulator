using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public int SizeY { get; }
        public int SizeX { get; }
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            SizeX = sizeX;
            SizeY = sizeY;
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
            if (nextpoint.X >= SizeX || nextpoint.X < 0)
                x = (nextpoint.X+SizeX)%SizeX;
            if (nextpoint.Y >= SizeY || nextpoint.Y < 0)
                y = (nextpoint.Y + SizeY) % SizeY;
            Point result = new Point(x, y);
            return result;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            int x = p.X, y = p.Y;
            var nextpoint = p.NextDiagonal(d);

            if (Exist(nextpoint))
                return nextpoint;
            if (nextpoint.X >= SizeX || nextpoint.X < 0)
                x = (nextpoint.X + SizeX) % SizeX;
            else x = nextpoint.X;
            if (nextpoint.Y >= SizeY || nextpoint.Y < 0)
                y = (nextpoint.Y + SizeY) % SizeY;
            else y = nextpoint.Y;
            Point result = new Point(x, y);
            return result;
        }

    }
}
