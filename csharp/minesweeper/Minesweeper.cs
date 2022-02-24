using System;
using System.Data;
using System.Linq;

public static class Minesweeper
{
    public static string[] Annotate(string[] input)
    {
        var results = input.Select(x => x.ToArray()).ToArray();
        (int row, int col)[] directions = { (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };
        for (var row = 0; row < results.Length; row++)
        {
            for (var col = 0; col < results[row].Length; col++)
            {
                if (results[row][col] == '*')
                {
                    foreach (var direction in directions)
                    {
                        (int row, int col) neighbor = direction.Add((row, col));
                        if (neighbor.CoordInRange(results.Length, results[row].Length)
                            && results[neighbor.row][neighbor.col] != '*')
                        {
                            results[neighbor.row][neighbor.col] = results[neighbor.row][neighbor.col].AddOne();
                        }
                    }
                }
            }
        }
        return results.Select(row => string.Concat(row)).ToArray();
    }

    private static (int, int) Add(this (int, int) tupel1, (int, int) tupel2) =>
        (tupel1.Item1 + tupel2.Item1, tupel1.Item2 + tupel2.Item2);

    private static bool CoordInRange(this (int row, int col) coord, int maxRow, int maxCol) =>
        (coord.row >= 0 && coord.row < maxRow && coord.col >= 0 && coord.col < maxCol);

    private static char AddOne(this char value)
    {
        var sum = char.IsNumber(value) ? value + 1 : '1';
        return (char)sum;
    }
}
