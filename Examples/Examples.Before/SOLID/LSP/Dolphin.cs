namespace Examples.Before.SOLID.LSP;

public class Dolphin : WaterCreature
{
    public override void Display()
    {
        base.Display();
        PrintBreathing();
    }

    private static void PrintBreathing() => Console.WriteLine("Has to breath air.");
}
