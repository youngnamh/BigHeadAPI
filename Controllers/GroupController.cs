using Amazon.DynamoDBv2.DataModel;
using BigHeadAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BigHeadAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController: ControllerBase
{
    private readonly IDynamoDBContext _context;

    public GroupController(IDynamoDBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroup(string id)
    {   
        var athlete = await _context.LoadAsync<Group>(id);
        if (athlete == null) return NotFound();
        return Ok(athlete);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody]Group createdGroup)
    {
        var athlete = await _context.LoadAsync<Group>(createdGroup.GroupId);
        //athlete already exists, update athletes
        if (athlete != null)
        {
            return BadRequest($"Group with Id {createdGroup.GroupId} already exists.");
        }
        else
        {
            await _context.SaveAsync(createdGroup);
            string jsonAthlete = System.Text.Json.JsonSerializer.Serialize(createdGroup);
            return Ok(JsonConvert.SerializeObject(jsonAthlete));
        }
    }

}