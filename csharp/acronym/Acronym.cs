using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        char[] separators = {' ', '-'};
        var acronym = string.Concat(phrase
                .Split(separators)
                .Where(word => word.Any(char.IsLetter))
                .Select(word => word.First(char.IsLetter)))
            .ToUpper();
        return acronym;
    }
}