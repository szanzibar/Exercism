using System;

public class Clock : IEquatable<Clock>
{
    private int _hours;
    private int _minutes;

    public Clock(int hours, int minutes)
    {
        var extraHours = minutes / 60;
        _minutes = minutes % 60;
        if (_minutes < 0)
        {
            _minutes += 60;
            extraHours += -1;
        }
        _hours = (hours + extraHours) % 24;
        if (_hours < 0) _hours += 24;
    }

    public override string ToString()
    {
        return $"{_hours.ToString("D2")}:{_minutes.ToString("D2")}";
    }

    public bool Equals(Clock clock)
    {
        if (clock == null) return false;
        if (_hours == clock._hours && _minutes == clock._minutes) return true;
        return false;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Clock clock = obj as Clock;
        if (clock == null) return false;
        return Equals(clock);
    }

    public Clock Add(int minutesToAdd) => new Clock(_hours, _minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(_hours, _minutes - minutesToSubtract);

    public override int GetHashCode()
    {
        return HashCode.Combine(_hours, _minutes);
    }
}
