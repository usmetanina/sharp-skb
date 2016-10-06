using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ImmutableGame:Game
    {
        public ImmutableGame(params int[] cells):base(cells)
        {
        }
        
        public new ImmutableGame Shift(int cell)
        {
            Cell currentCell = GetLocation(cell);

            if (IsCellsClose(currentCell, GetLocation(0)))
            {
                int[] newGame = GetStartCellsLocation();

                newGame[GetLocation(0).X * SizeField + GetLocation(0).Y] = cell;
                newGame[currentCell.X * SizeField + currentCell.Y] = 0;

                return new ImmutableGame(newGame);
            }
            else throw new ArgumentException("Двигать клетку невозможно");
        }

        public int[] GetStartCellsLocation()
        {
            int[] newGame = new int[CellLocation.Length];

            for (int i = 0; i < SizeField; i++)
            {
                for (int j = 0; j < SizeField; j++)
                {
                    newGame[i * SizeField + j] = Field[i, j];
                }
            }
            return newGame;
        }
    }
}
