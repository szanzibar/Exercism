using System;
using System.Collections.Generic;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2) throw new ArgumentOutOfRangeException();
        var sieve = new Dictionary<int, bool?>();
        for(var i = 2; i<=limit; i++)
        {
            if (!sieve.ContainsKey(i))
            {
                sieve[i] = true;
                for (var j = i+i; j<=limit; j += i)
                {
                    sieve[j] = false;
                }
                
            }
            
        }
        return sieve.Where(x => x.Value == true).Select(x => x.Key).ToArray();
    }
}