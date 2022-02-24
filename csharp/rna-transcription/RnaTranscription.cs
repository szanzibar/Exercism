using System;
using System.Linq;

public static class RnaTranscription
{
    public static string ToRna(string dna) => string.Concat(dna.Select(NucleotideDnaToRna));

    private static char NucleotideDnaToRna(char nucleotide) =>
        nucleotide switch
        {
            'G' => 'C',
            'C' => 'G',
            'T' => 'A',
            'A' => 'U',
            _ => throw new ArgumentOutOfRangeException()
        };
}