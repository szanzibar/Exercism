using System;
using System.Numerics;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64) throw new ArgumentOutOfRangeException();

        return (ulong)BigInteger.Pow(2, n-1);
    }

    public static ulong Total()
    {
        return (ulong)(BigInteger.Pow(2, 64) -1);
    }
}