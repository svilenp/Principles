using static Examples.Models.Static.Enums;

namespace Examples.Before.SOLID.LSP;

public class WaterCreature
{
    public string Name { get; set; }
    public string FavouriteFood { get; set; }
    public int SwimmingKmPerDay { get; set; }
    public Size EggsSize { get; set; }

    public virtual void Display()
    {
        PrintName();
        PrintSwim();
        PrintEat();
        PrintOffspring();
    }

    private void PrintName() => Console.WriteLine(Name);

    private void PrintSwim() => Console.WriteLine($"Swims {SwimmingKmPerDay} km per day!");

    private void PrintEat() => Console.WriteLine($"Loves to eat {FavouriteFood}.");

    private void PrintOffspring() => Console.WriteLine($"The eggs are with {EggsSize} size.");
}
