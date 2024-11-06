using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;


public class Rectangle
{
    public readonly int X1, Y1, X2, Y2;
    public Rectangle(int x1, int y1, int x2, int y2)
    {
       try
        {
            if (x1 == x2 || y1 == y2)
                throw new ArgumentException("Punkty współliniowe");
            x1 = X1;
            x2 = X2;
            y1 = Y1;
            y2 = Y2;
        }
        catch
        {

        }

        
    }
}
