using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public int SizeY { get; }
        public int SizeX { get; }
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
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
            int x = p.X, y = p.Y;
            var nextpoint = p.Next(d);
            if (Exist(nextpoint))
                return nextpoint;
            if (nextpoint.X >= SizeX)
                x = (SizeX-2);
            if(nextpoint.X < 0)
                x = (SizeX + 2);
            if (nextpoint.Y > SizeY)
                y = (SizeY -2);
            if (nextpoint.Y < 0)
                y = (SizeY + 2);
            Point result = new Point(x, y);
            return result;
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            int x = p.X, y = p.Y;
            var nextpoint = p.NextDiagonal(d);

            if (Exist(nextpoint))
                return nextpoint;

            switch (d)
            {
                case Direction.Up:
                    if (p.Y == SizeY - 1) y -= 1;
                    else y += 1;

                    if (p.X == 0) x += 1;
                    else x -= 1;
                    break;

                case Direction.Left:
                    if (p.Y == SizeY - 1) y -= 1;
                    else y += 1;

                    if (p.X == 0) x += 1;
                    else x -= 1;
                    break;

                case Direction.Right:
                    if (p.Y == 0) y += 1;
                    else y -= 1;

                    if (p.X == SizeX - 1) x -= 1;
                    else x += 1;
                    break;

                case Direction.Down:
                    if (p.Y == 0) y += 1;
                    else y -= 1;

                    if (p.X == 0) x += 1; 
                    else x -= 1;
                    break;

                default:
                    throw new InvalidDataException("Invalid Direction Value.");
            }

            return new Point(x, y);
        }

    }
}
