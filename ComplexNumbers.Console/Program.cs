using System;
using ComplexNumbers.Library;

namespace ComplexNumbers.Console;

/// <summary>
///     Driver program demonstrating the Complex number class functionality.
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("==============================================");
        System.Console.WriteLine("   Complex Number Class Demonstration");
        System.Console.WriteLine("==============================================\n");

        // Demonstrate basic construction
        DemonstrateConstruction();

        // Demonstrate arithmetic operations
        DemonstrateArithmetic();

        // Demonstrate properties
        DemonstrateProperties();

        // Demonstrate implicit conversions
        DemonstrateImplicitConversions();

        // Demonstrate static methods
        DemonstrateStaticMethods();

       

        // Interactive calculator
        RunInteractiveCalculator();
    }

    public static void DemonstrateConstruction()
    {
        System.Console.WriteLine("1. CONSTRUCTION AND BASIC REPRESENTATION");
        System.Console.WriteLine("-----------------------------------------");

        var c1 = new Complex(3, 4);
        var c2 = new Complex(5);
        var c3 = Complex.Zero;
        var c4 = Complex.One;
        var c5 = Complex.ImaginaryOne;

        System.Console.WriteLine($"Complex(3, 4) = {c1}");
        System.Console.WriteLine($"Complex(5) = {c2}");
        System.Console.WriteLine($"Complex.Zero = {c3}");
        System.Console.WriteLine($"Complex.One = {c4}");
        System.Console.WriteLine($"Complex.ImaginaryOne = {c5}");
        System.Console.WriteLine();
    }

    public static void DemonstrateArithmetic()
    {
        System.Console.WriteLine("2. ARITHMETIC OPERATIONS");
        System.Console.WriteLine("------------------------");

        var a = new Complex(3, 4);
        var b = new Complex(1, 2);

        System.Console.WriteLine($"a = {a}");
        System.Console.WriteLine($"b = {b}");
        System.Console.WriteLine($"a + b = {a + b}");
        System.Console.WriteLine($"a - b = {a - b}");
        System.Console.WriteLine($"a * b = {a * b}");
        System.Console.WriteLine($"a / b = {a / b}");
        System.Console.WriteLine($"-a = {-a}");
        System.Console.WriteLine();

        // Demonstrate operator chaining
        var c = new Complex(2, 1);
        var result = (a + b) * c - Complex.One;
        System.Console.WriteLine($"((a + b) * c) - 1 = {result}");
        System.Console.WriteLine();
    }

    public static void DemonstrateProperties()
    {
        System.Console.WriteLine("3. PROPERTIES");
        System.Console.WriteLine("-------------");

        var c = new Complex(3, 4);

        System.Console.WriteLine($"c = {c}");
        System.Console.WriteLine($"Real part: {c.Real}");
        System.Console.WriteLine($"Imaginary part: {c.Imaginary}");
        System.Console.WriteLine($"Magnitude: {c.Magnitude}");
        System.Console.WriteLine($"Phase (radians): {c.Phase}");
        System.Console.WriteLine($"Phase (degrees): {c.Phase * 180 / Math.PI}°");
        System.Console.WriteLine($"Conjugate: {c.Conjugate}");
        System.Console.WriteLine();
    }

    public static void DemonstrateImplicitConversions()
    {
        System.Console.WriteLine("4. IMPLICIT CONVERSIONS");
        System.Console.WriteLine("-----------------------");

        Complex fromDouble = 3.14;
        Complex fromInt = 42;

        System.Console.WriteLine($"Complex from double (3.14): {fromDouble}");
        System.Console.WriteLine($"Complex from int (42): {fromInt}");

        // Demonstrate mixed arithmetic with implicit conversions
        var c = new Complex(2, 3);
        var result1 = c + 5; // int implicitly converted
        var result2 = 2.5 * c; // double implicitly converted

        System.Console.WriteLine($"(2 + 3i) + 5 = {result1}");
        System.Console.WriteLine($"2.5 * (2 + 3i) = {result2}");
        System.Console.WriteLine();
    }

    public static void DemonstrateStaticMethods()
    {
        System.Console.WriteLine("5. STATIC METHODS");
        System.Console.WriteLine("-----------------");

        // FromPolar
        var polar = Complex.FromPolar(2, Math.PI / 4);
        System.Console.WriteLine($"FromPolar(2, π/4) = {polar}");
        System.Console.WriteLine($"Verification: magnitude = {polar.Magnitude:F4}, phase = {polar.Phase:F4}");
        System.Console.WriteLine();

        // Square root
        var negOne = new Complex(-1);
        var sqrtNegOne = Complex.Sqrt(negOne);
        System.Console.WriteLine($"√(-1) = {sqrtNegOne}");
        System.Console.WriteLine();

        // Power
        var i = Complex.ImaginaryOne;
        System.Console.WriteLine($"i^0 = {Complex.Pow(i, 0)}");
        System.Console.WriteLine($"i^1 = {Complex.Pow(i, 1)}");
        System.Console.WriteLine($"i^2 = {Complex.Pow(i, 2)}");
        System.Console.WriteLine($"i^3 = {Complex.Pow(i, 3)}");
        System.Console.WriteLine($"i^4 = {Complex.Pow(i, 4)}");
        System.Console.WriteLine();

        // Exponential and logarithm
        var c = new Complex(1, Math.PI / 2);
        System.Console.WriteLine($"e^(1 + iπ/2) = {Complex.Exp(c)}");
        System.Console.WriteLine($"ln(e) = {Complex.Log(new Complex(Math.E))}");
        System.Console.WriteLine();
    }

  

    public static void RunInteractiveCalculator()
    {
        System.Console.WriteLine("7. INTERACTIVE CALCULATOR");
        System.Console.WriteLine("-------------------------");
        System.Console.WriteLine("Enter complex numbers in the format 'a+bi' or 'a-bi'");
        System.Console.WriteLine("Type 'quit' to exit\n");

        while (true)
        {
            System.Console.Write("Enter first complex number (or 'quit'): ");
            var input1 = System.Console.ReadLine();

            if (input1?.ToLower() == "quit")
            {
                break;
            }

            if (!TryParseComplex(input1, out var c1))
            {
                System.Console.WriteLine("Invalid format. Try again.");
                continue;
            }

            System.Console.Write("Enter operation (+, -, *, /): ");
            var operation = System.Console.ReadLine();

            System.Console.Write("Enter second complex number: ");
            var input2 = System.Console.ReadLine();

            if (!TryParseComplex(input2, out var c2))
            {
                System.Console.WriteLine("Invalid format. Try again.");
                continue;
            }

            var result = operation switch
                         {
                             "+" => c1 + c2,
                             "-" => c1 - c2,
                             "*" => c1 * c2,
                             "/" => c1 / c2,
                             _ => Complex.Zero
                         };

            if (operation is "+" or "-" or "*" or "/")
            {
                System.Console.WriteLine($"Result: {c1} {operation} {c2} = {result}\n");
            }
            else
            {
                System.Console.WriteLine("Invalid operation. Try again.\n");
            }
        }

        System.Console.WriteLine("\nThank you for using the Complex Number Calculator!");
    }

    private static bool TryParseComplex(string? input, out Complex result)
    {
        result = Complex.Zero;

        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        input = input.Replace(" ", "").ToLower();

        // Handle pure real numbers
        if (!input.Contains('i'))
        {
            if (double.TryParse(input, out var real))
            {
                result = new Complex(real);
                return true;
            }

            return false;
        }

        // Handle pure imaginary numbers
        if (input == "i")
        {
            result = Complex.ImaginaryOne;
            return true;
        }

        if (input == "-i")
        {
            result = -Complex.ImaginaryOne;
            return true;
        }

        // Handle general case: a+bi or a-bi
        var lastPlus = input.LastIndexOf('+');
        var lastMinus = input.LastIndexOf('-', input.Length - 1, input.Length - 1);

        if (lastPlus == -1 && lastMinus <= 0)
        {
            // Pure imaginary like "3i" or "-3i"
            var imagStr = input.Replace("i", "");
            if (double.TryParse(imagStr, out var imag))
            {
                result = new Complex(0, imag);
                return true;
            }

            return false;
        }

        var splitPos = Math.Max(lastPlus, lastMinus);
        if (splitPos <= 0)
        {
            return false;
        }

        var realPart = input.Substring(0, splitPos);
        var imagPart = input.Substring(splitPos).Replace("i", "");

        if (imagPart == "+" || imagPart == "-")
        {
            imagPart += "1";
        }

        if (double.TryParse(realPart, out var r) && double.TryParse(imagPart, out var i))
        {
            result = new Complex(r, i);
            return true;
        }

        return false;
    }

    private static bool IsApproximatelyZero(Complex c)
    {
        const double tolerance = 1e-10;
        return Math.Abs(c.Real) < tolerance && Math.Abs(c.Imaginary) < tolerance;
    }
}