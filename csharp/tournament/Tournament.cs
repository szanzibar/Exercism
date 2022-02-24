using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{
    public static void Tally(Stream inStream, Stream outStream)
    {
        var tournament = new List<TeamStats>();
        using var reader = new StreamReader(inStream);

        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine().Split(';');

            if (!tournament.Any(team => team.TeamName == line[0])) tournament.Add(new TeamStats(line[0]));
            if (!tournament.Any(team => team.TeamName == line[1])) tournament.Add(new TeamStats(line[1]));

            var team1 = tournament.FirstOrDefault(team => team.TeamName == line[0]);
            var team2 = tournament.FirstOrDefault(team => team.TeamName == line[1]);
            switch (line[2])
            {
                case "win":
                    team1.MatchesWon++;
                    team2.MatchesLost++;
                    break;
                case "loss":
                    team1.MatchesLost++;
                    team2.MatchesWon++;
                    break;
                default:
                    team1.MatchesDrawn++;
                    team2.MatchesDrawn++;
                    break;
            }

        }
        var table = generateTournamentTable(tournament.OrderByDescending(team => team.Points()).ThenBy(team => team.TeamName));
        using var writer = new StreamWriter(outStream);
        writer.Write(table);
    }

    private static string generateTournamentTable(IEnumerable<TeamStats> tournament)
    {
        var table = "Team                           | MP |  W |  D |  L |  P\n";
        foreach (var teamStat in tournament)
        {
            table += $"{teamStat.TeamName.PadRight(30)} |" +
                $"{teamStat.MatchesPlayed().ToString().PadLeft(3)} |" +
                $"{teamStat.MatchesWon.ToString().PadLeft(3)} |" +
                $"{teamStat.MatchesDrawn.ToString().PadLeft(3)} |" +
                $"{teamStat.MatchesLost.ToString().PadLeft(3)} |" +
                $"{teamStat.Points().ToString().PadLeft(3)}" +
                "\n";
        }
        return table.Trim();
    }
}

public class TeamStats
{
    public int MatchesWon { get; set; } = 0;
    public int MatchesDrawn { get; set; } = 0;
    public int MatchesLost { get; set; } = 0;
    public string TeamName { get; private set; }
    public int MatchesPlayed() => MatchesWon + MatchesDrawn + MatchesLost;
    public int Points() => MatchesWon * 3 + MatchesDrawn;

    public TeamStats(string teamName)
    {
        TeamName = teamName;
    }
}