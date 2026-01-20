using CalculatorApp;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Generic Calculator");
        Console.WriteLine("Select type: 1=int, 2=float, 3=double, 4=decimal, 5=long");
        Console.WriteLine();

        Console.Write("Enter type (1-5): ");
        string typeChoice = Console.ReadLine();

        Console.Write("Enter first number: ");
        string input1 = Console.ReadLine();

        Console.Write("Enter operator (+, -, *, /): ");
        string op = Console.ReadLine();

        Console.Write("Enter second number: ");
        string input2 = Console.ReadLine();

        try
        {
            switch (typeChoice)
            {
                case "1":
                    if (int.TryParse(input1, out int a1) && int.TryParse(input2, out int b1))
                    {
                        Calculator<int> calc = new Calculator<int>();
                        calc.RegisterOperation("+", (x, y) => x + y);
                        calc.RegisterOperation("-", (x, y) => x - y);
                        calc.RegisterOperation("*", (x, y) => x * y);
                        calc.RegisterOperation("/", (x, y) => y == 0 ? throw new DivideByZeroException("Cannot divide by zero") : x / y);
                        int result = calc.Execute(op, a1, b1);
                        Console.WriteLine("Result (int): " + result);
                    }
                    break;

                case "2":
                    if (float.TryParse(input1, out float a2) && float.TryParse(input2, out float b2))
                    {
                        Calculator<float> calc = new Calculator<float>();
                        calc.RegisterOperation("+", (x, y) => x + y);
                        calc.RegisterOperation("-", (x, y) => x - y);
                        calc.RegisterOperation("*", (x, y) => x * y);
                        calc.RegisterOperation("/", (x, y) => y == 0 ? throw new DivideByZeroException("Cannot divide by zero") : x / y);
                        float result = calc.Execute(op, a2, b2);
                        Console.WriteLine("Result (float): " + result);
                    }
                    break;

                case "3":
                    if (double.TryParse(input1, out double a3) && double.TryParse(input2, out double b3))
                    {
                        Calculator<double> calc = new Calculator<double>();
                        calc.RegisterOperation("+", (x, y) => x + y);
                        calc.RegisterOperation("-", (x, y) => x - y);
                        calc.RegisterOperation("*", (x, y) => x * y);
                        calc.RegisterOperation("/", (x, y) => y == 0 ? throw new DivideByZeroException("Cannot divide by zero") : x / y);
                        double result = calc.Execute(op, a3, b3);
                        Console.WriteLine("Result (double): " + result);
                    }
                    break;

                case "4":
                    if (decimal.TryParse(input1, out decimal a4) && decimal.TryParse(input2, out decimal b4))
                    {
                        Calculator<decimal> calc = new Calculator<decimal>();
                        calc.RegisterOperation("+", (x, y) => x + y);
                        calc.RegisterOperation("-", (x, y) => x - y);
                        calc.RegisterOperation("*", (x, y) => x * y);
                        calc.RegisterOperation("/", (x, y) => y == 0 ? throw new DivideByZeroException("Cannot divide by zero") : x / y);
                        decimal result = calc.Execute(op, a4, b4);
                        Console.WriteLine("Result (decimal): " + result);
                    }
                    break;

                case "5":
                    if (long.TryParse(input1, out long a5) && long.TryParse(input2, out long b5))
                    {
                        Calculator<long> calc = new Calculator<long>();
                        calc.RegisterOperation("+", (x, y) => x + y);
                        calc.RegisterOperation("-", (x, y) => x - y);
                        calc.RegisterOperation("*", (x, y) => x * y);
                        calc.RegisterOperation("/", (x, y) => y == 0 ? throw new DivideByZeroException("Cannot divide by zero") : x / y);
                        long result = calc.Execute(op, a5, b5);
                        Console.WriteLine("Result (long): " + result);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid type choice");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
