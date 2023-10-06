using Microsoft.AspNetCore.Mvc;

namespace CodeMazeMapsterExample.Controllers;
[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    [HttpGet("NewPerson")]
    public IActionResult GetNewPerson()
    {
        var person = MappingFunctions.MapPersonToNewDto();

        return Ok(person);
    }

    [HttpGet("ExistingPerson")]
    public IActionResult GetExistingPerson()
    {
        var person = MappingFunctions.MapPersonToExistingDto();

        return Ok(person);
    }

    [HttpGet("GetPeopleQueryable")]
    public IActionResult GetPeopleQueryable()
    {
        var people = MappingFunctions.MapPersonQueryableToDtoQueryable();

        return Ok(people);
    }

    [HttpGet("ShortPerson")]
    public IActionResult GetShortPerson()
    {
        var person = MappingFunctions.CustomMapPersonToShortInfoDto();

        return Ok(person);
    }

    [HttpGet("Entity")]
    public IActionResult GetPersonEntity()
    {
        var person = MappingFunctions.MapPersonDtoToPersonEntity();

        return Ok(person);
    }
}