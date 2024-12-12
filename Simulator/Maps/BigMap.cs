using System;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _fields;
    protected BigMap(int SizeX, int SizeY) : base(SizeX, SizeY)
    {
        if (SizeX > 1000)
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        if (SizeY > 1000)
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too high");
        _fields = new Dictionary<Point, List<IMappable>>();
    }
    public override void Add(IMappable mappable, Point p)
    {
        if (!_fields.ContainsKey(p))
        {
            _fields[p] = new List<IMappable>();
        }
        _fields[p].Add(mappable);
    }
    public override void Remove(IMappable mappable, Point p)
    {
        if (_fields.ContainsKey(p) && _fields[p].Contains(mappable))
        {
            _fields[p].Remove(mappable);
            if (_fields[p].Count == 0)
            {
                _fields.Remove(p); // Usuń klucz, jeśli lista jest pusta
            }
        }
    }
    public override void Move(IMappable mappable, Point startPosition, Point endPosition)
    {
        Remove(mappable, startPosition);
        Add(mappable, endPosition);
    }
    //public override List<IMappable> At(Point p)
    //{
    //    return _fields[p];
    //}
    public override List<IMappable> At(Point p)
    {
        return _fields.ContainsKey(p) ? _fields[p] : new List<IMappable>();
    }
}