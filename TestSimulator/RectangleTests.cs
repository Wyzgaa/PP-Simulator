using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(1,1,2,3)]
    [InlineData(2,3,1,1)]
    public void
        Constructor_InvalidData_ShouldThrowArgumentException
        (int x1, int x2, int y1, int y2)
    {
        Assert.Throws<ArgumentException>(() =>
             new Rectangle(x1,y1,x2,y2));
    }
    [Theory]
    [InlineData(1, 1, 1, 1, 5, 5, true)]
    [InlineData(3, 4, 1, 1, 5, 5, true)]
    [InlineData(5, 5, 1, 1, 5, 5, true)]
    [InlineData(1, 5, 1, 1, 5, 5, true)]
    [InlineData(0, 5, 1, 1, 5, 5, false)]
    [InlineData(1, 6, 1, 1, 5, 5, false)]
    [InlineData(110, 10, 1, 1, 5, 5, false)]
    public void
        Contains_ValidData_ShouldReturnCorrectBool(int pointX,int pointY, int x1, int y1, int x2, int y2, bool expected)
    {
        var point= new Point(pointX, pointY);
        var rectangle= new Rectangle(x1,y1,x2, y2);
        Assert.Equal(expected, rectangle.Contains(point));
    }

    [Fact]
    public void ToString_ShouldReturnCorrectString() 
    {
        int x1= 1, y1= 2, x2=5, y2=10;
        var rectangle= new Rectangle(x1,y1,x2,y2);
        Assert.Equal("(1,2):(5,10)", rectangle.ToString());
    }
}
