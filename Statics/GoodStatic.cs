namespace Statics;

/// <summary>
/// These methods are "good" candidates for statics.  They don't access any instance members, and dont
/// seem to belong to any particular type.
/// </summary>
public class Utilities
{
    public static bool IsAllNumbers(string s)
    {
        return s.All(char.IsNumber);
    }

    public static bool IsWeekend(DateTime dt)
    {
        return dt.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;
    }
}