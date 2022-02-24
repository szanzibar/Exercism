using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = IntToDigits(number).ToList();
        var armstrong = digits.Sum(x => Math.Pow(x, digits.Count));
        return armstrong == number;
    }

    private static IEnumerable<int> IntToDigits(int number)
    {
        while (Math.Abs(number) > 0)
        {
            yield return number % 10;
            number /= 10;
        }
    }
}