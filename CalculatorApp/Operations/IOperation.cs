namespace CalculatorApp.Operations
{
    public interface IOperation
    {
        double Calculate(double a, double b);
        string Symbol { get; }
    }
}
