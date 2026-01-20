using NUnit.Framework;
using CalculatorApp;
using CalculatorApp.Operations;
using System;
using System.Collections.Generic;

namespace CalculatorApp.Tests
{
    /// <summary>
    /// Unit tests for the Calculator class.
    /// </summary>
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            var operations = new List<IOperation>
            {
                new AddOperation(),
                new SubtractOperation(),
                new MultiplyOperation(),
                new DivideOperation()
            };
            _calculator = new Calculator(operations);
        }

        [Test]
        public void AddOperation_WithPositiveNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Execute("+", 2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void SubtractOperation_WithPositiveNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Execute("-", 5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MultiplyOperation_WithPositiveNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Execute("*", 5, 3);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void DivideOperation_WithPositiveNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Execute("/", 6, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DivideByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Execute("/", 5, 0));
        }

        [Test]
        public void InvalidOperation_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _calculator.Execute("^", 2, 3));
        }

        [Test]
        public void AddOperation_WithNegativeNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Execute("+", -2, -3);
            Assert.AreEqual(-5, result);
        }

        [Test]
        public void MultiplyOperation_ByZero_ReturnsZero()
        {
            double result = _calculator.Execute("*", 5, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Operations_WithDecimalNumbers_ReturnsCorrectResult()
        {
            double result = _calculator.Execute("+", 2.5, 3.5);
            Assert.AreEqual(6.0, result);
        }
    }

    /// <summary>
    /// Unit tests for the UniversalCalculator that handles multiple data types.
    /// </summary>
    public class UniversalCalculatorTests
    {
        [Test]
        public void Integer_Addition_ReturnsCorrectResult()
        {
            int result = UniversalCalculator.Calculate("+", 5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Integer_Subtraction_ReturnsCorrectResult()
        {
            int result = UniversalCalculator.Calculate("-", 10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Integer_Multiplication_ReturnsCorrectResult()
        {
            int result = UniversalCalculator.Calculate("*", 6, 7);
            Assert.AreEqual(42, result);
        }

        [Test]
        public void Integer_Division_ReturnsCorrectResult()
        {
            int result = UniversalCalculator.Calculate("/", 15, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void Integer_Modulo_ReturnsCorrectResult()
        {
            int result = UniversalCalculator.Calculate("%", 17, 5);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Integer_Power_ReturnsCorrectResult()
        {
            int result = UniversalCalculator.Calculate("^", 2, 8);
            Assert.AreEqual(256, result);
        }

        [Test]
        public void Float_Addition_ReturnsCorrectResult()
        {
            float result = UniversalCalculator.Calculate("+", 2.5f, 3.5f);
            Assert.AreEqual(6.0f, result, 0.001f);
        }

        [Test]
        public void Float_Division_ReturnsCorrectResult()
        {
            float result = UniversalCalculator.Calculate("/", 10f, 4f);
            Assert.AreEqual(2.5f, result, 0.001f);
        }

        [Test]
        public void Double_Addition_ReturnsCorrectResult()
        {
            double result = UniversalCalculator.Calculate("+", 2.5, 3.5);
            Assert.AreEqual(6.0, result);
        }

        [Test]
        public void Double_Power_ReturnsCorrectResult()
        {
            double result = UniversalCalculator.Calculate("^", 2.0, 3.0);
            Assert.AreEqual(8.0, result);
        }

        [Test]
        public void Decimal_Addition_ReturnsCorrectResult()
        {
            decimal result = UniversalCalculator.Calculate("+", 10.5m, 5.5m);
            Assert.AreEqual(16m, result);
        }

        [Test]
        public void Decimal_Division_ReturnsCorrectResult()
        {
            decimal result = UniversalCalculator.Calculate("/", 10m, 4m);
            Assert.AreEqual(2.5m, result);
        }

        [Test]
        public void Long_Multiplication_ReturnsCorrectResult()
        {
            long result = UniversalCalculator.Calculate("*", 1000000L, 2000000L);
            Assert.AreEqual(2000000000000L, result);
        }

        [Test]
        public void Long_Division_ReturnsCorrectResult()
        {
            long result = UniversalCalculator.Calculate("/", 1000000L, 1000L);
            Assert.AreEqual(1000L, result);
        }

        [Test]
        public void Integer_DivideByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => UniversalCalculator.Calculate("/", 5, 0));
        }

        [Test]
        public void Double_DivideByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => UniversalCalculator.Calculate("/", 5.0, 0.0));
        }

        [Test]
        public void Integer_ModuloByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => UniversalCalculator.Calculate("%", 5, 0));
        }

        [Test]
        public void Invalid_Operation_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() => UniversalCalculator.Calculate("&", 5, 3));
        }

        [Test]
        public void GetSupportedOperations_ForDecimal_ReturnsBasicOps()
        {
            string[] ops = UniversalCalculator.GetSupportedOperations("decimal");
            Assert.AreEqual(4, ops.Length);
            Assert.Contains("+", ops);
            Assert.Contains("-", ops);
            Assert.Contains("*", ops);
            Assert.Contains("/", ops);
        }

        [Test]
        public void GetSupportedOperations_ForInt_ReturnsAllOps()
        {
            string[] ops = UniversalCalculator.GetSupportedOperations("int");
            Assert.AreEqual(6, ops.Length);
            Assert.Contains("^", ops);
        }
    }
}
