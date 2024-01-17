using System;
namespace MinesweeperApp.Models
{
	public class Grid
    {
        private readonly int[,] _mineField;
        private readonly int _size;

        public Grid(int size)
        {
            _size = size;
            _mineField = new int[size, size];
        }

        public int this[Location location]
        {
            get { return _mineField[location.Row, location.Column]; }
            set { _mineField[location.Row, location.Column] = value; }
        }

        public int Size
        {
            get { return _size; }
        }

        public int[,] MineField
        {
            get { return _mineField; }
        }

        public int RowLength
        {
            get { return _mineField.GetLength(0); }
        }

        public int ColumnLength
        {
            get { return _mineField.GetLength(1); }
        }
    }
}

