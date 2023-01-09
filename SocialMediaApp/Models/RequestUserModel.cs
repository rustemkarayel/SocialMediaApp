using EntityLayer;

namespace SocialMediaApp.Models
{
    public class RequestUserModel
    {
        public Request RequestModel { get; set; }
        public IEnumerable<User> UserModel { get; set; }
    }
}
