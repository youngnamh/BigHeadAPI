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
    public int? ListLength { get; set; }
    [DynamoDBProperty("activities")]
    public List<Activity>? Activities { get; set; }
    [DynamoDBProperty("groups")]
    public List<String>? Groups { get; set; }
    [DynamoDBProperty("friends")]
    public List<int>? Friends { get; set; }


    public void addGroups(List<String> newGroups)
    {
        if (newGroups.Count==0)
        {
            return;
        }
        if (Groups == null || Groups.Count == 0)
        {
            Groups = newGroups;
        }
        else
        {
            Groups.AddRange(newGroups);
        }
    }
    
    public void addFriends(List<int> newFriends)
    {
        if (newFriends.Count==0)
        {
            return;
        }
        if (Friends == null || Friends.Count == 0)
        {
            Friends = newFriends;
        }
        else
        {
            Friends.AddRange(Friends);
        }
    }
}