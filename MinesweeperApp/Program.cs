using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.Drawing;
using System;
using Microsoft.Extensions.DependencyInjection;
using MinesweeperApp.Models;
using MinesweeperApp.Services;
using MinesweeperApp.Utilities;

var serviceProvider = new ServiceCollection()
            .AddSingleton<IMinesweeperService, MinesweeperService>()
            .AddSingleton<IInputValidator, InputValidator>()
            .BuildServiceProvider();

var _minesweeperService = serviceProvider.GetService<IMinesweeperService>();
var _inputValidator = serviceProvider.GetService<IInputValidator>();

bool askSize = true;
bool askCount = true;
Grid grid = new Grid(0);
GameResult gameResult = GameResult.Continue;

Console.WriteLine("Welcome to Minesweeper!");

try
{
    while (true)
    {
        while (askSize)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the size of the grid (e.g. 4 for a 4x4 grid): ");

            int size;
            if (_inputValidator.ValidatePositiveNumber(Console.ReadLine(), out size) && _inputValidator.ValidateSize(size))
            {
                grid = new Grid(size);
                askSize = false;
            }
            else
            {
                Console.WriteLine("Enter a number from 3-26 only.");
            }

        }

        while (askCount)
        {
            Console.WriteLine();
            Console.WriteLine("Enter the number of mines to place on the grid (maximum is 35% of the total squares): ");

            int count;
            if (_inputValidator.ValidatePositiveNumber(Console.ReadLine(), out count))
            {
                if (_inputValidator.ValidateMineCount(count, grid.Size))
                {
                    askCount = false;

                    _minesweeperService.CreateMineField(grid);
                    _minesweeperService.AddMines(grid, count);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Number of mines exceeds maximum allowed.");
                }
            }
            else
            {
                Console.WriteLine("There must be at least 1 mine.");
            }
        }

        // Game Loop
        while (gameResult == GameResult.Continue)
        {
            Location loc = new Location();
            bool askCell = true;
            while (askCell)
            {
                Console.Write("Select a square to reveal (e.g. A1): ");

                if (_inputValidator.ValidateCell(Console.ReadLine(), grid.Size, out loc))
                {
                    if (_inputValidator.ValidateHiddenCellValue(grid[loc]))
                    {
                        askCell = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("This field is already uncovered.");
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid cell value.");
                }

                Console.WriteLine();
            }

            //Uncover the field by type
            if (grid[loc] == 9) //Mine
            {
                _minesweeperService.ShowAllFields(grid);
                gameResult = GameResult.Loss;
            }
            else if (grid[loc] >= 0) //0-8
            {
                Console.WriteLine("This square contains {0} adjacent {1}.", grid[loc], grid[loc] == 1 ? "mine" : "mines");
                _minesweeperService.UncoverField(grid, loc);
            }

            //Verification of a win
            if (gameResult == GameResult.Continue)
            {
                gameResult = GameResult.Win;
                foreach (int field in grid.MineField)
                {
                    if (field >= 0 && field != 9)
                    {
                        gameResult = GameResult.Continue;
                        break;
                    }
                }
            }
            Console.WriteLine();
            _minesweeperService.CreateMineField(grid);
            Console.WriteLine();
        }

        if (gameResult == GameResult.Loss)
        {
            Console.WriteLine("Oh no, you detonated a mine! Game over.");
        }
        else
        {
            Console.WriteLine("Congratulations, you have won the game!");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to play again...");
        Console.ReadLine();
        Console.Clear();
        gameResult = GameResult.Continue;
        askSize = true;
        askCount = true;
    }
}
catch(Exception ex)
{
    Console.WriteLine("An error occurred. Restart the game.");
}