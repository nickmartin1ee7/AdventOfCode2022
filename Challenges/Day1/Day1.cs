using BenchmarkDotNet.Attributes;

namespace Challenges.Day1;

[MemoryDiagnoser]
public class Day1 : Day<int>
{
    public Day1()
        : base("day1part1.txt", "day1part2.txt")
    {
    }

    [Benchmark]
    public override int Part1()
    {
        var p1Split = Part1Content.Split('\n');

        var maxElfCalories = 0;
        var elfTotalCalories = 0;

        for (var i = 0; i < p1Split.Length; i++)
            if (p1Split[i] == string.Empty) // New Elf
            {
                if (maxElfCalories < elfTotalCalories) // This last Elf had more calories
                    maxElfCalories = elfTotalCalories;

                elfTotalCalories = 0;
            }
            else // Count the Elf's calories
            {
                var calories = int.Parse(p1Split[i]);
                elfTotalCalories += calories;
            }

        return maxElfCalories;
    }

    [Benchmark]
    public override int Part2()
    {
        var p2Split = Part2Content.Split('\n');

        var sortedElfCalories = new SortedSet<int>();
        var elfTotalCalories = 0;

        for (var i = 0; i < p2Split.Length; i++)
            if (p2Split[i] == string.Empty) // New Elf
            {
                sortedElfCalories.Add(elfTotalCalories);
                elfTotalCalories = 0;
            }
            else // Count the Elf's calories
            {
                var calories = int.Parse(p2Split[i]);
                elfTotalCalories += calories;
            }

        return sortedElfCalories
            .Skip(sortedElfCalories.Count - 3)
            .Take(3)
            .Sum();
    }
}