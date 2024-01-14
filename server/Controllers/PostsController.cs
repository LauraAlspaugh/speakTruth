namespace speakTruth.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    private readonly PostsService _postsService;
    private readonly Auth0Provider _auth0Provider;
    private readonly CommentsService _commentsService;

    public PostsController(PostsService postsService, Auth0Provider auth0Provider, CommentsService commentsService)
    {
        _postsService = postsService;
        _auth0Provider = auth0Provider;
        _commentsService = commentsService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Post>> CreatePost([FromBody] Post postData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            postData.CreatorId = userInfo.Id;
            Post post = _postsService.CreatePost(postData);
            return Ok(post);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet]
    public ActionResult<List<Post>> GetPosts()
    {
        try
        {
            List<Post> posts = _postsService.GetPosts();
            return Ok(posts);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{postId}")]
    public ActionResult<Post> GetPostById(int postId)
    {
        try
        {
            Post post = _postsService.GetPostById(postId);
            return Ok(post);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [Authorize]
    [HttpPut("{postId}")]
    public async Task<ActionResult<Post>> EditPost(int postId, [FromBody] Post postData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            Post post = _postsService.EditPost(postId, userInfo.Id, postData);
            return Ok(post);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
    [HttpGet("{postId}/comments")]
    public ActionResult<List<Comment>> GetCommentsByPostId(int postId)
    {
        try
        {
            List<Comment> comments = _commentsService.GetCommentsByPostId(postId);
            return Ok(comments);
        }
        catch (Exception error)
        {

            return BadRequest(error.Message);
        }
    }
}