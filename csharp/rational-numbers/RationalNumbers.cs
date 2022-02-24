using System;
using System.Runtime.CompilerServices;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        return r.Expreal(realNumber);
    }
}

public struct RationalNumber
{
    private int _numerator;
    private int _denominator;
    public RationalNumber(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    static int GreatestCommonDivisor(int a, int b)
    {
        return b == 0 ? a : GreatestCommonDivisor(b, a % b);
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._numerator * r2._denominator + r1._denominator * r2._numerator, r1._denominator * r2._denominator).Reduce();
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._numerator * r2._denominator - r1._denominator * r2._numerator, r1._denominator * r2._denominator).Reduce();
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._numerator * r2._numerator, r1._denominator * r2._denominator).Reduce();
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1._numerator * r2._denominator, r2._numerator * r1._denominator).Reduce();
    }

    public RationalNumber Abs()
    {
        return new RationalNumber(_numerator < 0 ? _numerator * -1 : _numerator, _denominator < 0 ? _denominator * -1 : _denominator).Reduce();
    }

    public RationalNumber Reduce()
    {
        var reduced = new RationalNumber(_numerator, _denominator);
        var gcd = GreatestCommonDivisor(reduced._numerator, reduced._denominator);
        if (Math.Abs(gcd) > 1)
        {
            reduced._numerator /= Math.Abs(gcd);
            reduced._denominator /= Math.Abs(gcd);
        }
        if (reduced._denominator < 0) reduced *= new RationalNumber(-1, -1);

        return reduced;
    }

    public RationalNumber Exprational(int power)
    {
        var value = new RationalNumber((int)Math.Pow(_numerator, Math.Abs(power)), (int)Math.Pow(_denominator, Math.Abs(power))).Reduce();
        if (power < 0) value = new RationalNumber(value._denominator, value._numerator);
        return value;
    }

    public double Expreal(int baseNumber)
    {
        return Math.Pow(Math.Pow(baseNumber, _numerator), 1.0 / _denominator);
    }
}