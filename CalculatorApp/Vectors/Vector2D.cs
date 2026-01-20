using System;

namespace CalculatorApp.Vectors
{
    /// <summary>
    /// Represents a 2-dimensional vector with X and Y components of type T.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public class Vector2D<T> where T : struct
    {
        /// <summary>
        /// Gets or sets the X component of the vector.
        /// </summary>
        public T X { get; set; }

        /// <summary>
        /// Gets or sets the Y component of the vector.
        /// </summary>
        public T Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the Vector2D class.
        /// </summary>
        /// <param name="x">The X component (default: 0).</param>
        /// <param name="y">The Y component (default: 0).</param>
        public Vector2D(T x = default(T), T y = default(T))
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string in the format "(X, Y)".</returns>
        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current vector.
        /// </summary>
        /// <param name="obj">The object to compare with the current vector.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector2D<T>)) return false;
            Vector2D<T> other = (Vector2D<T>)obj;
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// Calculates the magnitude (length) of the vector.
        /// </summary>
        /// <returns>The magnitude of the vector as double.</returns>
        public double Magnitude()
        {
            dynamic x = X;
            dynamic y = Y;
            return Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Calculates the dot product of this vector with another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot product as dynamic type.</returns>
        public dynamic DotProduct(Vector2D<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            dynamic x1 = X;
            dynamic y1 = Y;
            dynamic x2 = other.X;
            dynamic y2 = other.Y;
            return x1 * x2 + y1 * y2;
        }
    }
}
