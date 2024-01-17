using System;
using System.Drawing;
using MinesweeperApp.Models;

namespace MinesweeperApp.Utilities
{
	public class InputValidator : IInputValidator
    {
        public bool ValidatePositiveNumber(string input, out int num)
        {
            int.TryParse(input, out num);
            if (num > 0)
            {
                return true;
            }

            return false;
        }
        public bool ValidateSize(int size)
        {
            if  (size >= 3 && size <= 26)
            {
                return true;
            }

            return false;
        }

        public bool ValidateMineCount(int count, int size)
        {
            if (count <= ((size * size) * 0.35))
            {
                return true;
            }

            return false;
        }

        public bool ValidateCell(string input, int size, out Location cell)
        {
            cell = new Location();
            if (!string.IsNullOrWhiteSpace(input))
            {
                char letter = char.Parse(input.Substring(0, 1));
                int num;
                int.TryParse(input.AsSpan(1), out num);

                cell.Row = char.ToUpper(letter) - 'A';
                cell.Column = num - 1;

                if ((Char.IsLetter(letter) && cell.Row < size) && (num > 0 && num <= size))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateHiddenCellValue(int cellValue)
        {
            if (cellValue >= 0)
            {
                return true;
            }

            return false;
        }
    }
}

