


namespace speakTruth.Services;
public class PostsService
{
    private readonly PostsRepository _postsRepository;

    public PostsService(PostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    internal Post CreatePost(Post postData)
    {
        Post post = _postsRepository.CreatePost(postData);
        return post;
    }

    internal string DestroyPost(int postId, string userId)
    {
        Post post = GetPostById(postId);
        if (post.CreatorId != userId)
        {
            throw new Exception("not yours to destroy!");
        }
        _postsRepository.DestroyPost(postId);
        return "it is gone";
    }

    internal Post EditPost(int postId, string id, Post postData)
    {
        Post post = GetPostById(postId);
        if (post.CreatorId != id)
        {
            throw new Exception("not your post to edit!");
        }
        post.Img = postData.Img ?? post.Img;
        post.Title = postData.Title ?? post.Title;
        post.Body = postData.Body ?? post.Body;
        _postsRepository.EditPost(post);
        return post;
    }

    internal Post GetPostById(int postId)
    {
        Post post = _postsRepository.GetPostById(postId);
        if (post == null)
        {
            throw new Exception("not a valid post id");
        }
        return post;
    }

    internal List<Post> GetPosts()
    {
        List<Post> posts = _postsRepository.GetPosts();
        return posts;
    }
}