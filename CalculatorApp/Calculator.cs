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
        /// <param name="symbol">The symbol of the operation (e.g., "+", "-", "*", "/").</param>
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

        /// <summary>
        /// Gets all available operations.
        /// </summary>
        /// <returns>Array of operation symbols.</returns>
        public string[] GetAvailableOperations()
        {
            var keys = new string[_operations.Count];
            _operations.Keys.CopyTo(keys, 0);
            return keys;
        }
    }

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
            var keys = new string[_operations.Count];
            _operations.Keys.CopyTo(keys, 0);
            return keys;
        }
    }

    /// <summary>
    /// Universal calculator that handles multiple data types.
    /// </summary>
    public class UniversalCalculator
    {
        /// <summary>
        /// Performs calculation with integer operands.
        /// Supports: +, -, *, /, %, ^
        /// </summary>
        public static int Calculate(string operation, int a, int b)
        {
            return ExecuteIntOperation(operation, a, b);
        }

        /// <summary>
        /// Performs calculation with float operands.
        /// Supports: +, -, *, /, %
        /// </summary>
        public static float Calculate(string operation, float a, float b)
        {
            return ExecuteFloatOperation(operation, a, b);
        }

        /// <summary>
        /// Performs calculation with double operands.
        /// Supports: +, -, *, /, %, ^
        /// </summary>
        public static double Calculate(string operation, double a, double b)
        {
            return ExecuteDoubleOperation(operation, a, b);
        }

        /// <summary>
        /// Performs calculation with decimal operands.
        /// Supports: +, -, *, /
        /// </summary>
        public static decimal Calculate(string operation, decimal a, decimal b)
        {
            return ExecuteDecimalOperation(operation, a, b);
        }

        /// <summary>
        /// Performs calculation with long operands.
        /// Supports: +, -, *, /, %, ^
        /// </summary>
        public static long Calculate(string operation, long a, long b)
        {
            return ExecuteLongOperation(operation, a, b);
        }

        private static int ExecuteIntOperation(string op, int a, int b)
        {
            switch (op.Trim().ToLower())
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return a / b;
                case "%":
                    if (b == 0) throw new DivideByZeroException("Cannot perform modulo by zero.");
                    return a % b;
                case "^": return (int)Math.Pow(a, b);
                default: throw new InvalidOperationException("Unknown operation: " + op);
            }
        }

        private static float ExecuteFloatOperation(string op, float a, float b)
        {
            switch (op.Trim().ToLower())
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return a / b;
                case "%":
                    if (b == 0) throw new DivideByZeroException("Cannot perform modulo by zero.");
                    return a % b;
                default: throw new InvalidOperationException("Unknown operation: " + op);
            }
        }

        private static double ExecuteDoubleOperation(string op, double a, double b)
        {
            switch (op.Trim().ToLower())
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return a / b;
                case "%":
                    if (b == 0) throw new DivideByZeroException("Cannot perform modulo by zero.");
                    return a % b;
                case "^": return Math.Pow(a, b);
                default: throw new InvalidOperationException("Unknown operation: " + op);
            }
        }

        private static decimal ExecuteDecimalOperation(string op, decimal a, decimal b)
        {
            switch (op.Trim().ToLower())
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return a / b;
                default: throw new InvalidOperationException("Unknown operation: " + op);
            }
        }

        private static long ExecuteLongOperation(string op, long a, long b)
        {
            switch (op.Trim().ToLower())
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/":
                    if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
                    return a / b;
                case "%":
                    if (b == 0) throw new DivideByZeroException("Cannot perform modulo by zero.");
                    return a % b;
                case "^": return (long)Math.Pow(a, b);
                default: throw new InvalidOperationException("Unknown operation: " + op);
            }
        }

        /// <summary>
        /// Gets supported operations for a specific data type.
        /// </summary>
        public static string[] GetSupportedOperations(string dataType)
        {
            if (dataType == null) dataType = "";
            
            switch (dataType.ToLower())
            {
                case "decimal":
                    return new[] { "+", "-", "*", "/" };
                case "float":
                    return new[] { "+", "-", "*", "/", "%" };
                case "int":
                    return new[] { "+", "-", "*", "/", "%", "^" };
                case "long":
                    return new[] { "+", "-", "*", "/", "%", "^" };
                case "double":
                    return new[] { "+", "-", "*", "/", "%", "^" };
                default:
                    return new[] { "+", "-", "*", "/" };
            }
        }
    }
}
