using System;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1)
        {
            throw new ArgumentOutOfRangeException();
        }
        var count = 0;
        while (number > 1)
        {
            count++;
            if (number % 2 == 0)
            {
                number /= 2;
            }
            else
            {
                number = 3 * number + 1;
            }
        }

        return count;
    }
}