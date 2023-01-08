using EntityLayer;

namespace SocialMediaApp.Models
{
    public class SavedUserPostModel
    {
        public Saved SavedModel { get; set; }
        public IEnumerable<User> UserModel { get; set; }
        public IEnumerable<Post> PostModel { get; set; }
    }
}
