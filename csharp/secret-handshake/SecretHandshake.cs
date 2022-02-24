using System;
using System.Collections.Generic;
using System.Linq;

public static class SecretHandshake
{
    private static readonly Dictionary<int, string> secrets = new Dictionary<int, string>()
        {
            { 0b1,  "wink" },
            { 0b10, "double blink" },
            { 0b100, "close your eyes" },
            { 0b1000, "jump" }
        };
    private static readonly int reverse = 0b10000;

    public static string[] Commands(int commandValue)
    {
        var messages = secrets.Where(s => (s.Key & commandValue) == s.Key).Select(s => s.Value).ToArray();
        if ((reverse & commandValue) == reverse) Array.Reverse(messages);
        return messages;
    }
}
