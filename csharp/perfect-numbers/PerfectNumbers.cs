using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect = 0,
    Abundant = 1,
    Deficient = -1
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1) throw new ArgumentOutOfRangeException();
        return (Classification)number.FactorsExcludingSelf().Sum().CompareTo(number);
    }

    private static IEnumerable<int> FactorsExcludingSelf(this int number)
    {
        if (number <= 1) yield break;
        yield return 1;
        var max = (int)Math.Sqrt(number);
        for (var i = 2; i <= max; i++)
        {
            if (number % i == 0)
            {
                yield return i;
                if (number / i != i)
                {
                    yield return number / i;
                }
            }
        }
    }
}