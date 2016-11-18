using System;
using System.Linq;

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

            foreach (var line in Reader.ReadCsv2<ClassFromFile>("airquality.csv"))
            {
                Console.WriteLine(line.Name);
            }

           foreach (var line in Reader.ReadCsv3("airquality.csv"))
           {
               foreach (var item in line)
                   Console.WriteLine(item); 
           }

            var windValues = Reader.ReadCsv4("airquality.csv").Where(z => z.Ozone > 10).Select(z => z.Wind);
        }
    }
}
