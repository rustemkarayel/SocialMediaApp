using EntityLayer;

namespace SocialMediaApp.Models
{
    public class MessageUserModel
    {
        public Message MessageModel { get; set; }
        public IEnumerable<User> UserModel { get; set; }
    }
}
