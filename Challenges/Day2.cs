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

        var guideScore = 0;
        var winScore = 0;
        var actualScore = 0;

        for (var i = 0; i < split.Length; i++)
        {
            var p1Choice = split[i].FirstOrDefault();

            var p2Choice = Game.UseStrategyGuide(p1Choice);
            guideScore += Game.Play(p1Choice, p2Choice);

            // p2Choice = Game.UseWinningStrategy(p1Choice);
            // winScore += Game.Play(p1Choice, p2Choice);
            //
            // p2Choice = split[i].LastOrDefault();
            // actualScore += Game.Play(p1Choice, p2Choice);
        }

        return guideScore;
    }

    [Benchmark]
    public override int Part2()
    {
        throw new NotImplementedException();
    }

    private static class Game
    {
        public static char UseWinningStrategy(char player1)
        {
            return player1 switch
            {
                Player1.Rock => Player2.Paper,
                Player1.Paper => Player2.Scissors,
                Player1.Scissors => Player2.Rock,
                _ => default
            };
        }

        public static char UseStrategyGuide(char player1)
        {
            return player1 switch
            {
                Player1.Rock => Player2.Paper,
                Player1.Paper => Player2.Rock,
                Player1.Scissors => Player2.Scissors,
                _ => default
            };
        }

        public static int Play(char player1, char player2)
        {
            const int loss = 0;
            const int tie = 3;
            const int win = 6;

            const int rock = 1;
            const int paper = 2;
            const int scissors = 3;

            return (player1, player2) switch
            {
                // Loss
                (Player1.Paper, Player2.Rock) => rock + loss,
                (Player1.Scissors, Player2.Paper) => paper + loss,
                (Player1.Rock, Player2.Scissors) => scissors + loss,

                // Tie
                (Player1.Rock, Player1.Rock) => rock + tie,
                (Player1.Paper, Player2.Paper) => paper + tie,
                (Player1.Scissors, Player2.Scissors) => scissors + tie,

                // Win
                (Player1.Scissors, Player2.Rock) => rock + win,
                (Player1.Rock, Player2.Paper) => paper + win,
                (Player1.Paper, Player2.Scissors) => scissors + win,

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