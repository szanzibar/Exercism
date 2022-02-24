using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private List<List<int>> matrix;
    public Matrix(string input)
    {
        matrix = input.Split('\n').Select(r => r.Split(' ').Select(item => int.Parse(item)).ToList()).ToList();
    }

    public int[] Row(int row)
    {
        return matrix.Skip(row - 1).First().ToArray();
    }

    public int[] Column(int col)
    {
        return matrix.Select(row => row.Skip(col - 1).First()).ToArray();
    }
}