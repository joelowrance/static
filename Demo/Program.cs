// See https://aka.ms/new-console-template for more information

using Statics;

// Extension methods 
var dt = DateTime.Now;
var dt2 = dt.DaysLater(5);
Console.WriteLine(dt2.ToString("f"));

//
// Statics in the framework
//These two
Console.WriteLine(Math.PI);
// This one
var lines = File.ReadAllLines(@"c:\src\flutter\.gitignore")
    // And then Linq is pretty much nothing but static methods
    .ToList()
    .Where(x => !string.IsNullOrEmpty(x));

//
// BadStatic

//
// FEMADesignatedDisasterArea


// "Good" static
var isAllNumbers = Utilities.IsAllNumbers("1234");
var isWeekend = Utilities.IsWeekend(DateTime.Now);

//
// Factory Methods.  
var tacos = Meal.CreateTacosMeal(drink: true, chips: false);

//
// private static

//
// static using

// Static ctor
// Static ctor will be called first
var c1 = new WithAStaticConstructor();

// Static ctor not called on second instance
var c2 = new WithAStaticConstructor();

//
// static members
var m1 = new WithAStaticMember("m1");
m1.DoSomething();
m1.DoSomething();

var m2 = new WithAStaticMember("m2");
m2.DoSomething();
m2.DoSomething();

Console.WriteLine($"m1 count: {WithAStaticMember.Count}");

var f = new ReadOnlyGuy("a", 12);
//f.Name = "b";

var g = new ReadOnlyGuy("b", 21);
//g.Name = "c";

// General rule of thumb: If you dont need to access instance members you can make it static
// If it's expensive or has side affects you should probably not make it static or at least find a way to wrap encapsulate it
