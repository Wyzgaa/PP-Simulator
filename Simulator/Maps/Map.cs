using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;


public abstract class Map
{
    private readonly Rectangle _map;
    public virtual bool Exist(Point p) => _map.Contains(p);
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        _map = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    public abstract void Add(IMappable mappable, Point p);
    public abstract void Remove(IMappable mappable, Point p);
    public abstract void Move(IMappable mappable, Point startPosition, Point endPosition);
    public abstract List<IMappable> At(Point p);
    public int SizeX { get; }
    public int SizeY { get; }

    public abstract Point Next(Point p, Direction d);

    public abstract Point NextDiagonal(Point p, Direction d);
}
