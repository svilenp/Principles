using Examples.Before.SOLID.LSP;
using Examples.Models.Static;
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
            new WaterCreature // Shark
            {
                Name = "Shark", 
                EggsSize = Enums.Size.Medium,
                FavouriteFood = "Herring",
                SwimmingKmPerDay = 50
            },
            new Dolphin
            {
                Name = "Dolphin",
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
