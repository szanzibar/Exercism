using System.Collections.Generic;

public class MatchingBrackets
{
    private const string OpenBrackets = "[{(";
    private const string CloseBrackets = "]})";

    public static bool IsPaired(string input)
    {
        var bracketStack = new Stack<char>();
        foreach (var c in input)
        {
            if (OpenBrackets.Contains(c)) bracketStack.Push(c);
            if (!CloseBrackets.Contains(c)) continue;

            if (bracketStack.Count == 0 || !IsBracketPair(bracketStack.Pop(), c))
            {
                return false;
            }
        }

        return bracketStack.Count == 0;
    }

    private static bool IsBracketPair(char openBracket, char closeBracket) =>
        openBracket switch
        {
            '[' when closeBracket == ']' => true,
            '{' when closeBracket == '}' => true,
            '(' when closeBracket == ')' => true,
            _ => false
        };
}