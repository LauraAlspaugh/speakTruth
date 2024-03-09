



namespace speakTruth.Repositories;
public class SongsRepository
{
    private readonly IDbConnection _db;

    public SongsRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Song CreateSong(Song songData)
    {
        string sql = @"
    INSERT INTO 
    songs(title, img, body, creatorId)
    VALUES(@Title, @Img, @Body, @CreatorId);
    SELECT 
    son.*,
    acc.*
    FROM songs son
    JOIN accounts acc ON son.creatorId = acc.id
    WHERE son.id = LAST_INSERT_ID();
";
        Song song = _db.Query<Song, Account, Song>(sql, (song, account) =>
         {
             song.Creator = account;
             return song;
         }, songData).FirstOrDefault();
        return song;
    }

    internal void DestroySong(int songId, string userId)
    {
        string sql = @"
DELETE FROM songs WHERE id = @songId LIMIT 1;
SELECT son.*,
    acc.*
    FROM songs son
    JOIN accounts acc ON son.creatorId = acc.id
    Where son.id = @songId;
";
        _db.Execute(sql, new { songId });
    }

    internal Song GetSongById(int songId)
    {
        string sql = @"
       SELECT 
       son.*,
       acc.*
       FROM songs son
       JOIN accounts acc ON son.creatorId = acc.id
       WHERE son.id = @songId;
       ";
        Song song = _db.Query<Song, Account, Song>(sql, (song, account) =>
        {
            song.Creator = account;
            return song;
        }, new { songId }).FirstOrDefault();
        return song;
    }

    internal List<Song> GetSongs()
    {
        string sql = @"
    SELECT 
    son.*,
    acc.*
    FROM songs son
    JOIN accounts acc ON son.creatorId = acc.id
    ";
        List<Song> songs = _db.Query<Song, Account, Song>(sql, (song, account) =>
        {
            song.Creator = account;
            return song;
        }).ToList();
        return songs;
    }
}