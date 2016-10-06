using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ImmutableGameDecorator
    {
        private ImmutableGame startGame;
        private List<int> steps;

        public ImmutableGameDecorator(params int[] list)
        {
            steps = new List<int>();
            startGame = new ImmutableGame(list);
        }

        public List<int> GetSteps()
        {
            return steps;
        }

        public ImmutableGame GetStartGame()
        {
            return startGame;
        }

        private Game GetCurrentGame()
        {
            //Game currentGame = startGame;
            Game currentGame = new Game(startGame.GetStartCellsLocation());

            foreach (int step in steps)
                currentGame.Shift(step);

            return currentGame;
        }


        public Cell GetLocation(int value)
        {
            return GetCurrentGame().GetLocation(value);
        }

        public int this[int x, int y]
        {
            get
            {
                if (x >= 0 && x < startGame.SizeField && y >= 0 && y < startGame.SizeField)
                    return GetCurrentGame()[x, y];
                else
                    throw new ArgumentException("Выход за пределы поля");
            }
        }

        public ImmutableGameDecorator Shift(int value)
        {
            Game currentGame = GetCurrentGame();

            if (currentGame.IsCellsClose(currentGame.GetLocation(value), currentGame.GetLocation(0)))
                steps.Add(value);
            else
                throw new ArgumentException("Двигать клетку невозможно");

            return this;
        }
    }
}
