using System;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            /*foreach (var line in Reader.ReadCsv1("airquality.csv"))
            {
                foreach (var item in line)
                    Console.WriteLine(item);
            }*/

            foreach (var line in Reader.ReadCsv2<ClassFromFile>("airquality.csv"))
            {
                Console.WriteLine(line.Name);
            }
        }
    }
}
