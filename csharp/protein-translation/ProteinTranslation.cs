using System;
using System.Collections.Generic;
using System.Linq;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        var codons = NucleotideToCodons(strand);
        return CodonsToProteins(codons);
    }

    private static string[] CodonsToProteins(string[] codons)
    {
        var proteins = new List<string>();
        foreach (var codon in codons)
        {
            switch (codon)
            {
                case "AUG":
                    proteins.Add("Methionine");
                    break;
                case "UUU":
                case "UUC":
                    proteins.Add("Phenylalanine");
                    break;
                case "UUA":
                case "UUG":
                    proteins.Add("Leucine");
                    break;
                case "UCU":
                case "UCC":
                case "UCA":
                case "UCG":
                    proteins.Add("Serine");
                    break;
                case "UAU":
                case "UAC":
                    proteins.Add("Tyrosine");
                    break;
                case "UGU":
                case "UGC":
                    proteins.Add("Cysteine");
                    break;
                case "UGG":
                    proteins.Add("Tryptophan");
                    break;
                case "UAA":
                case "UAG":
                case "UGA":
                    return proteins.ToArray();
                default:
                    break;
            };
        }
        return proteins.ToArray();
    }

    private static string[] NucleotideToCodons(string strand)
    {
        var codonCount = strand.Length / 3;
        var codons = new string[codonCount];

        for (var i = 0; i < codonCount; i++)
        {
            codons[i] = strand.Substring(i * 3, 3);
        }
        return codons;
    }
}