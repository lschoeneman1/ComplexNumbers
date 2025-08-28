using System;
using System.Text;
using System.Globalization;

namespace ComplexNumbers.Library
{
    /// <summary>
    /// Represents a complex number with real and imaginary parts.
    /// Demonstrates good class design principles and operator overloading.
    /// </summary>
    public class Complex : IEquatable<Complex>, IFormattable
    {
        #region Properties

        /// <summary>
        /// Gets the real part of the complex number.
        /// </summary>
        public double Real { get; }

        /// <summary>
        /// Gets the imaginary part of the complex number.
        /// </summary>
        public double Imaginary { get; }

        /// <summary>
        /// Gets the magnitude (modulus) of the complex number.
        /// </summary>
        public double Magnitude => Math.Sqrt(Real * Real + Imaginary * Imaginary);

        /// <summary>
        /// Gets the phase (argument) of the complex number in radians.
        /// </summary>
        public double Phase => Math.Atan2(Imaginary, Real);

        /// <summary>
        /// Gets the complex conjugate.
        /// </summary>
        public Complex Conjugate => new Complex(Real, -Imaginary);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Complex class.
        /// </summary>
        /// <param name="real">The real part.</param>
        /// <param name="imaginary">The imaginary part.</param>
        public Complex(double real, double imaginary = 0)
        {
            Real = real;
            Imaginary = imaginary;
        }

        #endregion

        #region Static Properties

        /// <summary>
        /// Gets the complex number zero (0 + 0i).
        /// </summary>
        public static Complex Zero => new Complex(0, 0);

        /// <summary>
        /// Gets the complex number one (1 + 0i).
        /// </summary>
        public static Complex One => new Complex(1, 0);

        /// <summary>
        /// Gets the imaginary unit (0 + 1i).
        /// </summary>
        public static Complex ImaginaryOne => new Complex(0, 1);

        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Adds two complex numbers.
        /// </summary>
        public static Complex operator +(Complex left, Complex right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            if (right is null) throw new ArgumentNullException(nameof(right));

            return new Complex(left.Real + right.Real, left.Imaginary + right.Imaginary);
        }

        /// <summary>
        /// Subtracts one complex number from another.
        /// </summary>
        public static Complex operator -(Complex left, Complex right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            if (right is null) throw new ArgumentNullException(nameof(right));

            return new Complex(left.Real - right.Real, left.Imaginary - right.Imaginary);
        }

        /// <summary>
        /// Multiplies two complex numbers.
        /// </summary>
        public static Complex operator *(Complex left, Complex right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            if (right is null) throw new ArgumentNullException(nameof(right));

            // (a + bi) * (c + di) = (ac - bd) + (ad + bc)i
            double real = left.Real * right.Real - left.Imaginary * right.Imaginary;
            double imaginary = left.Real * right.Imaginary + left.Imaginary * right.Real;

            return new Complex(real, imaginary);
        }

        /// <summary>
        /// Divides one complex number by another.
        /// </summary>
        public static Complex operator /(Complex left, Complex right)
        {
            if (left is null) throw new ArgumentNullException(nameof(left));
            if (right is null) throw new ArgumentNullException(nameof(right));

            double denominator = right.Real * right.Real + right.Imaginary * right.Imaginary;
            
            if (Math.Abs(denominator) < double.Epsilon)
                throw new DivideByZeroException("Cannot divide by zero complex number.");

            double real = (left.Real * right.Real + left.Imaginary * right.Imaginary) / denominator;
            double imaginary = (left.Imaginary * right.Real - left.Real * right.Imaginary) / denominator;

            return new Complex(real, imaginary);
        }

        /// <summary>
        /// Negates a complex number.
        /// </summary>
        public static Complex operator -(Complex value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            return new Complex(-value.Real, -value.Imaginary);
        }

        #endregion

        #region Implicit Conversions

        /// <summary>
        /// Implicitly converts a real number to a complex number.
        /// </summary>
        public static implicit operator Complex(double real)
        {
            return new Complex(real, 0);
        }

        /// <summary>
        /// Implicitly converts an integer to a complex number.
        /// </summary>
        public static implicit operator Complex(int real)
        {
            return new Complex(real, 0);
        }

        #endregion

        #region Equality Operators and Methods

        /// <summary>
        /// Determines whether two complex numbers are equal.
        /// </summary>
        public static bool operator ==(Complex left, Complex? right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        /// <summary>
        /// Determines whether two complex numbers are not equal.
        /// </summary>
        public static bool operator !=(Complex left, Complex right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Determines whether this instance is equal to another complex number.
        /// </summary>
        public bool Equals(Complex? other)
        {
            if (other is null) return false;
            
            const double tolerance = 1e-10;
            return Math.Abs(Real - other.Real) < tolerance && 
                   Math.Abs(Imaginary - other.Imaginary) < tolerance;
        }

        /// <summary>
        /// Determines whether this instance is equal to a specified object.
        /// </summary>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Complex);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }

        #endregion

        #region String Representation

        /// <summary>
        /// Returns a string representation of the complex number.
        /// </summary>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a string representation of the complex number using the specified format.
        /// </summary>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Returns a string representation of the complex number using the specified format and provider.
        /// </summary>
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            if (string.IsNullOrEmpty(format)) 
                format = "G";
            
            if (formatProvider == null) 
                formatProvider = CultureInfo.CurrentCulture;
            
            var sb = new StringBuilder();
            
            // Handle special cases
            if (Math.Abs(Real) < double.Epsilon && Math.Abs(Imaginary) < double.Epsilon)
                return "0";
            
            if (Math.Abs(Imaginary) < double.Epsilon)
                return Real.ToString(format, formatProvider);
            
            if (Math.Abs(Real) < double.Epsilon)
            {
                if (Math.Abs(Imaginary - 1) < double.Epsilon)
                    return "i";
                if (Math.Abs(Imaginary + 1) < double.Epsilon)
                    return "-i";
                return $"{Imaginary.ToString(format, formatProvider)}i";
            }
            
            // General case: a + bi or a - bi
            sb.Append(Real.ToString(format, formatProvider));
            
            if (Imaginary > 0)
            {
                sb.Append(" + ");
                if (Math.Abs(Imaginary - 1) > double.Epsilon)
                    sb.Append(Imaginary.ToString(format, formatProvider));
            }
            else
            {
                sb.Append(" - ");
                if (Math.Abs(Imaginary + 1) > double.Epsilon)
                    sb.Append(Math.Abs(Imaginary).ToString(format, formatProvider));
            }
            sb.Append('i');
            
            return sb.ToString();
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Creates a complex number from polar coordinates.
        /// </summary>
        /// <param name="magnitude">The magnitude (modulus).</param>
        /// <param name="phase">The phase (argument) in radians.</param>
        public static Complex FromPolar(double magnitude, double phase)
        {
            return new Complex(
                magnitude * Math.Cos(phase),
                magnitude * Math.Sin(phase)
            );
        }

        /// <summary>
        /// Computes the square root of a complex number.
        /// </summary>
        public static Complex Sqrt(Complex value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            
            double magnitude = Math.Sqrt(value.Magnitude);
            double phase = value.Phase / 2;
            return FromPolar(magnitude, phase);
        }

        /// <summary>
        /// Raises a complex number to a power.
        /// </summary>
        public static Complex Pow(Complex value, double exponent)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            
            double magnitude = Math.Pow(value.Magnitude, exponent);
            double phase = value.Phase * exponent;
            return FromPolar(magnitude, phase);
        }

        /// <summary>
        /// Computes the exponential of a complex number.
        /// </summary>
        public static Complex Exp(Complex value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            
            double expReal = Math.Exp(value.Real);
            return new Complex(
                expReal * Math.Cos(value.Imaginary),
                expReal * Math.Sin(value.Imaginary)
            );
        }

        /// <summary>
        /// Computes the natural logarithm of a complex number.
        /// </summary>
        public static Complex Log(Complex value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            
            return new Complex(
                Math.Log(value.Magnitude),
                value.Phase
            );
        }

        #endregion
    }
}
