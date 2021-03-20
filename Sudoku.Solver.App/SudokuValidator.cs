using System;

namespace Sudoku.Solver.App
{
    public class SudokuValidator
    {
        /// <summary>
        /// Bounds of the board
        /// </summary>
        static int N = 9;


        /// <summary>
        /// Validate if all elements on the board to see if there in the bounds (N)
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool isinRange(int[,] board)
        {
            // iterate the board[,] array
            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < N; col++)
                {

                    // Check if board[row],col]
                    // lies in the range
                    // ** also ignore zeros as these need to be replaced with values
                    if (board[row, col] < 0 ||
                        board[row, col] > 9)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Validate Sudoku Board
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool Validate(int[,] board)
        {
            // Check if all elements of board[,]
            // stores value in the range[1, 9]
            if (isinRange(board) == false)
            {
                return false;
            }

            // Stores unique value
            // from 1 to N
            bool[] unique = new bool[N + 1];

            // Traverse each row of
            // the given array
            for (int row = 0; row < N; row++)
            {

                // Initiliaze unique[]
                // array to false
                Array.Fill(unique, false);

                // Traverse each column
                // of current row
                for (int col = 0; col < N; col++)
                {
                    // Stores the value
                    // of board[row, col]
                    int Z = board[row, col];
                    //ignore 0 values
                    if (Z != 0)
                    {
                        // Check if current row
                        // stores duplicate value
                        if (unique[Z])
                        {
                            return false;
                        }
                        unique[Z] = true;
                    }
                }
            }

            // Traverse each column of
            // the given array
            for (int col = 0; col < N; col++)
            {
                // Initiliaze unique[]
                // array to false
                Array.Fill(unique, false);

                // Traverse each row
                // of current column
                for (int row = 0; row < N; row++)
                {
                    // Stores the value
                    // of board[row, col]
                    int Z = board[row, col];
                    //ignore 0 values
                    if (Z != 0)
                    {
                        // Check if current column
                        // stores duplicate value
                        if (unique[Z])
                        {
                            return false;
                        }
                        unique[Z] = true;
                    }
                }
            }

            // iterate each block of
            // size 3 * 3 in board[,] array
            for (int i = 0; i < N - 2; i += 3)
            {
                // j stores first column of
                // each 3 * 3 block
                for (int j = 0; j < N - 2; j += 3)
                {

                    // Initiliaze unique[]
                    // array to false
                    Array.Fill(unique, false);

                    // iterate current block
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 3; l++)
                        {
                            // Stores row number
                            // of current block
                            int row = i + k;

                            // Stores column number
                            // of current block
                            int col = j + l;

                            // Stores the value
                            // of board[row,col]
                            int Z = board[row, col];
                            //ignore 0 values
                            if (Z != 0)
                            {
                                // Check if current block
                                // stores duplicate value
                                if (unique[Z])
                                {
                                    return false;
                                }
                                unique[Z] = true;
                            }
                        }
                    }
                }
            }

            // If all conditions satisfied
            return true;
        }


    }
}
