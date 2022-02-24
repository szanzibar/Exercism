using System;
using System.Linq;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var song = "";
        for (var i = startBottles; i > startBottles - takeDown; i--)
        {
            song += Verse(i);
        }

        return song.Trim();
    }

    private static string Verse(int bottleCount)
    {
        var verse = $"{BottlesOfBeer(bottleCount)} on the wall, {BottlesOfBeer(bottleCount)}.\n";
        if (bottleCount == 0)
        {
            verse += "Go to the store and buy some more, 99 bottles of beer on the wall.\n\n";
        }
        else
        {
            verse += $"Take {(bottleCount == 1 ? "it" : "one")} down and pass it around, {BottlesOfBeer(bottleCount - 1)} on the wall.\n\n";
        }
        return verse.ToSentenceCase();
    }

    private static string BottlesOfBeer(int bottleCount)
    {
        return bottleCount switch
        {
            0 => $"no more bottles of beer",
            1 => $"{bottleCount} bottle of beer",
            _ => $"{bottleCount} bottles of beer",
        };
    }

    private static string ToSentenceCase(this string sentence)
    {
        return char.ToUpper(sentence[0]) + sentence.Substring(1);
    }
}