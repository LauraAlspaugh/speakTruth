


namespace speakTruth.Services;
public class SongsService
{
    private readonly SongsRepository _songsRepository;

    public SongsService(SongsRepository songsRepository)
    {
        _songsRepository = songsRepository;
    }

    internal Song CreateSong(Song songData)
    {
        Song song = _songsRepository.CreateSong(songData);
        return song;
    }

    internal string DestroySong(int songId, string userId)
    {
        Song song = GetSongById(songId);
        if (song.CreatorId != userId)
        {
            throw new Exception(" do not even try it");

        }
        _songsRepository.DestroySong(songId, userId);
        return "it really is gone";
    }

    internal Song GetSongById(int songId)
    {
        Song song = _songsRepository.GetSongById(songId);
        if (song == null)
        {
            throw new Exception("not a valid id");
        }
        return song;
    }

    internal List<Song> GetSongs()
    {
        List<Song> songs = _songsRepository.GetSongs();
        return songs;
    }
}