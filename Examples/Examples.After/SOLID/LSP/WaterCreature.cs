namespace Examples.After.SOLID.LSP;

public abstract class WaterCreature
{
    public string Name { get; set; }
    public string FavouriteFood { get; set; }
    public int SwimmingKmPerDay { get; set; }

    public void Display()
    {
        PrintName();
        PrintSwim();
        PrintEat();
        PrintOffspring();
        AdditionalDisplay();
    }

    private void PrintName() => Console.WriteLine(Name);

    private void PrintSwim() => Console.WriteLine($"Swims {SwimmingKmPerDay} km per day!");

    private void PrintEat() => Console.WriteLine($"Loves to eat {FavouriteFood}.");

    protected abstract void PrintOffspring();

    protected virtual void AdditionalDisplay() { }
}
