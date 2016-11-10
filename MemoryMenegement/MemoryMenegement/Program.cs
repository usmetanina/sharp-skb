using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryMenegement
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            using (timer.Start())
            {
                Thread.Sleep(150);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);

            var value = 678+789;
            Console.WriteLine("тянем время");

            using (timer.Continue())
            {
                Thread.Sleep(250);
            }
            Console.WriteLine(timer.ElapsedMilliseconds);
        }
    }
}
