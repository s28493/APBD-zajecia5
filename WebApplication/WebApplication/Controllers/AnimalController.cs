using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalController : ControllerBase
{
    private IAnimalService _animalsService;

    public AnimalController(IAnimalService animalsService)
    {
        _animalsService = animalsService;
    }

    [HttpGet]
    public IActionResult getAnimals(string orderBy = "name")
    {
        var animals = _animalsService.GetAnimals();
        switch (orderBy.ToLower())
        {
            case "description":
                animals = animals.OrderBy(a => a.Description);
                break;
            case "category":
                animals = animals.OrderBy(a => a.Category);
                break;
            case "area":
                animals = animals.OrderBy(a => a.Area);
                break;
            default:
                animals = animals.OrderBy(a => a.Name);
                break;
        }
        return Ok(animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult getAnimal(int id)
    {
        var animal = _animalsService.GetAnimal(id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        return Ok(animal);
    }
    
    [HttpPost]
    public IActionResult createAnimal(Animal animal)
    {
        var affectedCount = _animalsService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id:int}")]
    public IActionResult updateAnimal(int id, Animal animal)
    {
        var affectedCount = _animalsService.UpdateAnimal(animal);
        return NoContent();
    }
    
    
    [HttpDelete("{id:int}")]
    public IActionResult deleteAnimal(int id)
    {
        var affectedCount = _animalsService.DeleteAnimal(id);
        return NoContent();
    }
}

