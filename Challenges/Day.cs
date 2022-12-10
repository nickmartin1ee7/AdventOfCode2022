namespace Challenges;

public abstract class Day<TOut>
{
    protected readonly string Part1Content;
    protected readonly string Part2Content;

    protected Day(string part1File, string part2File)
    {
        Part1Content = File.ReadAllText(part1File);
        Part2Content = File.ReadAllText(part2File);
    }

    public abstract TOut Part1();
    public abstract TOut Part2();
}