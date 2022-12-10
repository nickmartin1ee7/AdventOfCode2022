using BenchmarkDotNet.Attributes;

namespace Challenges.Day2;

[MemoryDiagnoser]
public class Day2 : Day<int>
{
    public Day2()
        : base("day2part1.txt")
    {
    }

    [Benchmark]
    public override int Part1()
    {
        var split = Part1Content!.Split('\n');

        var totalScore = 0;

        for (var i = 0; i < split.Length; i++)
        {
            var p1Choice = split[i][0];
            totalScore += Game.Solve(p1Choice);
        }

        return totalScore;
    }

    [Benchmark]
    public override int Part2()
    {
        throw new NotImplementedException();
    }

    private static class Game
    {
        public static int Play(char player1, char player2)
        {
            throw new NotImplementedException();
        }

        public static int Solve(char player1)
        {
            return player1 switch
            {
                Player1.Rock => 8,
                Player1.Paper => 1,
                Player1.Scissors => 6,
                _ => 0
            };
        }
    }

    private static class Player1
    {
        public const char Rock = 'A';
        public const char Paper = 'B';
        public const char Scissors = 'C';
    }

    private static class Player2
    {
        public const char Rock = 'X';
        public const char Paper = 'Y';
        public const char Scissors = 'Z';
    }
}