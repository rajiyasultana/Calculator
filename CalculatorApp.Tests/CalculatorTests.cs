using NUnit.Framework;
using CalculatorApp;
using System;

namespace CalculatorApp.Tests
{
    /// <summary>
    /// Unit tests for the generic Calculator<T> class.
    /// </summary>
    public class GenericCalculatorTests
    {
        [Test]
        public void GenericCalculator_Integer_Addition_ReturnsCorrectResult()
        {
            Calculator<int> calc = new Calculator<int>();
            calc.RegisterOperation("+", (a, b) => a + b);
            int result = calc.Execute("+", 5, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void GenericCalculator_Integer_Subtraction_ReturnsCorrectResult()
        {
            Calculator<int> calc = new Calculator<int>();
            calc.RegisterOperation("-", (a, b) => a - b);
            int result = calc.Execute("-", 10, 4);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void GenericCalculator_Integer_Multiplication_ReturnsCorrectResult()
        {
            Calculator<int> calc = new Calculator<int>();
            calc.RegisterOperation("*", (a, b) => a * b);
            int result = calc.Execute("*", 6, 7);
            Assert.AreEqual(42, result);
        }

        [Test]
        public void GenericCalculator_Integer_Division_ReturnsCorrectResult()
        {
            Calculator<int> calc = new Calculator<int>();
            calc.RegisterOperation("/", (a, b) =>
            {
                if (b == 0) throw new DivideByZeroException();
                return a / b;
            });
            int result = calc.Execute("/", 15, 3);
            Assert.AreEqual(5, result);
        }

        [Test]
        public void GenericCalculator_Double_Addition_ReturnsCorrectResult()
        {
            Calculator<double> calc = new Calculator<double>();
            calc.RegisterOperation("+", (a, b) => a + b);
            double result = calc.Execute("+", 2.5, 3.5);
            Assert.AreEqual(6.0, result);
        }

        [Test]
        public void GenericCalculator_Double_Division_ReturnsCorrectResult()
        {
            Calculator<double> calc = new Calculator<double>();
            calc.RegisterOperation("/", (a, b) =>
            {
                if (b == 0) throw new DivideByZeroException();
                return a / b;
            });
            double result = calc.Execute("/", 10, 4);
            Assert.AreEqual(2.5, result);
        }

        [Test]
        public void GenericCalculator_Decimal_Addition_ReturnsCorrectResult()
        {
            Calculator<decimal> calc = new Calculator<decimal>();
            calc.RegisterOperation("+", (a, b) => a + b);
            decimal result = calc.Execute("+", 10.5m, 5.5m);
            Assert.AreEqual(16m, result);
        }

        [Test]
        public void GenericCalculator_Long_Multiplication_ReturnsCorrectResult()
        {
            Calculator<long> calc = new Calculator<long>();
            calc.RegisterOperation("*", (a, b) => a * b);
            long result = calc.Execute("*", 1000000L, 2000000L);
            Assert.AreEqual(2000000000000L, result);
        }

        [Test]
        public void GenericCalculator_InvalidOperation_ThrowsException()
        {
            Calculator<int> calc = new Calculator<int>();
            Assert.Throws<InvalidOperationException>(() => calc.Execute("&", 5, 3));
        }

        [Test]
        public void GenericCalculator_DivideByZero_ThrowsException()
        {
            Calculator<int> calc = new Calculator<int>();
            calc.RegisterOperation("/", (a, b) =>
            {
                if (b == 0) throw new DivideByZeroException();
                return a / b;
            });
            Assert.Throws<DivideByZeroException>(() => calc.Execute("/", 5, 0));
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
