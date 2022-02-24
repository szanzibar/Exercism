using System;
using System.Collections.Generic;
using System.Linq;

public static class Raindrops
{
    private static readonly Dictionary<int, string> RainDrops = new Dictionary<int, string>()
    {
        {3, "Pling"},
        {5, "Plang"},
        {7, "Plong"}
    };

    public static string Convert(int number) =>
        String.Concat(RainDrops
            .Where(x => number % x.Key == 0)
            .Select(x => x.Value)
            .DefaultIfEmpty(number.ToString()));
}