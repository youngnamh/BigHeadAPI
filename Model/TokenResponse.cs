namespace BigHeadAPI.Model;

public class TokenResponse
{
    public string refresh_token { get; set; }
    public string access_token { get; set; }
    public Athlete athlete { get; set; }
}