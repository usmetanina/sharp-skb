using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Game
    {
        private int sizeField;
        private int[,] field;
        private Cell[] cellLocation;

        public Game(params int[] cells)
        {
            sizeField = CalculateSize(cells);
            if (IsUniqueAndCorrectCells(cells))
            {
                field = new int[sizeField, sizeField];
                cellLocation = new Cell[sizeField * sizeField];

                for (int i = 0; i < sizeField; i++)
                {
                    for (int j = 0; j < sizeField; j++)
                    {
                        int cell = cells[i * sizeField + j];
                        cellLocation[cell] = new Cell(i, j);
                        field[i, j] = cell;
                    }
                }
            }
        }

        private int CalculateSize(int[] cells)
        {
            if (IsCorrectFieldSize(cells))
            {
                return (int)Math.Sqrt(cells.Length);
            }
            else throw new ArgumentException("Некорректное количество ячеек");
        }

        private bool IsCorrectFieldSize(int[] cells)
        {
            double dimension = Math.Sqrt(cells.Length);
            if (dimension % (int)dimension == 0)
                return true;
            else
                return false;
        }

        private bool IsUniqueAndCorrectCells(int[] cells)
        {
            int countZero=0;
            for (int i = 0; i < cells.Length; i++)
            {
                if (cells[i] >= 0 && cells[i] < cells.Length)
                {
                    if (cells[i] == 0) countZero++;
                    int cell = cells[i];
                    for (int j = i + 1; j < cells.Length; j++)
                    {
                        if (cell == cells[j])
                            throw new ArgumentException("Не уникальные значения клеток");
                    }
                }
                else
                    throw new ArgumentException("Не корректные значения клеток");
            }
            if (countZero!=1) throw new ArgumentException("Нет пустой клетки");
            else return true;
        }

        public int this[int x, int y]
        {
            get {
                if (x >= 0 && x < sizeField && y >= 0 && y < sizeField)
                    return field[x, y];
                else throw new ArgumentException("Выход за пределы поля");
            }
        }

        public Cell GetLocation(int value)
        {
            return cellLocation[value];
        }

        public void Shift(int cell)
        {
            Cell currentCell = GetLocation(cell);

            if (IsMovementUp(currentCell) || (IsMovementDown(currentCell)) ||
                IsMovementLeft(currentCell) || IsMovementRight(currentCell))
            {
                
                field[cellLocation[0].X, cellLocation[0].Y] = cell;
                field[currentCell.X, currentCell.Y] = 0;

                cellLocation[cell]=GetLocation(0);
                cellLocation[0] = currentCell;
            }
            else throw new ArgumentException("Двигать клетку невозможно");
        }

        private bool IsMovementUp(Cell cell)
        {
            if (cell.X != 0)
            {
                if (field[cell.X - 1, cell.Y] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }

        private bool IsMovementDown(Cell cell)
        {
            if (cell.X != sizeField-1)
            {
                if (field[cell.X + 1, cell.Y] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }

        private bool IsMovementLeft(Cell cell)
        {
            if (cell.Y != 0)
            {
                if (field[cell.X, cell.Y-1] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }
        private bool IsMovementRight(Cell cell)
        {
            if (cell.Y != sizeField-1)
            {
                if (field[cell.X, cell.Y + 1] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 2, 3, 4, 5, 6, 7, 8, 0);
            game.Shift(8);
        }
    }
}
