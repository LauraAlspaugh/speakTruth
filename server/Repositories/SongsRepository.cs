namespace speakTruth.Repositories;
public class SongsRepository
{
    private readonly IDbConnection _db;

    public SongsRepository(IDbConnection db)
    {
        _db = db;
    }
}