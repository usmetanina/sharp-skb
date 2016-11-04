using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq.Expressions;
using ComputerAlgebra;

namespace Algebra.Tests
{
    [TestClass]
    public class AlgebraTest
    {
        [TestMethod]
        public void SimpleTest()
        {
            Expression<Func<double, double>> f = x => x * x;
            Func<double, double> df = f.Differentiate();

            Console.WriteLine("f  = {0}", f);   //f  = x => (x * x)
            Console.WriteLine("df = {0}", df);  //df = x => (x + x)

            //Func<double, double> compiled = df.Compile();
            double result = df.Invoke(12);
            Assert.AreEqual(24, result);

            Console.WriteLine(result);          //24
        }

        [TestMethod]
        public void SinTest()
        {
            Expression<Func<double, double>> f = x => (10 + Math.Sin(x)) * x;
            Func<double, double> df = f.Differentiate();

            Console.WriteLine("f  = {0}", f);   //f  = x => ((10 + Sin(x)) * x)
            Console.WriteLine("df = {0}", df);  //df = x => ((10 + Sin(x)) + (Cos(x) * x))

            //Func<double, double> compiled = df.Compile();
            double result = df.Invoke(12);
            Assert.AreEqual(19.5896745867895, result, 5);

            Console.WriteLine(result);          //19,5896745867895          
        }
    }
}

