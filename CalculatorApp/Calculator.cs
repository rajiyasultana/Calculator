// CalculatorApp/Calculator.cs
using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    /// <summary>
    /// Generic calculator that supports any numeric type (int, float, double, decimal, long).
    /// </summary>
    /// <typeparam name="T">The numeric type to operate on.</typeparam>
    public class Calculator<T> where T : struct
    {
        private readonly Dictionary<string, Func<T, T, T>> _operations;

        /// <summary>
        /// Initializes a new instance of the generic Calculator class.
        /// </summary>
        public Calculator()
        {
            _operations = new Dictionary<string, Func<T, T, T>>();
        }

        /// <summary>
        /// Registers an operation with a symbol.
        /// </summary>
        /// <param name="symbol">The operation symbol.</param>
        /// <param name="operation">The operation function.</param>
        public void RegisterOperation(string symbol, Func<T, T, T> operation)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new ArgumentException("Symbol cannot be null or empty.");
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            _operations[symbol] = operation;
        }

        /// <summary>
        /// Executes an operation with two operands.
        /// </summary>
        /// <param name="symbol">The operation symbol.</param>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        public T Execute(string symbol, T a, T b)
        {
            if (string.IsNullOrWhiteSpace(symbol))
                throw new InvalidOperationException("Operation symbol cannot be null or empty.");

            if (!_operations.ContainsKey(symbol))
                throw new InvalidOperationException("Invalid operation symbol: " + symbol);

            try
            {
                return _operations[symbol](a, b);
            }
            catch (DivideByZeroException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error executing operation: " + symbol, ex);
            }
        }

        /// <summary>
        /// Gets all available operation symbols.
        /// </summary>
        /// <returns>Array of operation symbols.</returns>
        public string[] GetAvailableOperations()
        {
            string[] keys = new string[_operations.Count];
            _operations.Keys.CopyTo(keys, 0);
            return keys;
        }
    }
}
