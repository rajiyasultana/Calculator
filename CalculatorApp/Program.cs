using CalculatorApp;
using CalculatorApp.Operations;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var operations = new List<IOperation>
        {
            new AddOperation(),
            new SubtractOperation(),
            new MultiplyOperation(),
            new DivideOperation()
        };

        var calculator = new Calculator(operations);

        Console.WriteLine("Simple Console Calculator (+, -, *, /)");
        Console.Write("Enter first number: ");
        double a = double.Parse(Console.ReadLine()!);

        Console.Write("Enter operator: ");
        string op = Console.ReadLine()!;

        Console.Write("Enter second number: ");
        double b = double.Parse(Console.ReadLine()!);

        try
        {
            double result = calculator.Execute(op, a, b);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
