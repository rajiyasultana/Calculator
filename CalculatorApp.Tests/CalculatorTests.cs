using NUnit.Framework;
using CalculatorApp;
using CalculatorApp.Vectors;
using CalculatorApp.VectorOperations;
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
    /// Unit tests for generic Vector2D operations.
    /// </summary>
    public class Vector2DTests
    {
        [Test]
        public void Vector2D_Integer_Add_ReturnsCorrectResult()
        {
            Vector2D<int> v1 = new Vector2D<int>(3, 4);
            Vector2D<int> v2 = new Vector2D<int>(1, 2);
            Vector2DAddOperation<int> addOp = new Vector2DAddOperation<int>();
            Vector2D<int> result = addOp.Calculate(v1, v2);
            Assert.AreEqual(4, result.X);
            Assert.AreEqual(6, result.Y);
        }

        [Test]
        public void Vector2D_Double_Subtract_ReturnsCorrectResult()
        {
            Vector2D<double> v1 = new Vector2D<double>(5.0, 6.0);
            Vector2D<double> v2 = new Vector2D<double>(2.0, 1.0);
            Vector2DSubtractOperation<double> subtractOp = new Vector2DSubtractOperation<double>();
            Vector2D<double> result = subtractOp.Calculate(v1, v2);
            Assert.AreEqual(3.0, result.X);
            Assert.AreEqual(5.0, result.Y);
        }

        [Test]
        public void Vector2D_Float_Magnitude_ReturnsCorrectResult()
        {
            Vector2D<float> v = new Vector2D<float>(3f, 4f);
            double magnitude = v.Magnitude();
            Assert.AreEqual(5.0, magnitude, 0.001);
        }

        [Test]
        public void Vector2D_Integer_DotProduct_ReturnsCorrectResult()
        {
            Vector2D<int> v1 = new Vector2D<int>(1, 2);
            Vector2D<int> v2 = new Vector2D<int>(3, 4);
            dynamic dotProduct = v1.DotProduct(v2);
            Assert.AreEqual(11, dotProduct);
        }

        [Test]
        public void Vector2D_Decimal_Add_ReturnsCorrectResult()
        {
            Vector2D<decimal> v1 = new Vector2D<decimal>(1.5m, 2.5m);
            Vector2D<decimal> v2 = new Vector2D<decimal>(0.5m, 0.5m);
            Vector2DAddOperation<decimal> addOp = new Vector2DAddOperation<decimal>();
            Vector2D<decimal> result = addOp.Calculate(v1, v2);
            Assert.AreEqual(2.0m, result.X);
            Assert.AreEqual(3.0m, result.Y);
        }

        [Test]
        public void Vector2D_Long_Subtract_ReturnsCorrectResult()
        {
            Vector2D<long> v1 = new Vector2D<long>(1000L, 2000L);
            Vector2D<long> v2 = new Vector2D<long>(500L, 1000L);
            Vector2DSubtractOperation<long> subtractOp = new Vector2DSubtractOperation<long>();
            Vector2D<long> result = subtractOp.Calculate(v1, v2);
            Assert.AreEqual(500L, result.X);
            Assert.AreEqual(1000L, result.Y);
        }

        [Test]
        public void Vector2D_Equals_ReturnsTrueForSameValues()
        {
            Vector2D<int> v1 = new Vector2D<int>(3, 4);
            Vector2D<int> v2 = new Vector2D<int>(3, 4);
            Assert.IsTrue(v1.Equals(v2));
        }

        [Test]
        public void Vector2D_Equals_ReturnsFalseForDifferentValues()
        {
            Vector2D<int> v1 = new Vector2D<int>(3, 4);
            Vector2D<int> v2 = new Vector2D<int>(5, 6);
            Assert.IsFalse(v1.Equals(v2));
        }
    }

    /// <summary>
    /// Unit tests for generic Vector3D operations.
    /// </summary>
    public class Vector3DTests
    {
        [Test]
        public void Vector3D_Integer_Add_ReturnsCorrectResult()
        {
            Vector3D<int> v1 = new Vector3D<int>(1, 2, 3);
            Vector3D<int> v2 = new Vector3D<int>(4, 5, 6);
            Vector3DAddOperation<int> addOp = new Vector3DAddOperation<int>();
            Vector3D<int> result = addOp.Calculate(v1, v2);
            Assert.AreEqual(5, result.X);
            Assert.AreEqual(7, result.Y);
            Assert.AreEqual(9, result.Z);
        }

        [Test]
        public void Vector3D_Double_Subtract_ReturnsCorrectResult()
        {
            Vector3D<double> v1 = new Vector3D<double>(5.0, 6.0, 7.0);
            Vector3D<double> v2 = new Vector3D<double>(1.0, 2.0, 3.0);
            Vector3DSubtractOperation<double> subtractOp = new Vector3DSubtractOperation<double>();
            Vector3D<double> result = subtractOp.Calculate(v1, v2);
            Assert.AreEqual(4.0, result.X);
            Assert.AreEqual(4.0, result.Y);
            Assert.AreEqual(4.0, result.Z);
        }

        [Test]
        public void Vector3D_Float_Magnitude_ReturnsCorrectResult()
        {
            Vector3D<float> v = new Vector3D<float>(1f, 2f, 2f);
            double magnitude = v.Magnitude();
            Assert.AreEqual(3.0, magnitude, 0.001);
        }

        [Test]
        public void Vector3D_Integer_DotProduct_ReturnsCorrectResult()
        {
            Vector3D<int> v1 = new Vector3D<int>(1, 2, 3);
            Vector3D<int> v2 = new Vector3D<int>(4, 5, 6);
            dynamic dotProduct = v1.DotProduct(v2);
            Assert.AreEqual(32, dotProduct);
        }

        [Test]
        public void Vector3D_Double_CrossProduct_ReturnsCorrectResult()
        {
            Vector3D<double> v1 = new Vector3D<double>(1.0, 0.0, 0.0);
            Vector3D<double> v2 = new Vector3D<double>(0.0, 1.0, 0.0);
            Vector3D<double> result = v1.CrossProduct(v2);
            Assert.AreEqual(0.0, result.X);
            Assert.AreEqual(0.0, result.Y);
            Assert.AreEqual(1.0, result.Z);
        }

        [Test]
        public void Vector3D_Equals_ReturnsTrueForSameValues()
        {
            Vector3D<int> v1 = new Vector3D<int>(1, 2, 3);
            Vector3D<int> v2 = new Vector3D<int>(1, 2, 3);
            Assert.IsTrue(v1.Equals(v2));
        }
    }
}
