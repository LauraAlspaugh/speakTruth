


namespace speakTruth.Services;
public class PoetryService
{
    private readonly PoetryRepository _poetryRepository;

    public PoetryService(PoetryRepository poetryRepository)
    {
        _poetryRepository = poetryRepository;
    }

    internal Poem CreatePoem(Poem poemData)
    {
        Poem poem = _poetryRepository.CreatePoem(poemData);
        return poem;
    }

    internal string DestroyPoem(int poemId, string userId)
    {
        Poem poem = GetPoemById(poemId);
        if (poem.CreatorId != userId)
        {
            throw new Exception("Do not even try it!");

        }
        _poetryRepository.DestroyPoem(poemId);
        return "it really is gone";
    }

    internal Poem EditPoem(int poemId, string id, Poem poemData)
    {
        Poem poem = GetPoemById(poemId);
        if (poem.CreatorId != id)
        {
            throw new Exception("this is not yours to edit!");
        }
        poem.Img = poemData.Img ?? poem.Img;
        poem.Title = poemData.Title ?? poem.Title;
        poem.Body = poemData.Body ?? poem.Body;
        _poetryRepository.EditPoem(poem);
        return poem;
    }

    internal Poem GetPoemById(int poemId)
    {
        Poem poem = _poetryRepository.GetPoemById(poemId);
        if (poem == null)
        {
            throw new Exception("not a valid id!");

        }
        return poem;
    }

    internal List<Poem> GetPoetry()
    {
        List<Poem> poems = _poetryRepository.GetPoetry();
        return poems;
    }
}