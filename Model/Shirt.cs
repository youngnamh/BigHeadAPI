using System.ComponentModel.DataAnnotations;
using BigHeadAPI.Model.Validations;

namespace BigHeadAPI.Model;

public class Shirt
{
    public int ShirtId { get; set; }
    [Required]
    public string? Brand { get; set; }
    [Required]
    public string? Color { get; set; }
    public double? Price { get; set; }
    [Required]
    [Shirt_EnsureCorrectSizing]
    public int? Size { get; set; }
}