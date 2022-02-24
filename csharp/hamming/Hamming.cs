using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException(
                $"Length of first strand ({firstStrand.Length}) does not match length of second strand ({secondStrand.Length})");
        }

        return firstStrand.Where((c, i) => c != secondStrand[i]).Count();
    }
}