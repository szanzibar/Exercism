using System.Linq;

public static class Pangram
{
    private const string AllLetters = "abcdefghijklmnopqrstuvwxyz";

    public static bool IsPangram(string input) => AllLetters.All(input.ToLower().Contains);
}