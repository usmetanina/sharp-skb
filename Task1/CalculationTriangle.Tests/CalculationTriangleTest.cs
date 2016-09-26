using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculation;

namespace CalculationTriangle.Tests
{
    [TestClass]
    public class CalculationTriangleTest
    {
        void TestSides(double sideA, double sideB, double sideC, params double[] expectedResult)
        {
            double[] result = CalculationTriangleParameters.CalculationSide(sideA, sideB, sideC);
            CheckResult(expectedResult,result);
        }

        void CheckResult(double[] expectedResult, double[] result)
        {
            Assert.AreEqual(expectedResult.Length, result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i],1e-2);
            }
        }

        void TestSides(string firstAngle, string secondAngle, double side, params double[] expectedResult)
        {
            double[] result = CalculationTriangleParameters.CalculationSide(firstAngle, secondAngle, side);
            CheckResult(expectedResult, result);
        }

        void TestSides(double sideA, double sideB, string angle, params double[] expectedResult)
        {
            double[] result = CalculationTriangleParameters.CalculationSide(sideA, sideB, angle);
            CheckResult(expectedResult, result);
        }

        [TestMethod]
        public void PositiveExistingSide()
        {
            TestSides(3, 3, 3.5, 3, 3, 3.5);
        }

        [TestMethod]
        public void PositiveNonExistingSide()
        {
            TestSides(1, 2, 5);
        }

        [TestMethod]
        public void NegativeSide()
        {
            TestSides(1, -2, 5);
        }
        [TestMethod]
        public void ZeroSide()
        {
            TestSides(0, 3, 5);
        }

        [TestMethod]
        public void ZeroAngleSin()
        {
            TestSides("0", "30", 5);
        }

        [TestMethod]
        public void ExistingAngleSin()
        {
            TestSides("60", "60", 5, 5 , 5, 5);
        }

        [TestMethod]
        public void ExistingAngleCos()
        {
            TestSides(1, 5, "175", 1, 5, 6);
        }

        [TestMethod]
        public void NonExistingAngleCos()
        {
            TestSides(1, 5, "195");
        }

        void TestArea(double[] sides, double expectedResult)
        {
            double resultArea = CalculationTriangleParameters.CalculationArea(sides);
            Assert.AreEqual(expectedResult, resultArea);
        }

        [TestMethod]
        public void NonExistingArea()
        {
            TestArea(new double[0], 0);
        }
        
        [TestMethod]
        public void NonExistingTriangleArea()
        {
            TestArea(new double[] { 1, 2, 5 }, 0);
        }

        [TestMethod]
        public void ExistingArea()
        {
           TestArea(new double[] {3, 4, 5}, 6);
        }
    }
}
