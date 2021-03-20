using System;
using System.Collections.Generic;

namespace Sudoku.Solver.App
{
    internal class TestExecutor
    {
        public static void ExecuteTests()
        {
            Console.WriteLine("Executing Tests\n=============================================");

            var factory = new TestDataFactory();

            var testsToRun = new List<int[,]>
              {
                factory.SolvableTest1,
                factory.SolvableTest2,
                factory.SolvableTest3,
                factory.NotSolvableTest1,
                factory.NotSolvableTest2,
                factory.InvalidBoardTest1,
                factory.InvalidBoardTest2
              };


            foreach (var testBoard in testsToRun)
            {
                Console.WriteLine($"============Start Test============");
                if (SudokuValidator.Validate(testBoard))
                {
                    if (SudokuSolver.Solve(testBoard, 0, 0))
                        SudokuSolver.Print(testBoard);
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
                Console.WriteLine($"============End Test============");
            }

        }
    }
}
