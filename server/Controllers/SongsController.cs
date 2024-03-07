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
}