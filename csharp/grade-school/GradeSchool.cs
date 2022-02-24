using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private List<Student> roster = new List<Student>();

    public void Add(string student, int grade)
    {
        roster.Add(new Student() { Name = student, Grade = grade });
    }

    public IEnumerable<string> Roster()
    {
        return roster
        .OrderBy(s => s.Grade).ThenBy(s => s.Name)
        .Select(s => s.Name).ToArray();
    }

    public IEnumerable<string> Grade(int grade)
    {
        return roster
        .Where(s => s.Grade == grade)
        .OrderBy(s => s.Name)
        .Select(s => s.Name).ToArray();
    }
}

public class Student
{
    public string Name { get; set; }
    public int Grade { get; set; }
}