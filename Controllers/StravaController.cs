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

    public StravaController(StravaAuthService stravaAuthService)
    {
        _stravaAuthService = stravaAuthService;
    }

        
    [HttpGet]
    public IActionResult GetStrava()
    {   
        Console.WriteLine("Get Get Get WL");
        return Ok(JsonConvert.SerializeObject("Strava Get Request"));
    }
        
        
        
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody]StravaAuthCode stravaAuth)
    {
        var code = stravaAuth.Code;
        Console.WriteLine($"code: {code} WL");
        string response = await _stravaAuthService.GetStravaToken(code);
        return Ok(JsonConvert.SerializeObject(response));
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