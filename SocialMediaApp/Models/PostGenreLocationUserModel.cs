using EntityLayer;

namespace SocialMediaApp.Models
{
    public class PostGenreLocationUserModel
    {
        public Post PostModel { get; set; }
        public IEnumerable<Genre> GenreModel { get; set; }
        public IEnumerable<Location> LocationModel { get; set; }     
        public IEnumerable<User> UserModel { get; set; }
    }
}
