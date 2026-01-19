using NUnit.Framework;
using CalculatorApp;
using CalculatorApp.Operations;
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
        public void AddOperation_Test() => Assert.Equals(5, _calculator.Execute("+", 2, 3));

        [Test]
        public void SubtractOperation_Test() => Assert.Equals(2, _calculator.Execute("-", 5, 3));

        [Test]
        public void MultiplyOperation_Test() => Assert.Equals(15, _calculator.Execute("*", 5, 3));

        [Test]
        public void DivideOperation_Test() => Assert.Equals(2, _calculator.Execute("/", 6, 3));

        [Test]
        public void DivideByZero_ShouldThrow() => Assert.Throws<System.DivideByZeroException>(() => _calculator.Execute("/", 5, 0));
    }
}
