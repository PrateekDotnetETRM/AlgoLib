// See https://aka.ms/new-console-template for more information
using AlgoLib.Benchmark.Problems.Strings;
using BenchmarkDotNet.Running;

Console.WriteLine("Ruuning Benchmark");



BenchmarkRunner.Run<ScoreBenchmarks>();
//BenchmarkRunner.Run<SortArrayBenchmarks>();
//BenchmarkRunner.Run<TopKFrequentBenchmark>();
//BenchmarkRunner.Run<SumMatrixBenchmark>();
//BenchmarkRunner.Run<ProductExceptSelfBenchmark>();