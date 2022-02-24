using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        var results = new List<uint>();
        foreach (var number in numbers)
        {
            var bytes = new List<uint>();
            var shiftedNumber = number;
            do
            {
                uint lastByte = shiftedNumber & 127;

                if (bytes.Any())
                {
                    lastByte |= 128;
                }

                bytes.Add(lastByte);

                shiftedNumber >>= 7;

            } while (shiftedNumber > 0);
            bytes.Reverse();
            results.AddRange(bytes);
        }

        return results.ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        if ((bytes.Last() & 128) != 0)
            throw new InvalidOperationException();

        var results = new List<uint>();

        var temp = 0U;
        foreach (var thisByte in bytes)
        {
            temp = (temp << 7) + (thisByte & 127);
            if ((thisByte & 128) == 0)
            {
                results.Add(temp);
                temp = 0;
            }
        }

        return results.ToArray();
    }
}