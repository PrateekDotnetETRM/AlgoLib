using AlgoLib.Core.Problems.Arrays;
using FluentAssertions;
using Xunit;

namespace AlgoLib.Tests.Problems.Arrays
{
    public class SudokuTests
    {
        private readonly Sudoku _sudoku = new Sudoku();

        // Valid Sudoku board
        private readonly char[][] validBoard = new char[][]
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

        // Invalid Sudoku board (duplicate in row)
        private readonly char[][] invalidRowBoard = new char[][]
        {
        new[] {'5','3','.','.','7','.','.','.','.'},
        new[] {'6','.','.','1','9','5','.','.','.'},
        new[] {'.','9','8','.','.','.','.','6','.'},
        new[] {'8','.','.','.','6','.','.','.','3'},
        new[] {'4','.','.','8','.','3','.','.','1'},
        new[] {'7','.','.','.','2','.','.','.','6'},
        new[] {'.','6','.','.','.','.','2','8','.'},
        new[] {'.','.','.','4','1','9','.','.','5'},
        new[] {'5','.','.','.','8','.','.','7','9'} // Duplicate '5' in row 0
        };

        [Fact]
        public void IsValidSudokuThreeDict_ShouldReturnTrue_ForValidBoard()
        {
            var result = _sudoku.IsValidSudokuThreeDict(validBoard);
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidSudokuThreeDict_ShouldReturnFalse_ForInvalidRowBoard()
        {
            var result = _sudoku.IsValidSudokuThreeDict(invalidRowBoard);
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidSudokuSingleHSet_ShouldReturnTrue_ForValidBoard()
        {
            var result = _sudoku.IsValidSudokuSingleHSet(validBoard);
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidSudokuSingleHSet_ShouldReturnFalse_ForInvalidRowBoard()
        {
            var result = _sudoku.IsValidSudokuSingleHSet(invalidRowBoard);
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidSudokuBitManupulation_ShouldReturnTrue_ForValidBoard()
        {
            var result = _sudoku.IsValidSudokuBitManupulation(validBoard);
          
            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidSudokuBitManupulation_ShouldReturnFalse_ForInvalidRowBoard()
        {
            var result = _sudoku.IsValidSudokuBitManupulation(invalidRowBoard);
            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidSudoku_ShouldHandleEmptyBoard()
        {
            var emptyBoard = new char[9][];
            for (int i = 0; i < 9; i++) emptyBoard[i] = new char[9] { '.', '.', '.', '.', '.', '.', '.', '.', '.' };

            _sudoku.IsValidSudokuThreeDict(emptyBoard).Should().BeTrue();
            _sudoku.IsValidSudokuSingleHSet(emptyBoard).Should().BeTrue();
            _sudoku.IsValidSudokuBitManupulation(emptyBoard).Should().BeTrue();
        }
    }

}
