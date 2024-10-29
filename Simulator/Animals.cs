using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public class Animals
    {
        private string description="Unknown";
        public required string Description
        {
            get
            {
                return description;
            }
            init
            {
                if (value == null) { return; }
                string temp_name = value.Trim();
                if (temp_name.Length > 0)
                {
                    if (temp_name.Length > 15)
                    {
                        temp_name = temp_name.Substring(0, 15);
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
                description = temp_name;
            }
        }
        public uint Size { get; set; } = 3;
        public string Info
        {
            get { return $"{Description} <{Size}>"; }
        }
    }
}
