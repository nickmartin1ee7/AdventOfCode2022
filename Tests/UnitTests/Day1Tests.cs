using Challenges;
using Challenges.Day1;
using NUnit.Framework;

namespace Tests.UnitTests;

public class Day1Tests
{
    private Day<int> _day;

    [SetUp]
    public void Setup()
    {
        _day = new Day1();
    }

    [Test]
    public void Part1()
    {
        var result = _day.Part1();
        Assert.AreEqual(70116, result);
    }

    [Test]
    public void Part2()
    {
        var result = _day.Part2();
        Assert.AreEqual(206582, result);
    }
}