using Amazon.DynamoDBv2.DataModel;

namespace BigHeadAPI.Model;

[DynamoDBTable("challengeGroup")]
public class Group
{
    [DynamoDBHashKey("groupId")]
    public string? GroupId { get; set; }
    [DynamoDBProperty("groupName")]
    public string? GroupName { get; set; }
    [DynamoDBProperty("startDate")]
    public string? StartDate { get; set; }
    [DynamoDBProperty("endDate")]
    public string? EndDate { get; set; }
    [DynamoDBProperty("athletes")]
    public List<Athlete>? Athletes { get; set; }
}