using System;
using System.Collections.Generic;

public abstract class AllRobots
{
    protected static HashSet<string> allNames = new HashSet<string>();
}

public class Robot : AllRobots
{
    public string Name { get; private set; }

    public Robot()
    {
        Reset();
    }

    public void Reset()
    {
        Name = GenerateUniqueName();
    }

    private string GenerateUniqueName()
    {
        var name = "";
        do
        {
            name = $"{(char)Rando('A', 'Z')}{(char)Rando('A', 'Z')}{Rando(100, 999)}";
        } while (!allNames.Add(name));

        return name;
    }

    private int Rando(int min, int max)
    {
        Random rand = new Random();
        return rand.Next(min, max);
    }
}