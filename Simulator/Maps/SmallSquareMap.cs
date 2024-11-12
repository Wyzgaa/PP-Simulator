﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public int Size;

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
            throw new ArgumentOutOfRangeException("Niewłaściwy rozmiar mapy");
        Size = size;
    }
    public override bool Exist(Point p)
    {
        if(p.X>=0 && p.Y>=0 && p.X<=Size-1 && p.Y <= Size - 1)
            return true;
        return false;
    }

    public override Point Next(Point p, Direction d)
    {
        if(Exist(p.Next(d)))
            return p.Next(d);
        return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if(Exist(p.NextDiagonal(d)))
            return p.NextDiagonal(d);
        return p;
    }
}
