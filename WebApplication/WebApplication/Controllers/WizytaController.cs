using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers;

[Route("api/wizyty")]
[ApiController]
public class WizytaController : ControllerBase
{
    private static readonly List<Wizyta> _wizyty = new()
    {
        new Wizyta("01.11.2003",1,"dobra",100),
        new Wizyta("21.05.2012",1,"srednia",200),
        new Wizyta("24.11.2034",2,"aha",150),
        new Wizyta("32.91.1987",6,"tak",300)
    };
    
    [HttpGet("{AnimalID:int}")]
    public IActionResult getWizyty(int AnimalID)
    {
        var animalVisits = _wizyty.Where(wz => wz.AnimalId == AnimalID).ToList();
        return Ok(animalVisits);
    }


    [HttpPost]
    public IActionResult addWizyta(Wizyta wizyta)
    {  
        _wizyty.Add(wizyta);
        return StatusCode(StatusCodes.Status201Created);
    }
}