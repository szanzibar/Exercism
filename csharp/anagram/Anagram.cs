using System;
using System.Linq;
using System.Collections.Generic;

public class Anagram
{
    private readonly string baseWord;

    public Anagram(string baseWord)
    {
        this.baseWord = baseWord.ToLower();
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        var letterCounts = baseWord.GroupBy(c => c).ToDictionary(c => c.Key, n => n.Count());
        var anagrams = potentialMatches.Where(
            p => p.ToLower() != baseWord &&
            p.ToLower()
            .GroupBy(c => c)
            .ToDictionary(c => c.Key, n => n.Count())
            .Except(letterCounts)
            .Count() == 0)
            .ToArray();
        return anagrams;
    }
}