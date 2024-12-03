using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields;
    protected SmallMap(int SizeX, int SizeY) : base(SizeX, SizeY)
    {
        if (SizeX > 20)
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        if (SizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too high");

        _fields = new List<IMappable>[SizeX, SizeY];
    }
    public override void Add(IMappable mappable, Point p)
    {
        if(_fields[p.X, p.Y] == null)
            _fields[p.X, p.Y] = new List<IMappable>();
        _fields[p.X, p.Y]?.Add(mappable);
    }
    public override void Remove(IMappable mappable, Point p)
    {
        if (_fields[p.X, p.Y] != null && _fields[p.X, p.Y].Contains(mappable))
        {
            _fields[p.X, p.Y].Remove(mappable);
            if (_fields[p.X, p.Y].Count == 0)
            {
                _fields[p.X, p.Y] = null; 
            }
        }
    }
    public override void Move(IMappable mappable, Point startPosition, Point endPosition)
    {
        Remove(mappable, startPosition);
        Add(mappable, endPosition);
    }
    public override List<IMappable> At(Point p)
    {
        return _fields[p.X, p.Y];
    }
}
