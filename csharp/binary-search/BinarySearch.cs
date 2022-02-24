using System;
using System.Linq;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) return -1;
        var min = 0;
        var max = input.Length - 1;
        int key;
        do
        {
            key = ((max - min) / 2) + min;
            var previousKey = key;

            if (input[key] < value) min = key;
            else if (input[key] > value) max = key;
            else return -1;


            if (previousKey == key) return -1;
        } while (input[key] != value);

        return key;
    }
}