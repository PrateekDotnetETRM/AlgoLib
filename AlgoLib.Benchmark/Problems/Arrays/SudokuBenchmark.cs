using AlgoLib.Core.Problems.Arrays;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;


namespace AlgoLib.Benchmark.Problems.Arrays
{

    public class SudokuBenchmark
    {

        private readonly Sudoku _sudoku = new Sudoku();

        [ParamsSource(nameof(Boards))]
        public char[][] Board { get; set; }

        public IEnumerable<char[][]> Boards => new List<char[][]>
    {
        ValidBoard(),
        InvalidBoard(),
        FullValidBoard(),
        SemiFullBoard(),
        EmptyBoard()
    };

        [Benchmark]
        public bool ThreeDict() => _sudoku.IsValidSudokuThreeDict(Board);

        [Benchmark]
        public bool SingleHashSet() => _sudoku.IsValidSudokuSingleHSet(Board);

        [Benchmark]
        public bool BitManipulation() => _sudoku.IsValidSudokuBitManupulation(Board);

        // --- Helper Methods to Generate Boards ---
        private static char[][] ValidBoard() => new char[][]
        {
        new[] {'5','3','.','.','7','.','.','.','.'},
        new[] {'6','.','.','1','9','5','.','.','.'},
        new[] {'.','9','8','.','.','.','.','6','.'},
        new[] {'8','.','.','.','6','.','.','.','3'},
        new[] {'4','.','.','8','.','3','.','.','1'},
        new[] {'7','.','.','.','2','.','.','.','6'},
        new[] {'.','6','.','.','.','.','2','8','.'},
        new[] {'.','.','.','4','1','9','.','.','5'},
        new[] {'.','.','.','.','8','.','.','7','9'}
        };

        private static char[][] InvalidBoard() => new char[][]
        {
        new[] {'5','3','.','.','7','.','.','.','.'},
        new[] {'6','.','.','1','9','5','.','.','.'},
        new[] {'.','9','8','.','.','.','.','6','.'},
        new[] {'8','.','.','.','6','.','.','.','3'},
        new[] {'4','.','.','8','.','3','.','.','1'},
        new[] {'7','.','.','.','2','.','.','.','6'},
        new[] {'.','6','.','.','.','.','2','8','.'},
        new[] {'.','.','.','4','1','9','.','.','5'},
        new[] {'5','.','.','.','8','.','.','7','9'} // Duplicate '5'
        };

        private static char[][] FullValidBoard() => new char[][]
        {
        new[] {'5','3','4','6','7','8','9','1','2'},
        new[] {'6','7','2','1','9','5','3','4','8'},
        new[] {'1','9','8','3','4','2','5','6','7'},
        new[] {'8','5','9','7','6','1','4','2','3'},
        new[] {'4','2','6','8','5','3','7','9','1'},
        new[] {'7','1','3','9','2','4','8','5','6'},
        new[] {'9','6','1','5','3','7','2','8','4'},
        new[] {'2','8','7','4','1','9','6','3','5'},
        new[] {'3','4','5','2','8','6','1','7','9'}
        };

        private static char[][] SemiFullBoard() => new char[][]
        {
        new[] {'5','3','4','.','7','8','.','1','2'},
        new[] {'6','7','2','1','.','5','3','.','8'},
        new[] {'1','9','8','3','4','.','5','6','.'},
        new[] {'8','5','9','7','6','1','4','2','3'},
        new[] {'4','2','6','8','5','3','7','9','1'},
        new[] {'7','1','3','9','2','4','8','5','6'},
        new[] {'9','6','1','5','3','7','2','8','4'},
        new[] {'2','8','7','4','1','9','6','3','5'},
        new[] {'3','4','5','2','8','6','1','7','9'}
        };

        private static char[][] EmptyBoard()
        {
            var board = new char[9][];
            for (int i = 0; i < 9; i++)
                board[i] = new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };
            return board;
        }

    }

}
