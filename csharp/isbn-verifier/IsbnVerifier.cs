using System.Linq;
using System.Text.RegularExpressions;

public static class IsbnVerifier
{
    public static bool IsValid(string number)
    {
        var numbers = Regex.Matches(number, @"\d").Select(n => int.Parse(n.Value)).ToList();

        if (number.LastOrDefault() == 'X') numbers.Add(10);
        if (numbers.Count != 10) return false;

        return numbers.Select((n, i) => n * (10 - i)).Sum() % 11 == 0;
    }
}