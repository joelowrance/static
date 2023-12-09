using System.ComponentModel.Design;

namespace Statics;


/// <summary>
/// Everything is static.
/// There is no hierarchy and no clear separation of concerns.  Everything can access everything else.  Prime case
/// of spaghetti code.  This is easy to follow because it's kind of short, but imagine this being 100s of lines of code
/// per class, with each class being able to reach out to any other class.
/// </summary>
public class BusinessLogic
{
    //Calls config loader, database and emailer
    public static void Process()
    {
        var configs = ConfigLoader.LoadConfig();
        var db = new Database();
        var value = db.GetValue("myvalue");
        Emailer.SendEmail(value);
    }
}

public class ConfigLoader
{
    public static List<string> LoadConfig()
    {
        var lines = File.ReadLines(System.Configuration.ConfigurationManager.AppSettings["ConfigFile"]);
        return lines.ToList();
    }

    public static string? GetName(string key)
    {
        return key.Reverse().ToString();
    }
}

public class Database
{
    public string GetValue(string config)
    {
        var val = ConfigLoader.GetName(config);
        return val;
    }
}

public static class Emailer
{
    public static void SendEmail(string message)
    {
        ConfigLoader.GetName("emailAddress");
        
        Console.WriteLine(message);
    }
}