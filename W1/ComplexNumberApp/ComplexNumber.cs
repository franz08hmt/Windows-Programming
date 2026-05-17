// ComplexNumber.cs
// Subject: Windows Programming  |  Topic: OOP - Operator Overloading
// Student: Huynh Minh Tai  |  MSSV: 22110068
using System;
namespace ComplexNumberApp
{
    /// <summary>
    /// Represents a complex number with real and imaginary parts.
    /// Demonstrates OOP concepts: encapsulation, properties, operator overloading.
    /// </summary>
    public class ComplexNumber
    {
        // Private fields (Encapsulation)
        private int _real;
        private int _imaginary;

        // Default constructor
        public ComplexNumber() { }

        // Parameterized constructor
        public ComplexNumber(int real, int imaginary)
        {
            Real      = real;
            Imaginary = imaginary;
        }

        // Property: Real part
        public int Real
        {
            get { return _real; }
            set { _real = value; }
        }

        // Property: Imaginary part
        public int Imaginary
        {
            get { return _imaginary; }
            set { _imaginary = value; }
        }

        // Override ToString() — display format: ( a + bi ) or ( a - bi )
        public override string ToString()
        {
            if (_imaginary < 0)
                return $"( {_real} - {Math.Abs(_imaginary)}i )";
            return $"( {_real} + {_imaginary}i )";
        }

        // Operator overload: Addition
        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(
                x.Real      + y.Real,
                x.Imaginary + y.Imaginary);
        }

        // Static helper method for addition (alternative)
        public static ComplexNumber Add(ComplexNumber x, ComplexNumber y)
        {
            return x + y;
        }

        // Operator overload: Subtraction
        public static ComplexNumber operator -(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(
                x.Real      - y.Real,
                x.Imaginary - y.Imaginary);
        }

        // Static helper method for subtraction (alternative)
        public static ComplexNumber Subtract(ComplexNumber x, ComplexNumber y)
        {
            return x - y;
        }

        // Operator overload: Multiplication
        // Formula: (a+bi)(c+di) = (ac - bd) + (ad + bc)i
        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(
                x.Real * y.Real      - x.Imaginary * y.Imaginary,
                x.Real * y.Imaginary + y.Real      * x.Imaginary);
        }

        // Static helper method for multiplication (alternative)
        public static ComplexNumber Multiply(ComplexNumber x, ComplexNumber y)
        {
            return x * y;
        }
    }
}
