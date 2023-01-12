using EntityLayer;

namespace SocialMediaApp.Models
{
    public class PostLikeUserPostModel
    {
        public PostLike PostLikeModel { get; set; }
        public IEnumerable<Post> PostModel { get; set; }
        public IEnumerable<User> UserModel { get; set; }
    }
}
