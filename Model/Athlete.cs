using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;

namespace BigHeadAPI.Model;

[DynamoDBTable("athletes")]
public class Athlete
{
    [DynamoDBHashKey("id")]
    public int id { get; set; }
    [DynamoDBProperty("firstname")]
    public string? firstname { get; set; }
    [DynamoDBProperty("lastname")]
    public string? lastname { get; set; }
    [DynamoDBProperty("accessToken")]
    public string? AccessToken { get; set; }
    [DynamoDBProperty("refreshToken")]
    public string? RefreshToken { get; set; }
    [DynamoDBProperty("listLength")]
    public int ListLength { get; set; }
    [DynamoDBProperty("activities")]
    public List<Activity> Activities { get; set; }
}