using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        var highestValueInRow = new int[matrix.GetLength(0)];
        var lowestValueInCol = new int[matrix.GetLength(1)];

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            var highest = 0;
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                var lowest = int.MaxValue;
                for (var row2 = 0; row2 < matrix.GetLength(0); row2++)
                {
                    if (matrix[row2, col] <= lowest)
                    {
                        lowest = matrix[row2, col];
                    }
                }
                lowestValueInCol[col] = lowest;

                if (matrix[row, col] >= highest)
                {
                    highest = matrix[row, col];
                }
            }
            highestValueInRow[row] = highest;
        }

        var results = new List<(int, int)>();

        for (var row = 0; row < matrix.GetLength(0); row++)
        {
            for (var col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == highestValueInRow[row] && matrix[row, col] == lowestValueInCol[col])
                {
                    results.Add((row + 1, col + 1));
                }
            }
        }

        return results;
    }
}
