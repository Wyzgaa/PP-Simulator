using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Creature
    {
        private string? name = "Unknown";
        private int level=1;
        public string? Name
        {
            get
            {
                return name;
            }
            init
            {
                if (value == null) { return; }
                string temp_name = value.Trim();
                if(temp_name.Length>0)
                {
                    if (temp_name.Length > 25)
                    {
                        temp_name = temp_name.Substring(0, 25);
                        temp_name = temp_name.Trim();
                    }
                    temp_name = char.ToUpper(temp_name[0]) + temp_name.Substring(1);
                    if (temp_name.Length < 3)
                    {
                        temp_name = temp_name + string.Concat(Enumerable.Repeat("#", 3 - temp_name.Length));
                    }
                }
                if (temp_name == "")
                    temp_name = "Unknown";
                name = temp_name;
            }
        }
        public int Level
        {
            get => level;
            init
            {
                if (value <= 0)
                {
                    level = 1;
                }
                else if (value > 10)
                {
                    level = 10;
                }
                else
                {
                    level = value;
                }
                
            }
        }
        public void Upgrade()
        {
            if(level <10)
            {
                level++;
            }
        }
        public Creature() { }

        public Creature(string name, int level=1)
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

