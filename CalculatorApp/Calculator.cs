// CalculatorApp/Calculator.cs
using CalculatorApp.Operations;
using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    public class Calculator
    {
        private readonly Dictionary<string, IOperation> _operations;

        public Calculator(IEnumerable<IOperation> operations)
        {
            _operations = new Dictionary<string, IOperation>();
            foreach (var op in operations)
                _operations[op.Symbol] = op;
        }

        public double Execute(string symbol, double a, double b)
        {
            if (!_operations.ContainsKey(symbol))
                throw new InvalidOperationException("Invalid operation symbol.");
            return _operations[symbol].Calculate(a, b);
        }
    }
}
