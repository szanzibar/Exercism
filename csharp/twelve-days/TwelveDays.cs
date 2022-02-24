using System;
using System.Collections.Generic;
using System.Linq;

public static class TwelveDays
{
    private static readonly IReadOnlyList<string> ordinals = new List<string>() { "first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth" };

    private static readonly IReadOnlyList<string> gifts = new List<string>()
        {
            "a Partridge in a Pear Tree.",
            "two Turtle Doves",
            "three French Hens",
            "four Calling Birds",
            "five Gold Rings",
            "six Geese-a-Laying",
            "seven Swans-a-Swimming",
            "eight Maids-a-Milking",
            "nine Ladies Dancing",
            "ten Lords-a-Leaping",
            "eleven Pipers Piping",
            "twelve Drummers Drumming"
        };

    public static string Recite(int verseNumber)
    {

        var firstHalf = $"On the {ordinals[verseNumber - 1]} day of Christmas my true love gave to me: ";
        var secondHalfSequence = Enumerable.Range(1, verseNumber).Reverse().Select(v => gifts[v - 1]).ToList();
        var secondHalf = verseNumber > 1 ?
            string.Join(", ", secondHalfSequence.SkipLast(1)) + ", and " + secondHalfSequence.Last() :
            secondHalfSequence.First();

        return firstHalf + secondHalf;
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = string.Join('\n', Enumerable.Range(startVerse, endVerse - startVerse + 1).Select(v => Recite(v)));
        return verses;
    }
}