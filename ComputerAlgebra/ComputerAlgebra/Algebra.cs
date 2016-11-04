using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebra
{
    public static class Algebra
    {
        private static Expression DifferentiateOfPart(Expression expression)
        {
            if (expression is BinaryExpression)
            {
                if (expression.NodeType == ExpressionType.Add)
                    return Expression.Add(
                        DifferentiateOfPart(((BinaryExpression)expression).Left), 
                        DifferentiateOfPart(((BinaryExpression)expression).Right));

                else if (expression.NodeType == ExpressionType.Multiply)
                    return Expression.Add(
                        Expression.Multiply(
                            ((BinaryExpression)expression).Left, 
                            DifferentiateOfPart(((BinaryExpression)expression).Right)),

                        Expression.Multiply(
                            ((BinaryExpression)expression).Right, 
                            DifferentiateOfPart(((BinaryExpression)expression).Left)));
            }

            else if ((expression is MethodCallExpression) && 
                (((MethodCallExpression)expression).Method.Name == "Sin"))
            {
                var argument = ((MethodCallExpression)expression).Arguments[0];
                return Expression.Multiply(
                     Expression.Call(typeof(Math).GetMethod("Cos"), argument), 
                     DifferentiateOfPart(argument));
            }

            else if (expression is ConstantExpression)
                return Expression.Constant(0.0);

            else if (expression is ParameterExpression)
                return Expression.Constant(1.0);

            throw new ArgumentException("Incorrect expression");
        }

        public static Func<double, double> Differentiate(this Expression<Func<double, double>> expression)
        {
            return (Func<double, double>)Expression.Lambda(
                DifferentiateOfPart(expression.Body),
                expression.Parameters)
                .Compile();
        }
    }
}
