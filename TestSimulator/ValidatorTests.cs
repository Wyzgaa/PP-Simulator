using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-1, 0, 10, 0)]
    [InlineData(11, 0, 10, 10)]
    [InlineData(10, 0, 10, 10)]
    [InlineData(0, 0, 10, 0)]
    public void Limiter_ShouldReturnExpectedValue(int value, int min, int max, int expected)
    {
        Assert.Equal(expected, Validator.Limiter(value, min, max));
    }

    [Theory]
    [InlineData("test", 3, 10, '-', "Test")]
    [InlineData("    test   test  ", 1, 15, '*', "Test   test")]
    [InlineData("test", 10, 15, '_', "Test______")]
    [InlineData("LongTestTest", 5, 10, '-', "LongTestTe")]
    [InlineData("      TestSpaces   ", 2, 10, '#', "TestSpaces")]
    [InlineData("ShortTest", 11, 10, '#', "ShortTest##")]
    [InlineData("a                   b", 5, 10, '#', "A####")]
    public void Shortener_ValidStringReturnsCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        Assert.Equal(expected, Validator.Shortener(value, min, max, placeholder));
    }

    [Fact]
    public void Shortener_EmptyStringFillWithPlaceholder()
    { 
        Assert.Equal("--", Validator.Shortener("", 2, 5, '-'));
    }

}
