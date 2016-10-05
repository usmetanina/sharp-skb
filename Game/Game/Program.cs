using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            ImmutableGame game = new ImmutableGame(1, 2, 3, 4, 5, 6, 7, 8, 0);
            game.Shift(8);
        }
    }
}
