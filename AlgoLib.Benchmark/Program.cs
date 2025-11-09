// See https://aka.ms/new-console-template for more information
using AlgoLib.Benchmark.Problems.Arrays;
using BenchmarkDotNet.Running;

Console.WriteLine("Ruuning Benchmark . . .");




BenchmarkRunner.Run<SortArrayBenchmarks>();
