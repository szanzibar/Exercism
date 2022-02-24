using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        if (sequence.Except("ACGT").Count() > 0)
            throw new ArgumentException();

        return (sequence + "ACGT")
            .GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count() - 1);
    }
}