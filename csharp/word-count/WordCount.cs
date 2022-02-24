using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase) =>
        Regex.Matches(phrase.ToLower(), @"\b(\w|')+\b")
        .GroupBy(w => w.Value)
        .ToDictionary(w => w.Key, c => c.Select(w => w.Value).Count());
}