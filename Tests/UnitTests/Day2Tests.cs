using Challenges;
using Challenges.Day2;
using NUnit.Framework;

namespace Tests.UnitTests;

public class Day2Tests
{
    private Day<int>? _day;

    [SetUp]
    public void Setup()
    {
        _day = new Day2();
    }

    [Test]
    public void Part1()
    {
        var result = _day!.Part1();
        Assert.AreEqual(-1, result);
    }

    [Test]
    public void Part2()
    {
        var result = _day!.Part2();
        Assert.AreEqual(-1, result);
    }
}