using CalculatorApp.Vectors;

namespace CalculatorApp.VectorOperations
{
    /// <summary>
    /// Interface for generic 2D vector operations.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public interface IVector2DOperation<T> where T : struct
    {
        /// <summary>
        /// Performs the operation on two 2D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The result of the operation.</returns>
        Vector2D<T> Calculate(Vector2D<T> a, Vector2D<T> b);
    }

    /// <summary>
    /// Interface for generic 3D vector operations.
    /// </summary>
    /// <typeparam name="T">The numeric type for vector components.</typeparam>
    public interface IVector3DOperation<T> where T : struct
    {
        /// <summary>
        /// Performs the operation on two 3D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The result of the operation.</returns>
        Vector3D<T> Calculate(Vector3D<T> a, Vector3D<T> b);
    }
}
