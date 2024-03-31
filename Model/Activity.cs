using System.Text.Json.Serialization;

namespace BigHeadAPI.Model;

public class Activity
{
    public string? start_date { get; set; }
    public string? type { get; set; }
    public double? distance { get; set; }
}