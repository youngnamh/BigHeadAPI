using System.ComponentModel.DataAnnotations;

namespace BigHeadAPI.Model;

public class Athlete
{
    public int id { get; set; }
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
    public int ListLength { get; set; }

    public List<Activity> Activities { get; set; }
}