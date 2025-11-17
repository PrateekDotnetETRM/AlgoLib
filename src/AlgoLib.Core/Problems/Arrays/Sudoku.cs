using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoLib.Core.Problems.Arrays
{
    public class Sudoku
    {
        public bool IsValidSudokuThreeDict(char[][] board)
        {

            Dictionary<int, HashSet<char>> rows = new Dictionary<int, HashSet<char>>();
            Dictionary<int, HashSet<char>> cols = new Dictionary<int, HashSet<char>>();
            Dictionary<int, HashSet<char>> sqrs = new Dictionary<int, HashSet<char>>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    char cell = board[i][j];
                    if (cell == '.') continue;

                    var sqrnum = (i / 3) * 3 + (j / 3);



                    if (!rows.ContainsKey(i)) rows[i] = new HashSet<char>();
                    if (!cols.ContainsKey(j)) cols[j] = new HashSet<char>();
                    if (!sqrs.ContainsKey(sqrnum)) sqrs[sqrnum] = new HashSet<char>();

                    if (!rows[i].Add(cell)) return false;
                    if (!cols[j].Add(cell)) return false;
                    if (!sqrs[sqrnum].Add(cell)) return false;

                }
            }
            return true;
        }

        public bool IsValidSudokuSingleHSet(char[][] board)
        {

            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    char cell = board[i][j];
                    if (cell == '.') continue;

                    var sqrnum = (i / 3) * 3 + (j / 3);

                    var rowKey = $"r{i}{cell}";
                    var colKey = $"c{j}{cell}";
                    var sqrKey = $"s{sqrnum}{cell}";

                    if (!seen.Add(rowKey) || !seen.Add(colKey) || !seen.Add(sqrKey))
                        return false;

                }
            }
            return true;
        }

        public bool IsValidSudokuBitManupulation(char[][] board)
        {
            int[] rows = new int[9];
            int[] cols = new int[9];
            int[] boxes = new int[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    char cell = board[i][j];
                    if (cell == '.') continue;

                    int digit = cell - '0'; 
                    int mask = 1 << (digit - 1);
                    int boxIndex = (i / 3) * 3 + (j / 3);

                    if ((rows[i] & mask) != 0 || (cols[j] & mask) != 0 || (boxes[boxIndex] & mask) != 0)
                        return false;

                    rows[i] |= mask;
                    cols[j] |= mask;
                    boxes[boxIndex] |= mask;
                }
            }
            return true;
        }
    }
}
