
namespace Statics;

public class PersonConsumer
{
    public void DoSomething()
    {
        var p1 = new Person();
        p1.DoSomething(new DateTime(1980, 1, 1));

        var p2 = new Person();
        p2.DoSomething(new DateTime(1981, 1, 1));
    }

}


public class Person
{
    public void DoSomething(DateTime dateOfBirth)
    {
        var days = GetNumberOfDaysOld(dateOfBirth);
        Console.WriteLine($"You are {days} years old");
    }
    
    //IDE hints that this should be static as it does not access any instance data
    
    // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1822
    // Members that do not access instance data or call instance methods can be marked as static (Shared in Visual Basic).
    // After you mark the methods as static, the compiler will emit nonvirtual call sites to these members. Emitting nonvirtual
    // call sites will prevent a check at run time for each call that makes sure that the current object pointer is non-null. T
    // his can achieve a measurable performance gain for performance-sensitive code. In some cases,
    // the failure to access the current object instance represents a correctness issue.
    
    private double GetNumberOfDaysOld(DateTime date)
    {
        return DateTime.Now.Subtract(date).TotalDays;
    }
}

