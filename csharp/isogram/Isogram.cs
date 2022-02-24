using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var simplifiedWord = Regex.Matches(word.ToLower(), @"\w").Select(x => x.Value);
        return simplifiedWord.Distinct().Count() == simplifiedWord.Count();
    }
}
