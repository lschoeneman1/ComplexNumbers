# Complex Numbers Library in C#

A comprehensive implementation of complex numbers in C# demonstrating:
- Good object-oriented design principles
- Operator overloading
- Unit testing with xUnit
- Interactive console application

## Project Structure

```
ComplexNumbers/
├── ComplexNumbers.sln                 # Solution file
├── ComplexNumbers.Library/            # Core library
│   ├── Complex.cs                     # Complex number class
│   └── ComplexNumbers.Library.csproj  # Library project file
├── ComplexNumbers.Tests/              # Unit tests
│   ├── ComplexTests.cs                # Test cases
│   └── ComplexNumbers.Tests.csproj    # Test project file
└── ComplexNumbers.Console/            # Driver program
    ├── Program.cs                      # Console application
    └── ComplexNumbers.Console.csproj  # Console project file
```

## Prerequisites

- .NET 8.0 SDK or later
- Command line access

## Building and Running with .NET CLI

### 1. Navigate to the project directory
```bash
cd "F:\Dropbox\Teaching\Coding Samples\CSCI473\ComplexNumbers"
```

### 2. Restore NuGet packages
```bash
dotnet restore
```

### 3. Build the entire solution
```bash
dotnet build
```

### 4. Run the unit tests
```bash
dotnet test
```

To see more detailed test output:
```bash
dotnet test --logger "console;verbosity=detailed"
```

### 5. Run the console application
```bash
dotnet run --project ComplexNumbers.Console
```

## Individual Project Commands

### Build only the library
```bash
dotnet build ComplexNumbers.Library
```

### Build and run tests with coverage (optional)
```bash
dotnet test --collect:"XPlat Code Coverage"
```

### Create a release build
```bash
dotnet build --configuration Release
```

### Publish the console app (creates standalone executable)
```bash
dotnet publish ComplexNumbers.Console -c Release -r win-x64 --self-contained
```

## Features Demonstrated

### Complex Number Class
- **Immutable design**: All properties are read-only
- **Operator overloading**: +, -, *, /, == , !=, unary -
- **Implicit conversions**: From int and double
- **Properties**: Real, Imaginary, Magnitude, Phase, Conjugate
- **Static factory methods**: FromPolar, Zero, One, ImaginaryOne
- **Mathematical functions**: Sqrt, Pow, Exp, Log
- **IEquatable<Complex>** and **IFormattable** interfaces
- **Comprehensive XML documentation**

### Unit Tests
- **71 test cases** covering:
  - Constructor behavior
  - All arithmetic operations
  - Edge cases and error conditions
  - Mathematical identities (Euler's identity, De Moivre's theorem)
  - String formatting
  - Equality comparisons

### Console Application
- Demonstrates all class features
- Interactive calculator mode
- Complex number parsing
- Mathematical identity verification

## Design Principles

1. **Immutability**: Complex numbers are immutable for thread safety and predictable behavior
2. **Operator Overloading**: Natural mathematical syntax (c1 + c2 instead of c1.Add(c2))
3. **Defensive Programming**: Null checks and division by zero protection
4. **Documentation**: Complete XML documentation for IntelliSense
5. **Testing**: Comprehensive unit test coverage
6. **SOLID Principles**: Single responsibility, proper abstraction

## Usage Example

```csharp
using ComplexNumbers.Library;

// Create complex numbers
var c1 = new Complex(3, 4);      // 3 + 4i
var c2 = new Complex(1, -2);     // 1 - 2i
Complex c3 = 5;                  // Implicit conversion from double

// Arithmetic operations
var sum = c1 + c2;               // 4 + 2i
var product = c1 * c2;           // 11 - 2i
var quotient = c1 / c2;          // -1 + 2i

// Properties
double magnitude = c1.Magnitude;  // 5
double phase = c1.Phase;          // 0.9273 radians
var conjugate = c1.Conjugate;    // 3 - 4i

// Static methods
var fromPolar = Complex.FromPolar(2, Math.PI/4);  // √2 + √2i
var sqrt = Complex.Sqrt(new Complex(-1, 0));      // i
```

## Testing

The test suite includes:
- Basic operation tests
- Edge case handling
- Mathematical identity verification
- Property calculations
- String formatting tests
- Null handling
- Exception cases

Run tests to verify all functionality:
```bash
dotnet test --verbosity normal
```

## Notes

- The solution uses .NET 8.0 features
- All warnings are treated as errors in the library project
- The console app includes an interactive calculator for testing
- XML documentation is generated for the library

## License

This is an educational example for CSCI473.
