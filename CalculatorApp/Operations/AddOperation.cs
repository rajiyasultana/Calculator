// CalculatorApp/Operations/AddOperation.cs
using System;

namespace CalculatorApp.Operations
{
    /// <summary>
    /// Represents the addition operation.
    /// </summary>
    public class AddOperation : IOperation
    {
        /// <summary>
        /// Gets the symbol for the addition operation.
        /// </summary>
        public string Symbol => "+";

        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Calculate(double a, double b) => a + b;
    }

    /// <summary>
    /// Represents the subtraction operation.
    /// </summary>
    public class SubtractOperation : IOperation
    {
        /// <summary>
        /// Gets the symbol for the subtraction operation.
        /// </summary>
        public string Symbol => "-";

        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="a">The minuend.</param>
        /// <param name="b">The subtrahend.</param>
        /// <returns>The difference of the two numbers.</returns>
        public double Calculate(double a, double b) => a - b;
    }

    /// <summary>
    /// Represents the multiplication operation.
    /// </summary>
    public class MultiplyOperation : IOperation
    {
        /// <summary>
        /// Gets the symbol for the multiplication operation.
        /// </summary>
        public string Symbol => "*";

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Calculate(double a, double b) => a * b;
    }

    /// <summary>
    /// Represents the division operation.
    /// </summary>
    public class DivideOperation : IOperation
    {
        /// <summary>
        /// Gets the symbol for the division operation.
        /// </summary>
        public string Symbol => "/";

        /// <summary>
        /// Divides one number by another.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor.</param>
        /// <returns>The quotient of the two numbers.</returns>
        /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero.</exception>
        public double Calculate(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
