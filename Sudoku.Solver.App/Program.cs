using System;

namespace Sudoku.Solver.App
{
    class Program
    {
        private static int[,] board = new int[9, 9];

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Execute Tests (Y/N)?");

                var runTestResponse = Console.ReadLine();

                switch (runTestResponse.ToLower())
                {
                    case "y":
                        ExecuteTests();
                        break;
                    case "n":
                        ExecuteLive();
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadLine();               
            }
        }

        /// <summary>
        /// Execute Tests
        /// </summary>
        private static void ExecuteTests()
        {
            TestExecutor.ExecuteTests();
        }

        /// <summary>
        /// Execute Live Board
        /// </summary>
        private static void ExecuteLive()
        {
            Console.WriteLine("Enter each line of the board as prompted.\nEnter a value for each square separated by a comma, using 0 for empty squares");

            for (int line = 0; line < 9; line++)
            {
                Console.WriteLine($"Please enter line ({line + 1}) of the board:");

                var currentUserLine = Array.ConvertAll(Console.ReadLine().Split(','), p => p.Trim());

                for (int column = 0; column < 9; column++)
                {
                    board[line, column] = Convert.ToInt32(currentUserLine[column]);
                }
            }

            if (SudokuValidator.Validate(board))
            {
                if (SudokuSolver.Solve(board, 0, 0))
                    SudokuSolver.Print(board);
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unable to solve");
                    Console.ResetColor();
                }                    
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Invalid Board");
                Console.ResetColor();
            }
        }
    }
}
