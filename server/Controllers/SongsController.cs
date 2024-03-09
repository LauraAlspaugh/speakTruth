namespace speakTruth.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SongsController : ControllerBase
{
    private readonly SongsService _songsService;
    private readonly Auth0Provider _auth0Provider;

    public SongsController(SongsService songsService, Auth0Provider auth0Provider)
    {
        _songsService = songsService;
        _auth0Provider = auth0Provider;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Song>> CreateSong([FromBody] Song songData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            songData.CreatorId = userInfo.Id;
            Song song = _songsService.CreateSong(songData);
            return Ok(song);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<Song>> GetSongs()
    {
        try
        {
            List<Song> songs = _songsService.GetSongs();
            return Ok(songs);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{songId}")]
    public ActionResult<Song> GetSongById(int songId)
    {
        try
        {
            Song song = _songsService.GetSongById(songId);
            return Ok(song);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpDelete("{songId}")]
    public async Task<ActionResult<string>> DestroySong(int songId)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _songsService.DestroySong(songId, userId);
            return Ok(message);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}