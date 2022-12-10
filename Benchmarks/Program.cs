using BenchmarkDotNet.Running;
using Challenges;

BenchmarkSwitcher
    .FromAssembly(typeof(Day<int>).Assembly)
    .Run(args);