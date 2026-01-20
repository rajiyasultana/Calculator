using System;

namespace CalculatorApp.Vectors
{
    /// <summary>
    /// Represents a 3-dimensional vector with X, Y, and Z components.
    /// </summary>
    public class Vector3D
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
        /// Gets or sets the Z component of the vector.
        /// </summary>
        public double Z { get; set; }

        /// <summary>
        /// Initializes a new instance of the Vector3D class.
        /// </summary>
        /// <param name="x">The X component (default: 0).</param>
        /// <param name="y">The Y component (default: 0).</param>
        /// <param name="z">The Z component (default: 0).</param>
        public Vector3D(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string in the format \"(X, Y, Z)\".</returns>
        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current vector.
        /// </summary>
        /// <param name="obj">The object to compare with the current vector.</param>
        /// <returns>True if the objects are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector3D)) return false;
            Vector3D other = (Vector3D)obj;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }

        /// <summary>
        /// Calculates the magnitude (length) of the vector.
        /// </summary>
        /// <returns>The magnitude of the vector.</returns>
        public double Magnitude()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        /// <summary>
        /// Calculates the dot product of this vector with another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot product.</returns>
        public double DotProduct(Vector3D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return X * other.X + Y * other.Y + Z * other.Z;
        }

        /// <summary>
        /// Calculates the cross product of this vector with another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>A new Vector3D representing the cross product.</returns>
        public Vector3D CrossProduct(Vector3D other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            return new Vector3D(
                Y * other.Z - Z * other.Y,
                Z * other.X - X * other.Z,
                X * other.Y - Y * other.X
            );
        }
    }
}
