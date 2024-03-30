using BigHeadAPI.Model;
using BigHeadAPI.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BigHeadAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShirtsController: ControllerBase
{

        
    [HttpGet]
    public string GetShirts()
    {
        return "Reading all shirts";
    }
        
    [HttpGet("{id}")]
    public IActionResult GetShirtById(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var shirt = ShirtRepository.GetShirtById(id);
        if (shirt == null)
        {
            return NotFound();
        }
        return Ok(shirt);
    }
        
    [HttpPost]
    public string CreateShirt([FromBody]Shirt shirt)
    {
        return "CreateAShirt";
    }
        
    [HttpPut("{id}")]
    public string UpdateShirt(int id)
    {
        return $"Updating shirt with Id: {id}";
    }

    [HttpDelete("{id}")]
    public string DeleteShirt(int id)
    {
        return $"Deleting shirt with Id: {id}";
    }
}