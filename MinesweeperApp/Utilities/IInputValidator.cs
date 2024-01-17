using System;
using MinesweeperApp.Models;

namespace MinesweeperApp.Utilities
{
	public interface IInputValidator
	{
        bool ValidatePositiveNumber(string input, out int num);
        bool ValidateSize(int size);
		bool ValidateMineCount(int count, int size);
		bool ValidateCell(string input, int size, out Location cell);
        bool ValidateHiddenCellValue(int cellValue);

    }
}

