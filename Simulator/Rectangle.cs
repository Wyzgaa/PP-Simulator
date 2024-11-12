﻿using System;
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
                throw new ArgumentException();
            if (x1 > x2)
            {
                X1 = x2;
                X2 = x1;
            }
            else
            {
                X1 = x1;
                X2 = x2;
            }
            if (y1 > y2)
            {
                Y1 = y2;
                Y2 = y1;
            }
            else
            {
                Y1 = y1;
                Y2 = y2;
            }
        }
        catch (ArgumentException)
        {
            Console.WriteLine("nie chcemy 'chudych' prostokątów");
        }
            
    }
    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }
    public bool Contains(Point point) 
    {
        if(point.X>=X1 && point.X<=X2 && point.Y>=Y1 && point.Y<=Y2)
            return true;
        else 
            return false;
    }
    public override string ToString() 
    {
        return ($"({X1},{Y1}):({X2},{Y2})");
    }

}
