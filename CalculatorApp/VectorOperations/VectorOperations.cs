using System;
using CalculatorApp.Vectors;

namespace CalculatorApp.VectorOperations
{
    /// <summary>
    /// Performs addition operation on two generic 2D vectors.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public class Vector2DAddOperation<T> : IVector2DOperation<T> where T : struct
    {
        /// <summary>
        /// Adds two 2D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector2D<T> Calculate(Vector2D<T> a, Vector2D<T> b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            dynamic x1 = a.X;
            dynamic y1 = a.Y;
            dynamic x2 = b.X;
            dynamic y2 = b.Y;
            return new Vector2D<T>((T)(x1 + x2), (T)(y1 + y2));
        }
    }

    /// <summary>
    /// Performs subtraction operation on two generic 2D vectors.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public class Vector2DSubtractOperation<T> : IVector2DOperation<T> where T : struct
    {
        /// <summary>
        /// Subtracts one 2D vector from another.
        /// </summary>
        /// <param name="a">The first vector (minuend).</param>
        /// <param name="b">The second vector (subtrahend).</param>
        /// <returns>The difference of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector2D<T> Calculate(Vector2D<T> a, Vector2D<T> b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            dynamic x1 = a.X;
            dynamic y1 = a.Y;
            dynamic x2 = b.X;
            dynamic y2 = b.Y;
            return new Vector2D<T>((T)(x1 - x2), (T)(y1 - y2));
        }
    }

    /// <summary>
    /// Performs addition operation on two generic 3D vectors.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public class Vector3DAddOperation<T> : IVector3DOperation<T> where T : struct
    {
        /// <summary>
        /// Adds two 3D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector3D<T> Calculate(Vector3D<T> a, Vector3D<T> b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            dynamic x1 = a.X;
            dynamic y1 = a.Y;
            dynamic z1 = a.Z;
            dynamic x2 = b.X;
            dynamic y2 = b.Y;
            dynamic z2 = b.Z;
            return new Vector3D<T>((T)(x1 + x2), (T)(y1 + y2), (T)(z1 + z2));
        }
    }

    /// <summary>
    /// Performs subtraction operation on two generic 3D vectors.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public class Vector3DSubtractOperation<T> : IVector3DOperation<T> where T : struct
    {
        /// <summary>
        /// Subtracts one 3D vector from another.
        /// </summary>
        /// <param name="a">The first vector (minuend).</param>
        /// <param name="b">The second vector (subtrahend).</param>
        /// <returns>The difference of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector3D<T> Calculate(Vector3D<T> a, Vector3D<T> b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            dynamic x1 = a.X;
            dynamic y1 = a.Y;
            dynamic z1 = a.Z;
            dynamic x2 = b.X;
            dynamic y2 = b.Y;
            dynamic z2 = b.Z;
            return new Vector3D<T>((T)(x1 - x2), (T)(y1 - y2), (T)(z1 - z2));
        }
    }
}
