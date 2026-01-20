using CalculatorApp.Vectors;

namespace CalculatorApp.VectorOperations
{
    /// <summary>
    /// Interface for 2D vector operations.
    /// </summary>
    public interface IVector2DOperation
    {
        /// <summary>
        /// Performs the operation on two 2D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The result of the operation.</returns>
        Vector2D Calculate(Vector2D a, Vector2D b);
    }

    /// <summary>
    /// Interface for 3D vector operations.
    /// </summary>
    public interface IVector3DOperation
    {
        /// <summary>
        /// Performs the operation on two 3D vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The result of the operation.</returns>
        Vector3D Calculate(Vector3D a, Vector3D b);
    }
}
