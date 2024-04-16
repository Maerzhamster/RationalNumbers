using RationalNumbers;

namespace RationalTest;

public class RationalCalculationTest
{
    [TestCase(1, 1, 1)]
    [TestCase(0, -1, 1)]
    [TestCase(0, 2, 3)]
    public void NegativeValue(int whole, int num, int den)
    {
        Rational rational = new Rational(whole, num, den);
        Rational rational2 = -rational;
        Assert.That(rational2.Whole, Is.EqualTo(rational.Whole));
        Assert.That(rational2.Numerator, Is.EqualTo(rational.Numerator));
        Assert.That(rational2.Denominator, Is.EqualTo(rational.Denominator));
        Assert.That(rational.Negative, Is.Not.EqualTo(rational2.Negative));
    }

    [TestCase(10, 2, 5, 0, 1, false)]
    [TestCase(-10, 20, 0, 1, 2, true)]
    [TestCase(252, 123, 2, 2, 41, false)]
    public void Shortening(int num, int den, int exp_whole, int exp_num, int exp_den, bool exp_neg)
    {
        Rational rational = new Rational(num, den);
        Assert.That(rational.Whole, Is.EqualTo(exp_whole));
        Assert.That(rational.Numerator, Is.EqualTo(exp_num));
        Assert.That(rational.Denominator, Is.EqualTo(exp_den));
        Assert.That(rational.Negative, Is.EqualTo(exp_neg));
    }

    [TestCase(1, 2, 3, 4, 1, 1, 4, false)]
    [TestCase(5, 4, 7, 6, 2, 5, 12, false)]
    [TestCase(5, 4, -7, 6, 0, 1, 12, false)]
    public void Plus(int num, int den, int num2, int den2, int exp_whole, int exp_num, int exp_den, bool exp_neg)
    {
        Rational rational1 = new Rational(num, den);
        Rational rational2 = new Rational(num2, den2);
        Rational summe = rational1 + rational2;
        Assert.That(summe.Whole, Is.EqualTo(exp_whole));
        Assert.That(summe.Numerator, Is.EqualTo(exp_num));
        Assert.That(summe.Denominator, Is.EqualTo(exp_den));
        Assert.That(summe.Negative, Is.EqualTo(exp_neg));
    }

    [TestCase(5, 4, 7, 6, 0, 1, 12, false)]
    [TestCase(7, 6, 5, 4, 0, 1, 12, true)]
    public void Minus(int num, int den, int num2, int den2, int exp_whole, int exp_num, int exp_den, bool exp_neg)
    {
        Rational rational1 = new Rational(num, den);
        Rational rational2 = new Rational(num2, den2);
        Rational differenz = rational1 - rational2;
        Assert.That(differenz.Whole, Is.EqualTo(exp_whole));
        Assert.That(differenz.Numerator, Is.EqualTo(exp_num));
        Assert.That(differenz.Denominator, Is.EqualTo(exp_den));
        Assert.That(differenz.Negative, Is.EqualTo(exp_neg));
    }
    [TestCase(1, 2, 3, 4, 0, 3, 8, false)]
    [TestCase(5, 2, 2, 4, 1, 1, 4, false)]
    [TestCase(-5, 2, 2, 4, 1, 1, 4, true)]
    [TestCase(-5, 2, -2, 4, 1, 1, 4, false)]
    public void Mal(int num, int den, int num2, int den2, int exp_whole, int exp_num, int exp_den, bool exp_neg)
    {
        Rational rational1 = new Rational(num, den);
        Rational rational2 = new Rational(num2, den2);
        Rational differenz = rational1 * rational2;
        Assert.That(differenz.Whole, Is.EqualTo(exp_whole));
        Assert.That(differenz.Numerator, Is.EqualTo(exp_num));
        Assert.That(differenz.Denominator, Is.EqualTo(exp_den));
        Assert.That(differenz.Negative, Is.EqualTo(exp_neg));
    }
    [TestCase(1, 2, 3, 4, 0, 2, 3, false)]
    [TestCase(1, 2, -3, 4, 0, 2, 3, true)]
    [TestCase(-1, 2, -3, 4, 0, 2, 3, false)]
    public void Geteilt(int num, int den, int num2, int den2, int exp_whole, int exp_num, int exp_den, bool exp_neg)
    {
        Rational rational1 = new Rational(num, den);
        Rational rational2 = new Rational(num2, den2);
        Rational differenz = rational1 / rational2;
        Assert.That(differenz.Whole, Is.EqualTo(exp_whole));
        Assert.That(differenz.Numerator, Is.EqualTo(exp_num));
        Assert.That(differenz.Denominator, Is.EqualTo(exp_den));
        Assert.That(differenz.Negative, Is.EqualTo(exp_neg));
    }
    [TestCase(0, 3, 4, "0.75")]
    [TestCase(2, -2, 4, "-2.5")]
    [TestCase(1, 4, 6, "1.6666666666666666")]
    public void StringCheck(int whole, int num, int den, string expected_str)
    {
        Rational rational = new Rational(whole, num, den);
        Assert.That(rational.ToString(), Is.EqualTo(expected_str));
    }
}