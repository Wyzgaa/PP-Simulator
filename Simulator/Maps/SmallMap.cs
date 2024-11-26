using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;
    public SmallMap(int SizeX, int SizeY) : base(SizeX, SizeY)
    {
        if (SizeX > 20)
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        if (SizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too high");

        _fields = new List<Creature>[SizeX, SizeY];
    }
    public override void Add(Creature creature, Point p)
    {
        if(_fields[p.X, p.Y] == null)
            _fields[p.X, p.Y] = new List<Creature>();
        _fields[p.X, p.Y]?.Add(creature);
    }
    public override void Remove(Creature creature, Point p)
    {
        if (_fields[p.X, p.Y] != null && _fields[p.X, p.Y].Contains(creature))
        {
            _fields[p.X, p.Y].Remove(creature);
            if (_fields[p.X, p.Y].Count == 0)
            {
                _fields[p.X, p.Y] = null; 
            }
        }
    }
    public override void Move(Creature creature, Point startPosition, Point endPosition)
    {
        Remove(creature, startPosition);
        Add(creature, endPosition);
    }
    public override List<Creature> At(Point p)
    {
        return _fields[p.X, p.Y];
    }
}
