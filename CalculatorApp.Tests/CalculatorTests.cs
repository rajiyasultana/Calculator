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
}
