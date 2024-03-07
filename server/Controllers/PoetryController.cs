using System.Security.Cryptography;

namespace speakTruth.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PoetryController : ControllerBase
{
    private readonly PoetryService _poetryService;
    private readonly Auth0Provider _auth0Provider;

    public PoetryController(PoetryService poetryService, Auth0Provider auth0Provider)
    {
        _poetryService = poetryService;
        _auth0Provider = auth0Provider;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Poem>> CreatePoem([FromBody] Poem poemData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            poemData.CreatorId = userInfo.Id;
            Poem poem = _poetryService.CreatePoem(poemData);
            return Ok(poem);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }

    }
    [HttpGet]
    public ActionResult<List<Poem>> GetPoetry()
    {
        try
        {
            List<Poem> poems = _poetryService.GetPoetry();
            return Ok(poems);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{poemId}")]
    public ActionResult<Poem> GetPoemById(int poemId)
    {
        try
        {
            Poem poem = _poetryService.GetPoemById(poemId);
            return Ok(poem);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpDelete("{poemId}")]
    public async Task<ActionResult<string>> DestroyPoem(int poemId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _poetryService.DestroyPoem(poemId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpPut("{poemId}")]
    public async Task<ActionResult<Poem>> EditPoem(int poemId, [FromBody] Poem poemData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Poem poem = _poetryService.EditPoem(poemId, userInfo.Id, poemData);
            return Ok(poem);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}