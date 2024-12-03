using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals : IMappable
    {
        private string description="Unknown";
        public Map? Map { get; private set; }
        public Point Position { get; set; }
        public virtual char Symbol => 'A';
        public string Description
        {
            get
            {
                return description;
            }
            init
            {
                if (value == null) { return; }
                description = Validator.Shortener(value, 3, 15, '#');
            }
        }
        public uint Size { get; set; } = 3;
        public virtual string Info 
        {
            get { return $"{Description} <{Size}>"; }
        }

        public Animals(string description, uint size=3)
        {
            Description = description;
            Size = size;
        }

        public virtual void Go(Direction direction)
        {
            if (Map == null)
                throw new ArgumentNullException("Animal is not on the map");
            Point Temp = Map.Next(Position, direction);
            if (Temp.Equals(Position))
                return;
            Map.Move(this, Position, Temp);
            Position = Temp;
        }

        public virtual void PlaceOnMap(Map map, Point p)
        {
            Map = map;
            Position = p;
            map.Add(this, p);
        }

        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}
