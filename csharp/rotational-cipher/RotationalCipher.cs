using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) =>
        new string(text.Select(c =>
        {
            if (char.IsLetter(c))
            {
                var shiftedValue = c + shiftKey;
                if ((char.IsUpper(c) && shiftedValue > 'Z') ||
                    (char.IsLower(c) && shiftedValue > 'z'))
                {
                    return (char)(shiftedValue - 26);
                }

                return (char)shiftedValue;
            }

            return c;
        }).ToArray());
}