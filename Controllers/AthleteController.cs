using Amazon.DynamoDBv2.DataModel;
using BigHeadAPI.Model;
using BigHeadAPI.Model.Requests;
using BigHeadAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BigHeadAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AthleteController: ControllerBase
{
    private readonly IDynamoDBContext _context;

    public AthleteController(IDynamoDBContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAthlete(int id)
    {   
        var athlete = await _context.LoadAsync<Athlete>(id);
        if (athlete == null) return NotFound();
        return Ok(athlete);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAthlete([FromBody]Athlete createdAthlete)
    {
        var athlete = await _context.LoadAsync<Athlete>(createdAthlete.id);
        //athlete already exists, update athletes
        if (athlete != null)
        {
            return BadRequest($"Athlete with Id {createdAthlete.id} already exists.");
        }
        else
        {
            await _context.SaveAsync(createdAthlete);
            string jsonAthlete = System.Text.Json.JsonSerializer.Serialize(createdAthlete);
            return Ok(JsonConvert.SerializeObject(jsonAthlete));
        }
    }
    
    // Add a new groupId to the athletes groups
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAthlete([FromBody]UpdateAthleteRequest request, int id)
    {
        var athlete = await _context.LoadAsync<Athlete>(id);
        //athlete already exists, update athletes
        if (athlete == null)
        {
            return BadRequest($"Athlete with Id {id} doesn't exists.");
        }
        else
        {
            if (request.Groups != null)
            {
                //string groupId = newGroup.GroupId;
                athlete.addGroups(request.Groups);
            }

            if (request.Friends != null){}
            {
                athlete.addFriends(request.Friends);

            }
            await _context.SaveAsync(athlete);
            string jsonAthlete = System.Text.Json.JsonSerializer.Serialize(athlete);
            return Ok(JsonConvert.SerializeObject(jsonAthlete));
        }
    }
    

}