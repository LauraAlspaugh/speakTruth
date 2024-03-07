




namespace speakTruth.Repositories;
public class PoetryRepository
{
    private readonly IDbConnection _db;

    public PoetryRepository(IDbConnection db)
    {
        _db = db;
    }

    internal Poem CreatePoem(Poem poemData)
    {
        string sql = @"
    INSERT INTO 
    poetry(title, img, body, creatorId)
    VALUES(@Title, @Img, @Body, @CreatorId);
    SELECT 
    poe.*,
    acc.*
    FROM poetry poe
    JOIN accounts acc ON poe.creatorId = acc.id
    WHERE poe.id = LAST_INSERT_ID();
";
        Poem poem = _db.Query<Poem, Account, Poem>(sql, (poem, account) =>
         {
             poem.Creator = account;
             return poem;
         }, poemData).FirstOrDefault();
        return poem;
    }

    internal void DestroyPoem(int poemId)
    {
        string sql = @"
DELETE FROM poetry WHERE id = @poemId LIMIT 1;
SELECT poe.*,
    acc.*
    FROM poetry poe
    JOIN accounts acc ON poe.creatorId = acc.id
    Where poe.id = @poemId;
";
        _db.Execute(sql, new { poemId });
    }

    internal Poem EditPoem(Poem poem)
    {
        string sql = @"
        UPDATE poetry
        SET 
        title = @Title,
        img = @Img,
        body = @Body
        WHERE id = @Id;

        SELECT 
        poe.*,
        acc.*
        FROM poetry poe
        JOIN accounts acc ON poe.creatorId = acc.id
        WHERE poe.id = @Id;
        ";

        Poem newPoem = _db.Query<Poem, Account, Poem>(sql, (poem, account) =>
         {
             poem.Creator = account;
             return poem;
         }, poem).FirstOrDefault();
        return newPoem;
    }

    internal Poem GetPoemById(int poemId)
    {
        string sql = @"
       SELECT 
       poe.*,
       acc.*
       FROM poetry poe
       JOIN accounts acc ON poe.creatorId = acc.id
       WHERE poe.id = @poemId;
       ";
        Poem poem = _db.Query<Poem, Account, Poem>(sql, (poem, account) =>
        {
            poem.Creator = account;
            return poem;
        }, new { poemId }).FirstOrDefault();
        return poem;
    }

    internal List<Poem> GetPoetry()
    {
        string sql = @"
    SELECT 
    poe.*,
    acc.*
    FROM poetry poe
    JOIN accounts acc ON poe.creatorId = acc.id
    ";
        List<Poem> poems = _db.Query<Poem, Account, Poem>(sql, (poem, account) =>
        {
            poem.Creator = account;
            return poem;
        }).ToList();
        return poems;
    }
}