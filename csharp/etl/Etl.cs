using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var results = new Dictionary<string, int>();
        foreach (var keyValuePair in old)
        {
            foreach (var letter in keyValuePair.Value)
            {
                results.Add(letter.ToLower(), keyValuePair.Key);
            }
        }

        return results;
    }
}