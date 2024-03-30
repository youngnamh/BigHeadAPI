using BigHeadAPI.Model;
using BigHeadAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    public string GetStrava()
    {   
        Console.WriteLine("Get Get Get WL");
        System.Diagnostics.Debug.WriteLine("Get Get Get diag");
        return "Strava Get";
    }
        
        
        
    [HttpPost]
    public async Task<IActionResult> CreateAccount([FromBody]StravaAuthCode stravaAuth)
    {
        var code = stravaAuth.Code;
        Console.WriteLine($"code: {code} WL");
        System.Diagnostics.Debug.WriteLine($"code {code} diag");
        string response = await _stravaAuthService.GetStravaToken(code);
        Console.WriteLine("after");
        System.Diagnostics.Debug.WriteLine("after");
        return Ok(response);
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