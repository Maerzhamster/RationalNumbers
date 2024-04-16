using System.Text;

namespace RationalNumbers;

public class Rational
{
    /// <summary>
    /// Initialize a rational number (default as 0)
    /// </summary>
    public Rational()
    {
        Whole = 0;
        Numerator = 0;
        Denominator = 1;
        Negative = false;
    }
    /// <summary>
    /// Initialize a rational number
    /// </summary>
    /// <param name="whole">the "whole" part of the number</param>
    /// <param name="numerator">the numerator of the number</param>
    /// <param name="denominator">the denominator of the number</param>
    /// <exception cref="ArgumentException">the denominator must not be 0</exception>
    public Rational(int whole, int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
        }
        Whole = whole;
        Numerator = numerator;
        Denominator = denominator;
        Negative = false;
        Simplyfy();
    }

    /// <summary>
    /// Initialize a rational number
    /// </summary>
    /// <param name="numerator">the numerator of the number</param>
    /// <param name="denominator">the denominator of the number</param>
    /// <exception cref="ArgumentException">the denominator must not be 0</exception>
    public Rational(int numerator, int denominator) : this(0, numerator, denominator)
    {
    }

    private void Simplyfy()
    {
        if (Denominator < 0)
        {
            Denominator *= -1;
            Numerator *= -1;
        }
        if (Numerator < 0)
        {
            Negative = !Negative;
            Numerator *= -1;
        }
        while (Numerator > 0 && Numerator >= Denominator)
        {
            Numerator -= Denominator;
            Whole++;
        }
        // Shortening
        for (int i = 2; i < Denominator; i++)
        {
            while (Denominator % i == 0 && Numerator % i == 0)
            {
                Denominator /= i;
                Numerator /= i;
            }
        }
        if (Numerator == 0)
        {
            Denominator = 1;
        }
    }

    /// <summary>
    /// The whole part of the number
    /// </summary>
    public int Whole { get; set; }
    /// <summary>
    /// The numerator part of the number
    /// </summary>
    public int Numerator { get; set; }
    /// <summary>
    /// The denominator part of the number
    /// </summary>
    public int Denominator { get; set; }
    /// <summary>
    /// determines if the number is negative
    /// </summary>
    public bool Negative { get; set; }
    /// <summary>
    /// the number
    /// </summary>
    /// <param name="rational">the number</param>
    /// <returns>the number</returns>
    public static Rational operator +(Rational rational) => rational;
    /// <summary>
    /// The negative value of the number
    /// </summary>
    /// <param name="rational">the original number</param>
    /// <returns>the negative value of the number</returns>
    public static Rational operator -(Rational rational)
    {
        Rational copy = (Rational)rational.MemberwiseClone();
        copy.Negative = !rational.Negative;
        return copy;
    }
    private static int ResultingNumerator(Rational rational)
    {
        int num1 = rational.Numerator + rational.Whole * rational.Denominator;
        if (rational.Negative)
        {
            num1 *= -1;
        }
        return num1;
    }
    /// <summary>
    /// returns the sum of two numbers
    /// </summary>
    /// <param name="sum1">the first number</param>
    /// <param name="sum2">the second number</param>
    /// <returns>sum of the two numbers</returns>
    public static Rational operator +(Rational sum1, Rational sum2)
    {
        int num1 = ResultingNumerator(sum1);
        int num2 = ResultingNumerator(sum2);
        return new Rational((num1 * sum2.Denominator + num2 * sum1.Denominator), sum1.Denominator * sum2.Denominator);
    }
    /// <summary>
    /// returns the difference of two numbers
    /// </summary>
    /// <param name="sum1">the first number</param>
    /// <param name="sum2">the second number</param>
    /// <returns>the difference of two numbers</returns>
    public static Rational operator -(Rational sum1, Rational sum2)
    {
        int num1 = ResultingNumerator(sum1);
        int num2 = ResultingNumerator(sum2);
        return new Rational((num1 * sum2.Denominator - num2 * sum1.Denominator), sum1.Denominator * sum2.Denominator);
    }
    /// <summary>
    /// returns the product of two numbers
    /// </summary>
    /// <param name="sum1">the first number</param>
    /// <param name="sum2">the second number</param>
    /// <returns>product of the two numbers</returns>
    public static Rational operator *(Rational sum1, Rational sum2)
    {
        int num1 = ResultingNumerator(sum1);
        int num2 = ResultingNumerator(sum2);
        return new Rational((num1 * num2), sum1.Denominator * sum2.Denominator);
    }
    /// <summary>
    /// returns the division of two numbers
    /// </summary>
    /// <param name="sum1">the first number</param>
    /// <param name="sum2">the second number</param>
    /// <returns>division of the two numbers</returns>
    /// <exception cref="DivideByZeroException">the second number must not be 0</exception>
    public static Rational operator /(Rational sum1, Rational sum2)
    {
        int num1 = ResultingNumerator(sum1);
        int num2 = ResultingNumerator(sum2);
        if (num2 == 0)
        {
            throw new DivideByZeroException();
        }
        return new Rational((num1 * sum2.Denominator), sum1.Denominator * num2);
    }
    public override string ToString()
    {
        StringBuilder myString = new StringBuilder();
        if (Negative) { myString.Append("-");  }
        myString.Append(Whole.ToString());
        double rest = (1.0 * Numerator) / (1.0 * Denominator);
        if (rest > 0)
        {
            myString.Append(".");
            myString.Append(rest.ToString().Substring(2));
        }
        return myString.ToString();
    }
}
