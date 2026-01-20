namespace CalculatorApp.Operations
{
    /// <summary>
    /// Interface for basic binary arithmetic operations.
    /// </summary>
    public interface IOperation
    {
        /// <summary>
        /// Gets the symbol representing this operation (e.g., \"+\", \"-\").
        /// </summary>
        string Symbol { get; }

        /// <summary>
        /// Calculates the result of this operation on two operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        double Calculate(double a, double b);
    }
}
