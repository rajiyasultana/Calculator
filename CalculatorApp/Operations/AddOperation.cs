// CalculatorApp/Operations/AddOperation.cs
using System;

namespace CalculatorApp.Operations
{
    public class AddOperation : IOperation
    {
        public string Symbol => "+";
        public double Calculate(double a, double b) => a + b;
    }

    public class SubtractOperation : IOperation
    {
        public string Symbol => "-";
        public double Calculate(double a, double b) => a - b;
    }

    public class MultiplyOperation : IOperation
    {
        public string Symbol => "*";
        public double Calculate(double a, double b) => a * b;
    }

    public class DivideOperation : IOperation
    {
        public string Symbol => "/";
        public double Calculate(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
