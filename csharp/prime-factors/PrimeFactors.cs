using System;
using System.Collections.Generic;

public static class PrimeFactors
{
    public static long[] Factors(long number)
    {
        var factors = new List<long>();
        for (int i = 2; i <= number; i++)
        {
            if (number % i == 0)
            {
                factors.Add(i);
                number /= i;
                i--;
            }
        }
        return factors.ToArray();
    }
}