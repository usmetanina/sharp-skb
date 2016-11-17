using System;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in Reader.ReadCsv1("airquality.csv"))
            {
                foreach (var item in line)
                    Console.WriteLine(item);
            }
        }
    }
}
