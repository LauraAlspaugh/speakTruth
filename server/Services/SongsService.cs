namespace speakTruth.Services;
public class SongsService
{
    private readonly SongsRepository _songsRepository;

    public SongsService(SongsRepository songsRepository)
    {
        _songsRepository = songsRepository;
    }
}