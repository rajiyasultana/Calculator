using NUnit.Framework;
using CalculatorApp;
using CalculatorApp.Operations;
using System;
using System.Collections.Generic;

namespace CalculatorApp.Tests
{
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
        public void AddOperation_Test()
        {
            double result = _calculator.Execute("+", 2, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void SubtractOperation_Test()
        {
            double result = _calculator.Execute("-", 5, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void MultiplyOperation_Test()
        {
            double result = _calculator.Execute("*", 5, 3);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void DivideOperation_Test()
        {
            double result = _calculator.Execute("/", 6, 3);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void DivideByZero_ShouldThrow()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Execute("/", 5, 0));
        }

        [Test]
        public void InvalidOperation_ShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => _calculator.Execute("^", 2, 3));
        }

        [Test]
        public void AddNegativeNumbers_Test()
        {
            double result = _calculator.Execute("+", -2, -3);
            Assert.AreEqual(-5, result);
        }

        [Test]
        public void MultiplyByZero_Test()
        {
            double result = _calculator.Execute("*", 5, 0);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void DecimalOperations_Test()
        {
            double result = _calculator.Execute("+", 2.5, 3.5);
            Assert.AreEqual(6.0, result);
        }
    }
}
