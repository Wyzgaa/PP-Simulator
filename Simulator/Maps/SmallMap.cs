using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public SmallMap(int SizeX, int SizeY) : base(SizeX, SizeY)
    {
        if (SizeX > 20)
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too wide");
        if (SizeY > 20)
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too high");
    }
}
