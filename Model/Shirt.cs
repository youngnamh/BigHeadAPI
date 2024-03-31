using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;
using BigHeadAPI.Model.Validations;

namespace BigHeadAPI.Model;

[DynamoDBTable("shirts")]
public class Shirt
{
    [DynamoDBHashKey("shirtId")]   
    public int ShirtId { get; set; }
    [DynamoDBProperty("brand")]
    public string? Brand { get; set; }
    [DynamoDBProperty("color")]
    public string? Color { get; set; }
    [DynamoDBProperty("price")]
    public double? Price { get; set; }
    [DynamoDBProperty("size")]
    public int? Size { get; set; }
}