using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    /// <summary>
    /// You are given a 2D matrix matrix, handle multiple queries of the following type
    /// Calculate the sum of the elements of matrix inside the rectangle defined by its upper left corner(row1, col1) and lower right corner(row2, col2).
    /// </summary>
    public class SumMatrix
    {

        private int[][] _matrix; // keeping just for brute force

        private int[][] _prefix;
        public SumMatrix(int[][] matrix)

        {
            _matrix = matrix;

            // Pre-Building Prefix Sum (Range Sum) to make retrival faster 
            // if only one or two queries then just use brute force method 
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            _prefix = new int[rows + 1][];
            for (int i = 0; i <= rows; i++)
            {
                _prefix[i] = new int[cols + 1];
            }

            for (int i = 1; i <= rows; i++)
            {
                int prefix = 0;
                for (int j = 1; j <= cols; j++)
                {

                    prefix += matrix[i - 1][j - 1];
                    int above = _prefix[i - 1][j];
                    _prefix[i][j] = prefix + above;


                }
            }
        }
        public int SumRegionBetter(int row1, int col1, int row2, int col2)
        {

            return _prefix[row2 + 1][col2 + 1]
                    - _prefix[row1][col2 + 1]
                    - _prefix[row2 + 1][col1]
                    + _prefix[row1][col1];

        }
        public int SumRegionBruteForce(int row1, int col1, int row2, int col2)
        {
            int sum = 0;
            for (int i = row1; i <= row2; i++)
            {
                for (int j = col1; j <= col2; j++)
                {
                    sum += _matrix[i][j];
                }
            }
            return sum;
        }
    }
}
