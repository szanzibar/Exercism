using System;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int month;
    private readonly int year;

    public Meetup(int month, int year)
    {
        this.month = month;
        this.year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var firstDayOfWeekInMonth = 1 + dayOfWeek - new DateTime(year, month, 1).DayOfWeek;
        if (firstDayOfWeekInMonth < 1) firstDayOfWeekInMonth += 7;

        var day = schedule == Schedule.Teenth ?
            Enumerable.Range(13, 7).First(r => (r - firstDayOfWeekInMonth) % 7 == 0) : 
            firstDayOfWeekInMonth + 7 * ((int)schedule - 1);
            
        if (day > DateTime.DaysInMonth(year, month)) day -= 7;

        return new DateTime(year, month, day);
    }
}