using NUnit.Framework;
using CalculatorApp.Vectors;
using CalculatorApp.VectorOperations;
using System;

namespace CalculatorApp.Tests
{
    /// <summary>
    /// Unit tests for 2D vector operations.
    /// </summary>
    public class Vector2DTests
    {
        private IVector2DOperation _addOperation;
        private IVector2DOperation _subtractOperation;

        [SetUp]
        public void Setup()
        {
            _addOperation = new Vector2DAddOperation();
            _subtractOperation = new Vector2DSubtractOperation();
        }

        [Test]
        public void Vector2D_Add_WithPositiveNumbers_ReturnsCorrectResult()
        {
            Vector2D v1 = new Vector2D(2, 3);
            Vector2D v2 = new Vector2D(1, 4);
            Vector2D result = _addOperation.Calculate(v1, v2);
            
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(7, result.Y);
        }

        [Test]
        public void Vector2D_Subtract_WithPositiveNumbers_ReturnsCorrectResult()
        {
            Vector2D v1 = new Vector2D(5, 7);
            Vector2D v2 = new Vector2D(2, 3);
            Vector2D result = _subtractOperation.Calculate(v1, v2);
            
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(4, result.Y);
        }

        [Test]
        public void Vector2D_Add_WithNegativeNumbers_ReturnsCorrectResult()
        {
            Vector2D v1 = new Vector2D(-1, -2);
            Vector2D v2 = new Vector2D(3, 4);
            Vector2D result = _addOperation.Calculate(v1, v2);
            
            Assert.AreEqual(2, result.X);
            Assert.AreEqual(2, result.Y);
        }

        [Test]
        public void Vector2D_Subtract_ResultsInNegative_ReturnsCorrectResult()
        {
            Vector2D v1 = new Vector2D(1, 2);
            Vector2D v2 = new Vector2D(3, 4);
            Vector2D result = _subtractOperation.Calculate(v1, v2);
            
            Assert.AreEqual(-2, result.X);
            Assert.AreEqual(-2, result.Y);
        }

        [Test]
        public void Vector2D_Magnitude_ReturnsCorrectValue()
        {
            Vector2D v = new Vector2D(3, 4);
            double magnitude = v.Magnitude();
            
            Assert.AreEqual(5, magnitude);
        }

        [Test]
        public void Vector2D_Add_WithNullVector_ThrowsArgumentNullException()
        {
            Vector2D v1 = new Vector2D(1, 2);
            Assert.Throws<ArgumentNullException>(() => _addOperation.Calculate(v1, null));
        }

        [Test]
        public void Vector2D_DotProduct_ReturnsCorrectValue()
        {
            Vector2D v1 = new Vector2D(2, 3);
            Vector2D v2 = new Vector2D(4, 5);
            double result = v1.DotProduct(v2);
            
            Assert.AreEqual(23, result);
        }
    }
}
