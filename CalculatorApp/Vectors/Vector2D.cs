using System;

namespace CalculatorApp.Vectors
{
    /// <summary>
    /// Represents a 2-dimensional vector with X and Y components.
    /// </summary>
    public class Vector2D
    {
        /// <summary>
        /// Gets or sets the X component of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y component of the vector.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Initializes a new instance of the Vector2D class.
        /// </summary>
        /// <param name="x">The X component (default: 0).</param>
        /// <param name="y">The Y component (default: 0).</param>
        public Vector2D(double x = 0, double y = 0)
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
            if (!(obj is Vector2D)) return false;
            Vector2D other = (Vector2D)obj;
            return X == other.X && Y == other.Y;
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
        /// <returns>The magnitude of the vector.</returns>
        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        /// Calculates the dot product of this vector with another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot product.</returns>
        public double DotProduct(Vector2D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return X * other.X + Y * other.Y;
        }
    }
}
