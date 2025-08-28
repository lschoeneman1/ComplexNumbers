using System;
using Xunit;
using ComplexNumbers.Library;

namespace ComplexNumbers.Tests
{
    public class ComplexTests
    {
        private const double Tolerance = 1e-10;

        #region Constructor Tests

        [Fact]
        public void Constructor_WithRealAndImaginary_SetsCorrectValues()
        {
            // Arrange & Act
            var complex = new Complex(3.5, -2.1);

            // Assert
            Assert.Equal(3.5, complex.Real);
            Assert.Equal(-2.1, complex.Imaginary);
        }

        [Fact]
        public void Constructor_WithOnlyReal_SetsImaginaryToZero()
        {
            // Arrange & Act
            var complex = new Complex(5.0);

            // Assert
            Assert.Equal(5.0, complex.Real);
            Assert.Equal(0.0, complex.Imaginary);
        }

        #endregion

        #region Static Properties Tests

        [Fact]
        public void Zero_ReturnsCorrectValue()
        {
            // Arrange & Act
            var zero = Complex.Zero;

            // Assert
            Assert.Equal(0, zero.Real);
            Assert.Equal(0, zero.Imaginary);
        }

        [Fact]
        public void One_ReturnsCorrectValue()
        {
            // Arrange & Act
            var one = Complex.One;

            // Assert
            Assert.Equal(1, one.Real);
            Assert.Equal(0, one.Imaginary);
        }

        [Fact]
        public void ImaginaryOne_ReturnsCorrectValue()
        {
            // Arrange & Act
            var i = Complex.ImaginaryOne;

            // Assert
            Assert.Equal(0, i.Real);
            Assert.Equal(1, i.Imaginary);
        }

        #endregion

        #region Property Tests

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(5, 12, 13)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 1, 1)]
        public void Magnitude_CalculatedCorrectly(double real, double imaginary, double expectedMagnitude)
        {
            // Arrange
            var complex = new Complex(real, imaginary);

            // Act
            var magnitude = complex.Magnitude;

            // Assert
            Assert.Equal(expectedMagnitude, magnitude, Tolerance);
        }

        [Fact]
        public void Phase_CalculatedCorrectly()
        {
            // Arrange
            var complex = new Complex(1, 1);

            // Act
            var phase = complex.Phase;

            // Assert
            Assert.Equal(Math.PI / 4, phase, Tolerance);
        }

        [Fact]
        public void Conjugate_ReturnsCorrectValue()
        {
            // Arrange
            var complex = new Complex(3, 4);

            // Act
            var conjugate = complex.Conjugate;

            // Assert
            Assert.Equal(3, conjugate.Real);
            Assert.Equal(-4, conjugate.Imaginary);
        }

        #endregion

        #region Addition Tests

        [Fact]
        public void Addition_TwoComplexNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var c1 = new Complex(3, 4);
            var c2 = new Complex(1, 2);

            // Act
            var result = c1 + c2;

            // Assert
            Assert.Equal(4, result.Real);
            Assert.Equal(6, result.Imaginary);
        }

        [Fact]
        public void Addition_WithNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            var c1 = new Complex(-2, 3);
            var c2 = new Complex(5, -7);

            // Act
            var result = c1 + c2;

            // Assert
            Assert.Equal(3, result.Real);
            Assert.Equal(-4, result.Imaginary);
        }

        #endregion

        #region Subtraction Tests

        [Fact]
        public void Subtraction_TwoComplexNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            var c1 = new Complex(5, 7);
            var c2 = new Complex(2, 3);

            // Act
            var result = c1 - c2;

            // Assert
            Assert.Equal(3, result.Real);
            Assert.Equal(4, result.Imaginary);
        }

        #endregion

        #region Multiplication Tests

        [Fact]
        public void Multiplication_TwoComplexNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            var c1 = new Complex(3, 2);
            var c2 = new Complex(1, 4);

            // Act
            var result = c1 * c2;

            // Assert
            // (3 + 2i) * (1 + 4i) = 3 + 12i + 2i + 8i² = 3 + 14i - 8 = -5 + 14i
            Assert.Equal(-5, result.Real);
            Assert.Equal(14, result.Imaginary);
        }

        [Fact]
        public void Multiplication_ByImaginaryUnit_RotatesBy90Degrees()
        {
            // Arrange
            var c = new Complex(1, 0);
            var i = Complex.ImaginaryOne;

            // Act
            var result = c * i;

            // Assert
            Assert.Equal(0, result.Real, Tolerance);
            Assert.Equal(1, result.Imaginary, Tolerance);
        }

        #endregion

        #region Division Tests

        [Fact]
        public void Division_TwoComplexNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            var c1 = new Complex(4, 2);
            var c2 = new Complex(2, 0);

            // Act
            var result = c1 / c2;

            // Assert
            Assert.Equal(2, result.Real);
            Assert.Equal(1, result.Imaginary);
        }

        [Fact]
        public void Division_ByZero_ThrowsException()
        {
            // Arrange
            var c1 = new Complex(1, 1);
            var c2 = Complex.Zero;

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => c1 / c2);
        }

        #endregion

        #region Negation Tests

        [Fact]
        public void Negation_ReturnsCorrectValue()
        {
            // Arrange
            var c = new Complex(3, -4);

            // Act
            var result = -c;

            // Assert
            Assert.Equal(-3, result.Real);
            Assert.Equal(4, result.Imaginary);
        }

        #endregion

        #region Implicit Conversion Tests

        [Fact]
        public void ImplicitConversion_FromDouble_CreatesComplexNumber()
        {
            // Arrange & Act
            Complex c = 5.5;

            // Assert
            Assert.Equal(5.5, c.Real);
            Assert.Equal(0, c.Imaginary);
        }

        [Fact]
        public void ImplicitConversion_FromInt_CreatesComplexNumber()
        {
            // Arrange & Act
            Complex c = 42;

            // Assert
            Assert.Equal(42, c.Real);
            Assert.Equal(0, c.Imaginary);
        }

        #endregion

        #region Equality Tests

        [Fact]
        public void Equals_SameValues_ReturnsTrue()
        {
            // Arrange
            var c1 = new Complex(3.14, 2.71);
            var c2 = new Complex(3.14, 2.71);

            // Act & Assert
            Assert.True(c1.Equals(c2));
            Assert.True(c1 == c2);
            Assert.False(c1 != c2);
        }

        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            // Arrange
            var c1 = new Complex(3.14, 2.71);
            var c2 = new Complex(2.71, 3.14);

            // Act & Assert
            Assert.False(c1.Equals(c2));
            Assert.False(c1 == c2);
            Assert.True(c1 != c2);
        }

        [Fact]
        public void Equals_WithNull_ReturnsFalse()
        {
            // Arrange
            var c = new Complex(1, 1);

            // Act & Assert
            Assert.False(c.Equals(null));
            Assert.False(c == null);
        }

        [Fact]
        public void GetHashCode_SameValues_ReturnsSameHash()
        {
            // Arrange
            var c1 = new Complex(3.14, 2.71);
            var c2 = new Complex(3.14, 2.71);

            // Act & Assert
            Assert.Equal(c1.GetHashCode(), c2.GetHashCode());
        }

        #endregion

        #region ToString Tests

        [Theory]
        [InlineData(3, 4, "3 + 4i")]
        [InlineData(3, -4, "3 - 4i")]
        [InlineData(-3, 4, "-3 + 4i")]
        [InlineData(-3, -4, "-3 - 4i")]
        [InlineData(3, 1, "3 + i")]
        [InlineData(3, -1, "3 - i")]
        [InlineData(0, 1, "i")]
        [InlineData(0, -1, "-i")]
        [InlineData(5, 0, "5")]
        [InlineData(0, 0, "0")]
        [InlineData(0, 2, "2i")]
        [InlineData(0, -2, "-2i")]
        public void ToString_VariousNumbers_FormatsCorrectly(double real, double imaginary, string expected)
        {
            // Arrange
            var c = new Complex(real, imaginary);

            // Act
            var result = c.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void ToString_WithFormat_UsesSpecifiedFormat()
        {
            // Arrange
            var c = new Complex(3.14159, 2.71828);

            // Act
            var result = c.ToString("F2");

            // Assert
            Assert.Equal("3.14 + 2.72i", result);
        }

        #endregion

        #region Static Methods Tests

        [Fact]
        public void FromPolar_CreatesCorrectComplexNumber()
        {
            // Arrange
            double magnitude = 2;
            double phase = Math.PI / 4; // 45 degrees

            // Act
            var c = Complex.FromPolar(magnitude, phase);

            // Assert
            Assert.Equal(Math.Sqrt(2), c.Real, Tolerance);
            Assert.Equal(Math.Sqrt(2), c.Imaginary, Tolerance);
        }

        [Fact]
        public void Sqrt_CalculatesCorrectly()
        {
            // Arrange
            var c = new Complex(-1, 0); // sqrt(-1) should be i

            // Act
            var result = Complex.Sqrt(c);

            // Assert
            Assert.Equal(0, result.Real, Tolerance);
            Assert.Equal(1, result.Imaginary, Tolerance);
        }

        [Fact]
        public void Pow_CalculatesCorrectly()
        {
            // Arrange
            var c = Complex.ImaginaryOne;

            // Act
            var result = Complex.Pow(c, 2); // i^2 should be -1

            // Assert
            Assert.Equal(-1, result.Real, Tolerance);
            Assert.Equal(0, result.Imaginary, Tolerance);
        }

        [Fact]
        public void Exp_CalculatesCorrectly()
        {
            // Arrange
            var c = new Complex(0, Math.PI); // e^(i*π) should be -1 (Euler's identity)

            // Act
            var result = Complex.Exp(c);

            // Assert
            Assert.Equal(-1, result.Real, Tolerance);
            Assert.Equal(0, result.Imaginary, Tolerance);
        }

        [Fact]
        public void Log_CalculatesCorrectly()
        {
            // Arrange
            var c = new Complex(Math.E, 0); // log(e) should be 1

            // Act
            var result = Complex.Log(c);

            // Assert
            Assert.Equal(1, result.Real, Tolerance);
            Assert.Equal(0, result.Imaginary, Tolerance);
        }

        #endregion

        #region Edge Cases and Complex Scenarios

        [Fact]
        public void MultiplicationDistributivity_HoldsTrue()
        {
            // Arrange
            var a = new Complex(2, 3);
            var b = new Complex(4, -1);
            var c = new Complex(-1, 2);

            // Act
            var left = a * (b + c);
            var right = (a * b) + (a * c);

            // Assert
            Assert.Equal(left.Real, right.Real, Tolerance);
            Assert.Equal(left.Imaginary, right.Imaginary, Tolerance);
        }

        [Fact]
        public void DivisionByConjugate_GivesRealNumber()
        {
            // Arrange
            var c = new Complex(3, 4);

            // Act
            var result = c / c.Conjugate;

            // Assert
            Assert.Equal(-0.28, result.Real, 2); // 7/25 = 0.28
            Assert.Equal(0.96, result.Imaginary, 2); // 24/25 = 0.96
        }

        [Fact]
        public void EulersIdentity_IsValid()
        {
            // Arrange & Act
            // e^(iπ) + 1 = 0
            var eipi = Complex.Exp(new Complex(0, Math.PI));
            var result = eipi + Complex.One;

            // Assert
            Assert.Equal(0, result.Real, Tolerance);
            Assert.Equal(0, result.Imaginary, Tolerance);
        }

        #endregion
    }
}
