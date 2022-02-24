using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    public static int Score(string input)
    {
        var values = new Dictionary<int, string>()
        {
            {1, "aeioulnrst" },
            {2, "dg" },
            {3, "bcmp"},
            {4, "fhvwy" },
            {5, "k" },
            {8, "jx" },
            {10, "qz" }
        };

        var score = 0;
        foreach (char letter in input.ToLower())
        {
            score += values.Where(v => v.Value.Contains(letter)).FirstOrDefault().Key;
        }

        return score;
    }
}