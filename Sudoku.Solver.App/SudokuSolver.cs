using System;

namespace Sudoku.Solver.App
{
    public class SudokuSolver
    {
        /// <summary>
        /// Print Board
        /// </summary>
        /// <param name="board"></param>
        public static void Print(int[,] board)
        {
            Console.WriteLine("+-----+-----+-----+");

            for (int row = 1; row < 10; ++row)
            {
                for (int col = 1; col < 10; ++col)
                    Console.Write("|{0}", board[row - 1, col - 1]);

                Console.WriteLine("|");
                if (row % 3 == 0) Console.WriteLine("+-----+-----+-----+");
            }
        }

        /// <summary>
        /// Solve Board
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static bool Solve(int[,] board, int row, int col)
        {
            if (row < 9 && col < 9)
            {
                //check if current row, position already has a number
                if (board[row, col] != 0)
                {
                    //check if column position is still in bounds, then proceed to next column
                    if ((col + 1) < 9) return Solve(board, row, col + 1);
                    //check if row still in bounds, then proceed to next row
                    else if ((row + 1) < 9) return Solve(board, row + 1, 0);
                    //out of bounds of the row, end of board
                    else return true;
                }
                else
                {
                    //iterate possible numbers
                    for (int num = 0; num < 9; ++num)
                    {
                        if (IsNumberAvailableToUse(board, row, col, num + 1))
                        {
                            board[row, col] = num + 1;

                            if ((col + 1) < 9)
                            {
                                if (Solve(board, row, col + 1)) return true;
                                else board[row, col] = 0;
                            }
                            else if ((row + 1) < 9)
                            {
                                if (Solve(board, row + 1, 0)) return true;
                                else board[row, col] = 0;
                            }
                            else return true;
                        }
                    }
                }
                //unable to solve
                return false;
            }
            else return true;
        }

        /// <summary>
        /// Validate if number can used at current row, column, subgrid
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool IsNumberAvailableToUse(int[,] board, int row, int col, int num)
        {
            //work out start of sub grid
            int rowStart = (row / 3) * 3;
            int colStart = (col / 3) * 3;

            for (int i = 0; i < 9; ++i)
            {
                //check the row
                if (board[row, i] == num) return false;
                //check the column down
                if (board[i, col] == num) return false;
                //check the 3 by 3 sub grid
                if (board[rowStart + (i % 3), colStart + (i / 3)] == num) return false;
            }

            return true;
        }
    }
}
