using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Creature
    {
        private string? name;
        private int level;
        public string? Name
        {
            get
            {
                return name;
            }
            set { name = value; }
        }
        public int Level
        {
            get => level;
            init
            {
                if (value < 0)
                {
                    level = 1;
                }
                else
                {
                    level = value;
                }
            }
        }
        public Creature() { }

        public Creature(string name, int level)
        {
            Name=name;
            Level = level;
        }
        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
        public string Info
        {
            get { return $"{Name} [{Level}]"; }
        }

    }
}

