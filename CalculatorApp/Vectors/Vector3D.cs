using System;

namespace CalculatorApp.Vectors
{
    /// <summary>
    /// Represents a 3-dimensional vector with X, Y, and Z components of type T.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public class Vector3D<T> where T : struct
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
        /// Gets or sets the Z component of the vector.
        /// </summary>
        public T Z { get; set; }

        /// <summary>
        /// Initializes a new instance of the Vector3D class.
        /// </summary>
        /// <param name="x">The X component (default: 0).</param>
        /// <param name="y">The Y component (default: 0).</param>
        /// <param name="z">The Z component (default: 0).</param>
        public Vector3D(T x = default(T), T y = default(T), T z = default(T))
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns a string representation of the vector.
        /// </summary>
        /// <returns>A string in the format "(X, Y, Z)".</returns>
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
            if (!(obj is Vector3D<T>)) return false;
            Vector3D<T> other = (Vector3D<T>)obj;
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
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
        /// <returns>The magnitude of the vector as double.</returns>
        public double Magnitude()
        {
            dynamic x = X;
            dynamic y = Y;
            dynamic z = Z;
            return Math.Sqrt(x * x + y * y + z * z);
        }

        /// <summary>
        /// Calculates the dot product of this vector with another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>The dot product as dynamic type.</returns>
        public dynamic DotProduct(Vector3D<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            dynamic x1 = X;
            dynamic y1 = Y;
            dynamic z1 = Z;
            dynamic x2 = other.X;
            dynamic y2 = other.Y;
            dynamic z2 = other.Z;
            return x1 * x2 + y1 * y2 + z1 * z2;
        }

        /// <summary>
        /// Calculates the cross product of this vector with another vector.
        /// </summary>
        /// <param name="other">The other vector.</param>
        /// <returns>A new Vector3D representing the cross product.</returns>
        public Vector3D<T> CrossProduct(Vector3D<T> other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            dynamic x1 = X;
            dynamic y1 = Y;
            dynamic z1 = Z;
            dynamic x2 = other.X;
            dynamic y2 = other.Y;
            dynamic z2 = other.Z;
            return new Vector3D<T>(
                (T)(y1 * z2 - z1 * y2),
                (T)(z1 * x2 - x1 * z2),
                (T)(x1 * y2 - y1 * x2)
            );
        }
    }
}
