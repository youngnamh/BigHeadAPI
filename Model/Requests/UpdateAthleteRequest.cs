namespace BigHeadAPI.Model.Requests;

public class UpdateAthleteRequest
{
    public List<string>? Groups { get; set; }
    public List<int>? Friends { get; set; }
}