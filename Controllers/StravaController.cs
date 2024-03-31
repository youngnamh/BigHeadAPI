using Amazon.DynamoDBv2.DataModel;
using BigHeadAPI.Model;
using BigHeadAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BigHeadAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StravaController: ControllerBase
{
    private readonly StravaAuthService _stravaAuthService;
    private readonly IDynamoDBContext _context;

    public StravaController(StravaAuthService stravaAuthService, IDynamoDBContext context)
    {
        _stravaAuthService = stravaAuthService;
        _context = context;
    }

    [HttpGet]
    public string GetStrava()
    {
        return "getStrava no id";
    }
        
        
        
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody]StravaAuthCode stravaAuth)
    {
        var code = stravaAuth.Code;
        Athlete response = await _stravaAuthService.GetStravaToken(code);
        string jsonAthlete = System.Text.Json.JsonSerializer.Serialize(response);
        
        await _context.SaveAsync(response);
        return Ok(JsonConvert.SerializeObject(jsonAthlete));
    }
        
    [HttpPut("{id}")]
    public string UpdateStrava(int id)
    {
        Console.WriteLine($"Get Get Get {id}");
        return $"Updating strava with Id: {id}";
    }

    [HttpDelete("{id}")]
    public string DeleteStrava(int id)
    {
        return $"Deleting strava with Id: {id}";
    }
}