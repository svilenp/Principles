namespace Examples.After.SOLID.LSP;

public class Dolphin : WaterCreature
{
    protected override void PrintOffspring() => Console.WriteLine("Doesn't lay eggs.");

    protected override void AdditionalDisplay() => PrintBreathing();

    private void PrintBreathing() => Console.WriteLine("Has to breathe air.");
}
