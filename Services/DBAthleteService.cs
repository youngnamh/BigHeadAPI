using Amazon.DynamoDBv2.DataModel;

namespace BigHeadAPI.Services;

public class DBAthleteService
{
    private readonly IDynamoDBContext _context;

    public DBAthleteService(IDynamoDBContext context)
    {
        _context = context;
    }
    
    
}