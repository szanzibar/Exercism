using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        var phoneNumberRegex = @"^1?([2-9]\d\d[2-9]\d{6})$";
        var match = Regex.Match(string.Concat(phoneNumber.Where(char.IsDigit)), phoneNumberRegex);
        return match.Success ? match.Groups[1].ToString() : throw new ArgumentException("Invalid Phone Number");
    }
}