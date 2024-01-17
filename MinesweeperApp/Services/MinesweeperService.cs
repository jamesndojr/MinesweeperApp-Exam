using System;
using MinesweeperApp.Models;

namespace MinesweeperApp.Services
{
    public class MinesweeperService : IMinesweeperService
    {
        public void CreateMineField(Grid grid)
        {
            Console.Write("    ");
            for (int j = 0; j < grid.ColumnLength; j++)
            {
                Console.Write("{0,2} ", j + 1);
            }
            Console.WriteLine();
            char c = 'A';
            for (int i = 0; i < grid.RowLength; i++)
            {
                Console.Write("{0,2}  ", c);
                for (int j = 0; j < grid.ColumnLength; j++)
                {
                    Location loc = new Location
                    {
                        Row = i,
                        Column = j
                    };
                    if (grid[loc] >= 0) //Covered field
                    {
                        Console.Write(" _ ");
                    }
                    else if (grid[loc] == -10) //Uncovered field
                    {
                        AddBackgroundColor('0', ConsoleColor.DarkGray);
                    }
                    else if (grid[loc] == -9) //Uncovered mine
                    {
                        AddBackgroundColor('X', ConsoleColor.Red);
                    }
                    else //Uncovered number
                    {
                        AddBackgroundColor((-grid[loc]).ToString()[0], ConsoleColor.DarkCyan);
                    }
                }
                Console.WriteLine();
                c++;
            }
        }

        public void AddMines(Grid grid, int count)
        {
            for (int k = 0; k < count; k++)
            {
                Location loc = new Location
                {
                    Row = Random.Shared.Next(grid.Size),
                    Column = Random.Shared.Next(grid.Size)
                };

                while (grid[loc] == 9)
                {
                    (loc.Row, loc.Column) = (Random.Shared.Next(grid.Size), Random.Shared.Next(grid.Size));
                }

                grid[loc] = 9;

                for (int i = Math.Max(loc.Row - 1, 0); i <= Math.Min(loc.Row + 1, grid.Size - 1); i++)
                {
                    for (int j = Math.Max(loc.Column - 1, 0); j <= Math.Min(loc.Column + 1, grid.Size - 1); j++)
                    {
                        Location newLoc = new Location
                        {
                            Row = i,
                            Column = j
                        };

                        if (grid[newLoc] != 9)
                        {
                            grid[newLoc]++;
                        }
                    }
                }
            }
        }


        public void UncoverField(Grid grid, Location loc)
        {
            if (loc.Row >= 0 && loc.Column >= 0 && loc.Row < grid.RowLength && loc.Column < grid.ColumnLength)
            {
                if (grid[loc] == 0)
                {
                    grid[loc] = -10;

                    //Uncover all nearby fields
                    for (int x = -1; x <= 1; x++)
                    {
                        for (int y = -1; y <= 1; y++)
                        {
                            UncoverField(grid, new Location { Row = loc.Row + x, Column = loc.Column + y });
                        }
                    }
                }
                else if (grid[loc] > 0 && grid[loc] < 9)
                {
                    grid[loc] *= -1;
                }
            }
        }

        public void ShowAllFields(Grid grid)
        {
            for (int j = 0; j < grid.Size; j++)
            {
                for (int i = 0; i < grid.Size; i++)
                {
                    Location newLoc = new Location
                    {
                        Row = i,
                        Column = j
                    };
                    if (grid[newLoc] >= 1 && grid[newLoc] <= 9)
                    {
                        grid[newLoc] *= -1;
                    }
                    else if (grid[newLoc] == 0)
                    {
                        grid[newLoc] = -10;
                    }
                }
            }
        }

        private void AddBackgroundColor(char letter, ConsoleColor color)
        {
            var originalColor = Console.BackgroundColor;
            Console.BackgroundColor = color;
            Console.Write(" {0} ", letter);
            Console.BackgroundColor = originalColor;
        }
    }
}

