using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    // coords are always (y or row, x or column) except returned from Search

    private readonly char[][] grid;
    private readonly (int row, int col)[] directions = { (0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1) };
    public WordSearch(string grid)
    {
        this.grid = grid.Split('\n').Select(row => row.ToArray()).ToArray();
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var answers = new Dictionary<string, ((int, int), (int, int))?>();
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[row].Length; col++)
            {
                var wordsMatchingFirstLetter = wordsToSearchFor.Where(word => word.First() == grid[row][col]);
                foreach (var word in wordsMatchingFirstLetter)
                {
                    foreach (var direction in directions)
                    {
                        var start = (row, col);
                        var letterIndex = 0;
                        (int row, int col) coord = (row + (letterIndex * direction.row), col + (letterIndex * direction.col));
                        while (coord.row >= 0 && coord.row < grid.Length
                            && coord.col >= 0 && coord.col < grid[row].Length
                            && letterIndex < word.Length
                            && grid[coord.row][coord.col] == word.Skip(letterIndex).First())
                        {
                            letterIndex++;
                            if (letterIndex == word.Length)
                            {
                                answers.Add(word, ((start.col + 1, start.row + 1), (coord.col + 1, coord.row + 1)));
                                break;
                            }
                            coord = (row + (letterIndex * direction.row), col + (letterIndex * direction.col));
                        }
                    }

                }
            }
        }

        return answers;
    }
}