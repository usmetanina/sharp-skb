using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{

    public class Cell
    {
        public readonly int X;
        public readonly int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Game
    {
        public int SizeField { get; private set; }
        public int[,] Field  { get; private set;}
        public Cell[] CellLocation { get; private set; }

        public Game(params int[] cells)
        {
            SizeField = CalculateSize(cells);
            if (IsUniqueAndCorrectCells(cells))
            {
                Field = new int[SizeField, SizeField];
                CellLocation = new Cell[SizeField * SizeField];

                for (int i = 0; i < SizeField; i++)
                {
                    for (int j = 0; j < SizeField; j++)
                    {
                        int cell = cells[i * SizeField + j];
                        CellLocation[cell] = new Cell(i, j);
                        Field[i, j] = cell;
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
            int countZero = 0;
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
            if (countZero != 1) throw new ArgumentException("Нет пустой клетки");
            else return true;
        }

        public int this[int x, int y]
        {
            get
            {
                if (x >= 0 && x < SizeField && y >= 0 && y < SizeField)
                    return Field[x, y];
                else throw new ArgumentException("Выход за пределы поля");
            }
        }

        public Cell GetLocation(int value)
        {
            return CellLocation[value];
        }

        public void Shift(int cell)
        {
            Cell currentCell = GetLocation(cell);

            if (IsCellsClose(currentCell, GetLocation(0)))
            {

                Field[CellLocation[0].X, CellLocation[0].Y] = cell;
                Field[currentCell.X, currentCell.Y] = 0;

                CellLocation[cell] = GetLocation(0);
                CellLocation[0] = currentCell;
            }
            else throw new ArgumentException("Двигать клетку невозможно");
        }

        protected bool IsCellsClose(Cell firsCell, Cell secondCell)
        {
            return ((firsCell.X == secondCell.X) && (Math.Abs(firsCell.Y - secondCell.Y) == 1))
                 || ((firsCell.Y == secondCell.Y) && (Math.Abs(firsCell.X - secondCell.X) == 1));
        }
    }
}
