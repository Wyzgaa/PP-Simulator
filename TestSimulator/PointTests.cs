using Simulator;

namespace TestSimulator;
public class PointTests
{
    [Fact]
    public void ToString_ShouldReturnCorrectValue()
    {
        var point = new Point(1, 2);
        Assert.Equal("(1, 2)", point.ToString());
    }

    [Theory]
    [InlineData(10,10,Direction.Down,10,9)]
    [InlineData(10,10,Direction.Up,10,11)]
    [InlineData(10,10,Direction.Left,9,10)]
    [InlineData(10,10,Direction.Right,11,10)]
    public void Next_ShouldReturnCorrectValue(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point= new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(10, 10, Direction.Up, 11, 11)]
    [InlineData(10, 10, Direction.Right, 11, 9)]
    [InlineData(10, 10, Direction.Down, 9, 9)]
    [InlineData(10, 10, Direction.Left, 9, 11)]
  
    public void NextDiagonal_ShouldReturnCorrectValue(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        Point point = new Point(x, y);
        Point nextPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
