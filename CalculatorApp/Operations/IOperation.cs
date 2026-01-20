using System;

namespace CalculatorApp.Operations
{
    /// <summary>
    /// Interface for arithmetic operations.
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Gets the symbol for the operation.
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Performs the operation on two operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        double Calculate(double a, double b);
    }
}
