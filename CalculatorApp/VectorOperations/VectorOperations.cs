using System;
using CalculatorApp.Vectors;

namespace CalculatorApp.VectorOperations
{
    /// <summary>
    /// Performs addition operation on two 2D vectors.
    /// </summary>
    public class Vector2DAddOperation : IVector2DOperation
    {
        /// <summary>
        /// Adds two 2D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector2D Calculate(Vector2D a, Vector2D b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            return new Vector2D(a.X + b.X, a.Y + b.Y);
        }
    }

    /// <summary>
    /// Performs subtraction operation on two 2D vectors.
    /// </summary>
    public class Vector2DSubtractOperation : IVector2DOperation
    {
        /// <summary>
        /// Subtracts one 2D vector from another.
        /// </summary>
        /// <param name="a">The first vector (minuend).</param>
        /// <param name="b">The second vector (subtrahend).</param>
        /// <returns>The difference of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector2D Calculate(Vector2D a, Vector2D b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            return new Vector2D(a.X - b.X, a.Y - b.Y);
        }
    }

    /// <summary>
    /// Performs addition operation on two 3D vectors.
    /// </summary>
    public class Vector3DAddOperation : IVector3DOperation
    {
        /// <summary>
        /// Adds two 3D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The sum of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector3D Calculate(Vector3D a, Vector3D b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            return new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
    }

    /// <summary>
    /// Performs subtraction operation on two 3D vectors.
    /// </summary>
    public class Vector3DSubtractOperation : IVector3DOperation
    {
        /// <summary>
        /// Subtracts one 3D vector from another.
        /// </summary>
        /// <param name="a">The first vector (minuend).</param>
        /// <param name="b">The second vector (subtrahend).</param>
        /// <returns>The difference of the two vectors.</returns>
        /// <exception cref="ArgumentNullException">Thrown when either vector is null.</exception>
        public Vector3D Calculate(Vector3D a, Vector3D b)
        {
            if (a == null) throw new ArgumentNullException(nameof(a));
            if (b == null) throw new ArgumentNullException(nameof(b));
            return new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
    }
}
