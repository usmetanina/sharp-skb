using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Три стороны \n2. Две стороны и угол \n3. Два угла и сторона \nВсе величины могут быть дробными числами\nВаш выбор:");
            string choice = Console.ReadLine();
            Triangle triangle=null;

            if (Convert.ToInt32(choice) < 4 && Convert.ToInt32(choice) > 0)
            {
                if (choice.Equals("1")) triangle =  Triangle.CreateTriangleUsingThreeSides(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                if (choice.Equals("2")) triangle = Triangle.CreateTriangleUsingTwoSidesAndOneAngle(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));
                if (choice.Equals("3")) triangle = Triangle.CreateTriangleUsingTwoAnglesAndOneSide(Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()), Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine(triangle.GetArea());
            }
        }
    }
}
