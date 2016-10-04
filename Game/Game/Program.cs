using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Cell
    {
        public int x { get; set; }
        public int y { get; set; }

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public class Game
    {
        private int sizeField;
        private int[,] field;
        private Cell[] cellLocation;

        public Game(params int[] cells)
        {
            if (IsCorrectFieldSize(cells) && IsUniqueAndCorrectCells(cells))
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

        private bool IsCorrectFieldSize(int[] cells)
        {
            double dimension = Math.Sqrt(cells.Length);
            if (int.TryParse(dimension.ToString(), out sizeField))
                return true;
            else
                throw new ArgumentException("Некорректное количество ячеек");
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
            get { return field[x, y]; }
        }

        public Cell GetLocation(int value)
        {
            return cellLocation[value];
        }

        public void Shift(int cell)
        {
            Cell currentCell = GetLocation(cell);

            if (IsMovementUp(currentCell))
            {
                field[currentCell.x, currentCell.y] = 0;
                field[cellLocation[0].x, cellLocation[0].y] = cell;

                cellLocation[cell].x--;
                cellLocation[0].x++;
            }
            else if (IsMovementDown(currentCell))
            {
                field[currentCell.x, currentCell.y] = 0;
                field[cellLocation[0].x, cellLocation[0].y] = cell;

                cellLocation[cell].x++;
                cellLocation[0].x--;
            }
            else if (IsMovementRight(currentCell))
            {
                field[currentCell.x, currentCell.y] = 0;
                field[cellLocation[0].x, cellLocation[0].y] = cell;

                cellLocation[cell].y++;
                cellLocation[0].y--;
            }
            else if (IsMovementLeft(currentCell))
            {
                field[currentCell.x, currentCell.y] = 0;
                field[cellLocation[0].x, cellLocation[0].y] = cell;

                cellLocation[cell].y--;
                cellLocation[0].y++;
            }
            else throw new ArgumentException("Двигать клетку невозможно");
        }

        private bool IsMovementUp(Cell cell)
        {
            if (cell.x != 0)
            {
                if (field[cell.x - 1, cell.y] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }

        private bool IsMovementDown(Cell cell)
        {
            if (cell.x != sizeField-1)
            {
                if (field[cell.x + 1, cell.y] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }

        private bool IsMovementLeft(Cell cell)
        {
            if (cell.y != 0)
            {
                if (field[cell.x, cell.y-1] == 0)
                    return true;
                else return false;

            }
            else
                return false;
        }
        private bool IsMovementRight(Cell cell)
        {
            if (cell.y != sizeField-1)
            {
                if (field[cell.x, cell.y + 1] == 0)
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
