using System;
using System.Collections.Generic;
using System.Linq;

public static class Dominoes
{
    public static bool CanChain(IEnumerable<(int, int)> dominoes)
    {
        var count = dominoes.Count();
        if (count == 0) return true;

        var dominoesList = dominoes.ToList();
        var orderedDominoes = new List<(int, int)>();
        (dominoesList, orderedDominoes) = dominoesList.First().MoveDomino(dominoesList, orderedDominoes);

        (_, orderedDominoes) = OrderDominoes(dominoesList, orderedDominoes);

        if (orderedDominoes.Count() != dominoes.Count()) return false;
        if (orderedDominoes.First().Item1 == orderedDominoes.Last().Item2) return true;
        return false;
    }

    private static (List<(int, int)>, List<(int, int)>) OrderDominoes(List<(int, int)> dominoes, List<(int, int)> orderedDominoes)
    {
        if (dominoes.Count() == 0) return (dominoes, orderedDominoes);
        var nextDominos = dominoes.MatchDominoes(orderedDominoes.Last().Item2);
        foreach (var domino in nextDominos)
        {
            var (newDominoes, newOrderedDominoes) = domino.MoveDomino(dominoes, orderedDominoes);
            (newDominoes, newOrderedDominoes) = OrderDominoes(newDominoes, newOrderedDominoes);
            if (newDominoes.Count == 0)
            {
                return (newDominoes, newOrderedDominoes);
            }

        }

        return (dominoes, orderedDominoes);
    }

    private static List<(int, int)> MatchDominoes(this List<(int, int)> dominoes, int value)
    {
        var list = new List<(int, int)>();

        for (int i = 0; i < dominoes.Count(); i++)
        {
            if (dominoes[i].Item1 == value) list.Add(dominoes[i]);
            else if (dominoes[i].Item2 == value)
            {
                dominoes[i] = dominoes[i].ReverseDomino();
                list.Add(dominoes[i]);
            }
        }
        return list;
    }

    private static (int, int) ReverseDomino(this (int, int) domino)
    {
        return (domino.Item2, domino.Item1);
    }

    private static (List<(int, int)>, List<(int, int)>) MoveDomino(this (int, int) domino, List<(int, int)> source, List<(int, int)> destination)
    {
        var newSource = new List<(int, int)>();
        newSource.AddRange(source);
        var newDestination = new List<(int, int)>();
        newDestination.AddRange(destination);

        var toMove = newSource.FirstOrDefault(d => d == domino);
        if (toMove == default) throw new Exception("Domino cannot be moved. It does not exist in source list");

        newDestination.Add(toMove);
        newSource.Remove(toMove);

        return (newSource, newDestination);
    }
}