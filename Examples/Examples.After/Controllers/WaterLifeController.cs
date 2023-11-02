using Examples.After.SOLID.LSP;
using Microsoft.AspNetCore.Mvc;

namespace Examples.After.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WaterLifeController : ControllerBase
{
    [HttpGet]
    [Route("Animals")]
    public void Animals()
    {
        var waterAnimals = new List<WaterCreature>()
        {
            new WhaleShark
            {
                Name = "Sharky",
                FavouriteFood = "Herring",
                SwimmingKmPerDay = 50
            },
            new Dolphin
            {
                Name = "aDolph",
                FavouriteFood = "Squid",
                SwimmingKmPerDay = 30
            }
        };

        foreach (var waterAnimal in waterAnimals)
        {
            waterAnimal.Display();
            Console.WriteLine();
        }
    }
}
