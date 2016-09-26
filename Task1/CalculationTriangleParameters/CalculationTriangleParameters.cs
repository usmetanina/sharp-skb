using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class CalculationTriangleParameters
    {
        private static double[] CheckExistence(double sideA, double sideB, double sideC)
        {
            if ((sideA < sideB + sideC) && (sideB < sideA + sideC) && (sideC < sideA + sideB) && sideA>0 && sideB>0 && sideC>0)
                return new double[] { sideA, sideB, sideC };
            else
                return new double[0];
        }

        public static double[] CalculationSide(double firstSide, double secondSide, string angle)
        {
            double angleInRadians = Convert.ToDouble(angle) * Math.PI / 180;

            if (Convert.ToDouble(angle) < 180 && Convert.ToDouble(angle) > 0)
            {
                double desiredSide = Math.Sqrt(firstSide * firstSide + secondSide * secondSide - 2 * firstSide * secondSide * Math.Cos(angleInRadians));//теорема косинусов

                return CheckExistence(firstSide, secondSide, desiredSide);
            }
            else
                return new double[0];
        }

        public static double[] CalculationSide(double firstSide, double secondSide, double thirdSide)
        {
            return CheckExistence(firstSide, secondSide, thirdSide);
        }

        public static double[] CalculationSide(string firstAngle, string secondAngle, double thirdSide)
        {
            double firstAngleInRadians = Convert.ToDouble(firstAngle) * Math.PI / 180;
            double secondAngleInRadians = Convert.ToDouble(secondAngle) * Math.PI / 180;

            if (Convert.ToDouble(firstAngle) < 180 && Convert.ToDouble(firstAngle) > 0 && Convert.ToDouble(secondAngle) < 180 && Convert.ToDouble(secondAngle) > 0)
            {
                double firstSide = thirdSide * Math.Sin(firstAngleInRadians) / Math.Sin( (180*Math.PI/180) - secondAngleInRadians - firstAngleInRadians);//теорема синусов
                double secondSide = thirdSide * Math.Sin(secondAngleInRadians) / Math.Sin( (180 * Math.PI / 180) - secondAngleInRadians - firstAngleInRadians);//теорема синусов

                return CheckExistence(firstSide, secondSide, thirdSide);
            }
            else
                return new double[0];
        }

        public static double CalculationArea(double[] sides)
        {
            if ((sides.Length != 0)&&(CheckExistence(sides[0], sides[1], sides[2]).Length!=0))
            {
                double semiperimeter = (sides[0] + sides[1] + sides[2]) / 2; //Герона
                return Math.Sqrt(semiperimeter * (semiperimeter - sides[0]) * (semiperimeter - sides[1]) * (semiperimeter - sides[2]));
            }
            else
                return 0;
        }
    }
}
