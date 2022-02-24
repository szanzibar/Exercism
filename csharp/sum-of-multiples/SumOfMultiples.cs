using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max) =>
        Enumerable.Range(0, max)
            .Where(integer => multiples
                .Where(multiple => multiple != 0)
                .Any(multiple => integer % multiple == 0))
            .Sum();
}