namespace Statics;

public class ReadOnlyGuy
{
    public readonly string Name;
    public readonly int Age;

    public ReadOnlyGuy(string name, int age)
    {
        Name = name;
        Age = age;
    }
}



public class WithAStaticMember
{
    // Count is shared across instances. 
    public static int Count { get; set; }

    public string Name { get; set; }

    public WithAStaticMember(string name)
    {
        Name = name;
    }

    public void DoSomething()
    {
        Count++;
    }
}

public class WithAStaticConstructor
{
    public static int Count;
    public int NonStaticCount;
    
    // the framework will call this before the first instance is created
    static WithAStaticConstructor()
    {
        Count = 400;
    }
    
    // then this
    public WithAStaticConstructor()
    {
        NonStaticCount = 100;
    }
}

