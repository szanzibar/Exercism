using System.Collections.Generic;
using System.Linq;

public enum Plant
{
    Violets = 'V',
    Radishes = 'R',
    Clover = 'C',
    Grass = 'G'
}

public class KindergartenGarden
{
    private readonly string diagram;

    public KindergartenGarden(string diagram)
    {
        this.diagram = diagram;
    }

    public IEnumerable<Plant> Plants(string student)
    {
        var index = (student.First() - 'A') * 2;
        return diagram
            .Split('\n')
            .SelectMany(s => s.Substring(index, 2))
            .Select(p => (Plant)p);
    }
}