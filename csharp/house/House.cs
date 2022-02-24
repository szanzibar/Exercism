using System;
using System.Collections.Generic;

public static class House
{

    public static string Recite(int verseNumber)
    {
        (string verb, string noun)[] verses =
        {
            ("lay in","house that Jack built"),
            ("ate", "malt"),
            ("killed", "rat"),
            ("worried", "cat"),
            ("tossed", "dog"),
            ("milked", "cow with the crumpled horn"),
            ("kissed", "maiden all forlorn"),
            ("married", "man all tattered and torn"),
            ("woke", "priest all shaven and shorn"),
            ("kept", "rooster that crowed in the morn"),
            ("belonged to", "farmer sowing his corn" ),
            ("", "horse and the hound and the horn")
        };

        var constructedVerse = $"This is the {verses[verseNumber - 1].noun} ";
        for (var i = verseNumber - 2; i >= 0; i--)
        {
            constructedVerse += $"that {verses[i].verb} the {verses[i].noun} ";
        }
        return constructedVerse.Trim() + ".";
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var song = "";
        for (var i = startVerse; i <= endVerse; i++)
        {
            song += Recite(i) + "\n";
        }
        return song.Trim();
    }
}