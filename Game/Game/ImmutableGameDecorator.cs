using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ImmutableGameDecorator:Game
    {
        private ImmutableGame startGame;
        private List<int> steps;

        public ImmutableGameDecorator(ImmutableGame startGame)
        {
            steps = new List<int>();
            this.startGame = startGame;
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
            Game currentGame = new Game(startGame.GetStartCellsLocation());

            foreach (int step in steps)
                currentGame.Shift(step);

            return currentGame;
        }


        public override Cell GetLocation(int value)
        {
            return GetCurrentGame().GetLocation(value);
        }

        public override int this[int x, int y]
        {
            get
            {
                if (x >= 0 && x < startGame.SizeField && y >= 0 && y < startGame.SizeField)
                    return GetCurrentGame()[x, y];
                else
                    throw new ArgumentException("Выход за пределы поля");
            }
        }

        public new ImmutableGameDecorator Shift(int value)
        {
            Game currentGame = GetCurrentGame();

            if (currentGame.IsCellsClose(currentGame.GetLocation(value), currentGame.GetLocation(0)))
            {
                ImmutableGameDecorator newGame = new ImmutableGameDecorator(startGame);

                foreach (int step in steps)
                    newGame.steps.Add(step);

                newGame.steps.Add(value);
                return newGame;
            }
            else
                throw new ArgumentException("Двигать клетку невозможно");
        }
    }
}
