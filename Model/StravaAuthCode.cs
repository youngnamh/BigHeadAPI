using System.ComponentModel.DataAnnotations;

namespace BigHeadAPI.Model;

public class StravaAuthCode
{
    [Required]
    public string? Code { get; set; }
}