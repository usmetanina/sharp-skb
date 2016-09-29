using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WorkWithTriangle.Tests
{
    [TestClass]
    public class TriangleTest
    {

        [TestMethod]
        public void Triangle_CreateTriangleWithExistingSidesMustReturnArea()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;

            Triangle triangle = Triangle.CreateTriangleUsingThreeSides(sideA, sideB, sideC);
            Assert.AreEqual(6, triangle.GetArea());
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Треугольник с такими длинами сторон не существует!\n")]
        public void Triangle_TryCreateImpossibleTriangleWithNonExistingSidesMustThrowException()
        {
            double sideA = 1;
            double sideB = 2;
            double sideC = 5;

            Triangle triangle=Triangle.CreateTriangleUsingThreeSides(sideA, sideB, sideC);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Треугольник с такими длинами сторон не существует!\n")]
        public void Triangle_TryCreateImpossibleTriangleWithZeroSideMustThrowException()
        {
            double sideA = 0;
            double sideB = 1;
            double sideC = 2;

            Triangle triangle = Triangle.CreateTriangleUsingThreeSides(sideA, sideB, sideC);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Некорректно задан угол\n")]
        public void Triangle_TryCreateImpossibleTriangleWithZeroAngleMustThrowException()
        {
            double firstAngle = 0;
            double secondAngle = 30;
            double side = 5;

            Triangle triangle = Triangle.CreateTriangleUsingTwoAnglesAndOneSide(firstAngle, secondAngle, side);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Некорректно задан угол\n")]
        public void Triangle_TryCreateImpossibleTriangleWithBigSummaTwoAngleseMustThrowException()
        {
            double firstAngle = 110;
            double secondAngle = 78;
            double side = 5;

            Triangle triangle = Triangle.CreateTriangleUsingTwoAnglesAndOneSide(firstAngle, secondAngle, side);
        }

        [TestMethod]
        public void Triangle_CreateTriangleWithExistingSideAndExistingTwoAngleseMustReturnArea()
        {
            double firstAngle = 45;
            double secondAngle = 45;
            double side = 10;

            Triangle triangle = Triangle.CreateTriangleUsingTwoAnglesAndOneSide(firstAngle, secondAngle, side);
            Assert.AreEqual(25, triangle.GetArea(),1e-5);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "Некорректно задан угол\n")]
        public void Triangle_TryCreateImpossibleTriangleWithBigAngleMustThrowException()
        {
            double firstSide = 2;
            double secondSide = 3;
            double angle = 195;

            Triangle triangle = Triangle.CreateTriangleUsingTwoSidesAndOneAngle(firstSide, secondSide, angle);
        }
    }
}