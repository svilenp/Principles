using static Examples.Models.Static.Enums;

namespace Examples.After.SOLID.LSP;

public class WhaleShark : WaterCreature
{
    protected override void PrintOffspring() => Console.WriteLine($"The eggs are with {Size.Big} size.");

    protected override void AdditionalDisplay() => PrintInfo();

    private void PrintInfo() => Console.WriteLine("The largest known extant fish species.");
}
