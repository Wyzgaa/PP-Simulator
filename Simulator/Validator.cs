using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public static class Validator
    {
        public static int Limiter(int value, int min, int max) 
        {
            if (value <= min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            else
            {
                return value;
            }
        }
        public static string Shortener(string value, int min, int max, char placeholder)
        {
            string temp_name = value.Trim();
            if (temp_name.Length > 0)
            {
                if (temp_name.Length > max)
                {
                    temp_name = temp_name.Substring(0, max);
                    temp_name = temp_name.Trim();
                }
                temp_name = char.ToUpper(temp_name[0]) + temp_name.Substring(1);
                if (temp_name.Length < min)
                {
                    temp_name = temp_name + string.Concat(Enumerable.Repeat(placeholder, min - temp_name.Length));
                }
            }
            if (temp_name == "")
                temp_name = string.Concat(Enumerable.Repeat(placeholder, min - temp_name.Length));
            return temp_name;
        }
    }
}
