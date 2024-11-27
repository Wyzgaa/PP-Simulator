using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    //object Info { get; }
    //object Position { get; set; }

    void Go(Direction direction);
    void PlaceOnMap(Map map, Point point);
}
