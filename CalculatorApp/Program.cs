using CalculatorApp;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Universal Console Calculator");
        Console.WriteLine("Supports: int, float, double, decimal, long");
        Console.WriteLine("Operations: +, -, *, /, %, ^ (where applicable)");
        Console.WriteLine();

        Console.Write("Enter first number: ");
        string input1 = Console.ReadLine();

        Console.Write("Enter operator (+, -, *, /, %, ^): ");
        string op = Console.ReadLine();

        Console.Write("Enter second number: ");
        string input2 = Console.ReadLine();

        try
        {
            // Try as integer first
            if (int.TryParse(input1, out int a) && int.TryParse(input2, out int b))
            {
                int result = UniversalCalculator.Calculate(op, a, b);
                Console.WriteLine("Result (int): " + result);
            }
            // Try as double
            else if (double.TryParse(input1, out double d1) && double.TryParse(input2, out double d2))
            {
                double result = UniversalCalculator.Calculate(op, d1, d2);
                Console.WriteLine("Result (double): " + result);
            }
            else
            {
                Console.WriteLine("Invalid number format");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
