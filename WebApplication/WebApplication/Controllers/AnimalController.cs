using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private static readonly List<Animal> _animals = new()
    {
        new Animal(1, "Puszek", "Kot", 1500, "czarny"),
        new Animal(2, "Reksio", "Pies", 500, "szary"),
        new Animal(3, "Filemon", "Kot", 200, "bialy"),
        new Animal(4, "Kajtek", "Pies", 4500, "brazowy"),
        new Animal(5, "Koko", "Malpa", 5000, "czarny"),
    };

    [HttpGet]
    public IActionResult getAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult getAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(an => an.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        return Ok(animal);
    }
    
}