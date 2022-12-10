namespace Challenges;

public abstract class Day<TOut>
{
    protected readonly string? Part1Content;
    protected readonly string? Part2Content;

    protected Day(string? part1File = null, string? part2File = null)
    {
        const string challengesPath = "../../../../Inputs";

        if (part1File is not null)
            Part1Content = File.ReadAllText(Path.Combine(challengesPath, part1File));

        if (part2File is not null)
            Part2Content = File.ReadAllText(Path.Combine(challengesPath, part2File));
    }

    public abstract TOut Part1();
    public abstract TOut Part2();
}