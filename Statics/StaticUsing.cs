using static System.Console;
using static System.Math;
using static Statics.MyExample;
namespace Statics;


public class StaticUsing
{
    public void DoSomething()
    {
        //instead of Math.Ceiling(12.78M);
        var f = Ceiling(12.78M);
        
        //instead of Console.WriteLine
        WriteLine(f);
        
        // Works with non-framework classes
        var g = RoundUp(12.78M);
        WriteLine(g);
    }
}

public static class MyExample
{
    public static decimal RoundUp(decimal d)
    {
        return Ceiling(d);
    }
    
}

