namespace Statics;

public static class ExtensionMethods
{
    // Extension methods are static methods that can be called as if they were instance methods on the type they are extending.
    public static DateTime DaysLater(this DateTime date, int days) => date.AddDays(days);
    public static DateTime DaysBefore(this DateTime date, int days) => date.AddDays(-days);
}

