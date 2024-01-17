using System;
using MinesweeperApp.Models;

namespace MinesweeperApp.Services
{
	public interface IMinesweeperService
	{
        void CreateMineField(Grid grid);
        void AddMines(Grid grid, int count);
        void UncoverField(Grid grid, Location loc);
        void ShowAllFields(Grid grid);
    }
}

