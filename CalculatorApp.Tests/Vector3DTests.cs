using NUnit.Framework;
using CalculatorApp.Vectors;
using CalculatorApp.VectorOperations;
using System;

namespace CalculatorApp.Tests
{
    /// <summary>
    /// Unit tests for 3D vector operations.
    /// </summary>
    public class Vector3DTests
    {
        private IVector3DOperation _addOperation;
        private IVector3DOperation _subtractOperation;

        [SetUp]
        public void Setup()
        {
            _addOperation = new Vector3DAddOperation();
            _subtractOperation = new Vector3DSubtractOperation();
        }

        [Test]
        public void Vector3D_Add_WithPositiveNumbers_ReturnsCorrectResult()
        {
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(2, 3, 4);
            Vector3D result = _addOperation.Calculate(v1, v2);
            
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(5, result.Y);
            Assert.AreEqual(7, result.Z);
        }

        [Test]
        public void Vector3D_Subtract_WithPositiveNumbers_ReturnsCorrectResult()
        {
            Vector3D v1 = new Vector3D(5, 7, 9);
            Vector3D v2 = new Vector3D(2, 3, 4);
            Vector3D result = _subtractOperation.Calculate(v1, v2);
            
            Assert.AreEqual(3, result.X);
            Assert.AreEqual(4, result.Y);
            Assert.AreEqual(5, result.Z);
        }

        [Test]
        public void Vector3D_Add_WithNegativeNumbers_ReturnsCorrectResult()
        {
            Vector3D v1 = new Vector3D(-1, -2, -3);
            Vector3D v2 = new Vector3D(1, 2, 3);
            Vector3D result = _addOperation.Calculate(v1, v2);
            
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
            Assert.AreEqual(0, result.Z);
        }

        [Test]
        public void Vector3D_Subtract_ResultsInNegative_ReturnsCorrectResult()
        {
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(2, 3, 4);
            Vector3D result = _subtractOperation.Calculate(v1, v2);
            
            Assert.AreEqual(-1, result.X);
            Assert.AreEqual(-1, result.Y);
            Assert.AreEqual(-1, result.Z);
        }

        [Test]
        public void Vector3D_Magnitude_ReturnsCorrectValue()
        {
            Vector3D v = new Vector3D(1, 2, 2);
            double magnitude = v.Magnitude();
            
            Assert.AreEqual(3, magnitude);
        }

        [Test]
        public void Vector3D_Add_WithNullVector_ThrowsArgumentNullException()
        {
            Vector3D v1 = new Vector3D(1, 2, 3);
            Assert.Throws<ArgumentNullException>(() => _addOperation.Calculate(v1, null));
        }

        [Test]
        public void Vector3D_DotProduct_ReturnsCorrectValue()
        {
            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(4, 5, 6);
            double result = v1.DotProduct(v2);
            
            Assert.AreEqual(32, result);
        }

        [Test]
        public void Vector3D_CrossProduct_ReturnsCorrectValue()
        {
            Vector3D v1 = new Vector3D(1, 0, 0);
            Vector3D v2 = new Vector3D(0, 1, 0);
            Vector3D result = v1.CrossProduct(v2);
            
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
            Assert.AreEqual(1, result.Z);
        }
    }
}
