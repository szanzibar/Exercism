using System;
using System.Linq;

public static class LargestSeriesProduct
{
    public static long GetLargestProduct(string digits, int span)
    {
        if (!digits.All(d => int.TryParse(d.ToString(), out int result))) throw new ArgumentException();
        if (digits.Length < span || span < 0) throw new ArgumentException();

        double largest = 0;
        for (var i = 0; i <= digits.Length - span; i++)
        {
            var product = digits.Skip(i).Take(span).Select(d => char.GetNumericValue(d)).Aggregate(1, (double x, double y) => x * y);
            largest = product > largest ? product : largest;
        }
        return (long)largest;
    }
}