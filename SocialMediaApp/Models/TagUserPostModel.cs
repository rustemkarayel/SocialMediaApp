using EntityLayer;

namespace SocialMediaApp.Models
{
    public class TagUserPostModel
    {
        public Tag tagModel { get; set; }

        public IEnumerable<User> userModel { get; set; }
        public IEnumerable<Post> postModel { get; set; }
    }
}
