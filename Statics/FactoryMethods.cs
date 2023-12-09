namespace Statics;

/// <summary>
/// Factory methods
/// </summary>
public class Meal
{
    public List<Item> Items { get; } = new();
    
    // Static Factory Methods, these are methods that create an instance of the class with some predefined values.
    // Can be used to create default instances of a class or to hide complexity if there are set up steps that need to be
    // taken
    public static Meal CreateQuesadillaMeal(bool drink, bool chips)
    {
        var meal = new Meal();
        meal.Items.Add(new Item("Quesadilla", 4.95m));
        if (drink)
        {
            meal.Items.Add(CreateDrink());
        }
        if (chips)
        {
            meal.Items.Add(CreateChips());
        }
        return meal;
    }
    
    public static Meal CreateTacosMeal(bool drink, bool chips)
    {
        var meal = new Meal();
        meal.Items.Add(new Item("Tacos", 6.95m));
        if (drink)
        {
            meal.Items.Add(CreateDrink());
        }
        if (chips)
        {
            meal.Items.Add(CreateChips());
        }
        return meal;
    }

    
    private static Item CreateDrink() => new Item("Drink", 1.95m);
    private static Item CreateChips() => new Item("Chips", 1.95m);
    
    
}

public record Item(string Description, decimal Price);