// CalculatorApp/Calculator.cs
using CalculatorApp.Operations;
using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    /// <summary>
    /// A simple calculator that supports basic arithmetic operations (+, -, *, /).
    /// </summary>
    public class Calculator
    {
        private readonly Dictionary<string, IOperation> _operations;

        /// <summary>
        /// Initializes a new instance of the Calculator class with the specified operations.
        /// </summary>
        /// <param name="operations">A collection of operations to register with the calculator.</param>
        /// <exception cref="ArgumentNullException">Thrown when operations is null.</exception>
        public Calculator(IEnumerable<IOperation> operations)
        {
            if (operations == null) throw new ArgumentNullException(nameof(operations));
            
            _operations = new Dictionary<string, IOperation>();
            foreach (var op in operations)
            {
                if (op != null)
                    _operations[op.Symbol] = op;
            }
        }

        /// <summary>
        /// Executes an operation with two operands.
        /// </summary>
        /// <param name="symbol">The symbol of the operation (e.g., \"+\", \"-\", \"*\", \"/\").</param>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the symbol is not recognized.</exception>
        public double Execute(string symbol, double a, double b)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new InvalidOperationException("Operation symbol cannot be null or empty.");
            
            if (!_operations.ContainsKey(symbol))
                throw new InvalidOperationException("Invalid operation symbol: " + symbol);
            
            return _operations[symbol].Calculate(a, b);
        }
    }
}
