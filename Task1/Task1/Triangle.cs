using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithTriangle
{
    public class Triangle
    {
        private double sideA;
        private double sideB;
        private double sideC;
        private double area;

        public Triangle() { }

        private void SetSides(double sideA, double sideB, double sideC)             
        {
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public static Triangle CreateTriangleUsingThreeSides(double sideA, double sideB, double sideC)
        {
            Triangle triangle = new Triangle();
            if (IsCorrectSides(sideA, sideB, sideC))
            {
                triangle.SetSides(sideA, sideB, sideC);
                return triangle;
            }
            else
                throw new Exception("Треугольник с такими длинами сторон не существует!\n");
        }


        public static Triangle CreateTriangleUsingTwoSidesAndOneAngle(double firstSide, double secondSide, double angle)
        {
            Triangle triangle = new Triangle();

            double thirdSide = CalculateSideUsingTwoSidesAndOneAngle(firstSide,secondSide,angle);
            if (IsCorrectSides(firstSide, secondSide, thirdSide))
            {
                triangle.SetSides(firstSide, secondSide, thirdSide);
                return triangle;
            }
            else
                throw new Exception("Треугольник с такими длинами сторон не существует!\n");
        }

        public static Triangle CreateTriangleUsingTwoAnglesAndOneSide(double firstAngle, double secondAngle, double side)
        {
            Triangle triangle = new Triangle();

            double firstSide = CalculateSideUsingTwoAnglesAndOneSide(firstAngle, secondAngle, side);
            double secondSide = CalculateSideUsingTwoAnglesAndOneSide(secondAngle, firstAngle, side);
            if (IsCorrectSides(firstSide, secondSide, side))
            {
                triangle.SetSides(firstSide, secondSide, side);
                return triangle;
            }
            else
                throw new Exception("Треугольник с такими длинами сторон не существует!\n");
        }

        public void CalculateTriangleArea()
        {
            if (IsCorrectSides(sideA, sideB, sideC))
            {
                double semiperimeter = (sideA + sideB + sideC) / 2; //Герона
                this.area= Math.Sqrt(semiperimeter * (semiperimeter - sideA) * (semiperimeter - sideB) * (semiperimeter - sideC));
            }
            else
                throw new Exception("Треугольник с такими длинами сторон не существует!\n");
        }

        public double GetArea()
        {
            return area;
        }

        private static bool IsCorrectSides(double sideA, double sideB, double sideC)
        {
            if ((sideA < sideB + sideC) && (sideB < sideA + sideC) && (sideC < sideA + sideB) && sideA > 0 && sideB > 0 && sideC > 0)
                return true;
            else
                return false;
        }

        private static double CalculateSideUsingTwoSidesAndOneAngle(double firstSide, double secondSide, double angle)
        {
            if (angle < 180 && angle > 0)
            {
                double angleInRadians = angle * Math.PI / 180;
                double desiredSide = Math.Sqrt(firstSide * firstSide + secondSide * secondSide - 2 * firstSide * secondSide * Math.Cos(angleInRadians));//теорема косинусов
                return desiredSide;
            }
            else
                throw new Exception("Некорректно задан угол\n");
        }


        private static double CalculateSideUsingTwoAnglesAndOneSide(double firstAngle, double secondAngle, double side)
        {

            if (firstAngle < 180 && firstAngle > 0 && secondAngle < 180 && secondAngle > 0 && ((firstAngle+secondAngle)<180))
            {
                double firstAngleInRadians = firstAngle * Math.PI / 180;
                double secondAngleInRadians = secondAngle * Math.PI / 180;
                double desiredSide = side * Math.Sin(firstAngleInRadians) / Math.Sin((180 * Math.PI / 180) - secondAngleInRadians - firstAngleInRadians);//теорема синусов
                return desiredSide;
            }
            else
                throw new Exception("Некорректно задан угол\n");
        }
    }
}
