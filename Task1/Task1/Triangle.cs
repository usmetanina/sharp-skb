using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculation;

namespace WorkWithTriangle
{
    class Triangle
    {
        private double[] sides;

        public Triangle(double sideA, double sideB, double sideC)
        {
            sides = CalculationTriangleParameters.CalculationSide(sideA, sideB, sideC);
        }

        public Triangle(double firstSide, double secondSide, string angle)
        {
            sides = CalculationTriangleParameters.CalculationSide(firstSide, secondSide, angle);
        }

        public Triangle(string firstAngle, string secondAngle, double side)
        {
            sides = CalculationTriangleParameters.CalculationSide(firstAngle, secondAngle, side);
        }

        public double GetArea()
        {
            return CalculationTriangleParameters.CalculationArea(sides);
        }
    }
}
