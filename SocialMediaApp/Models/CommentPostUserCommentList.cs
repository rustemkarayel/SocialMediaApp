using EntityLayer;

namespace SocialMediaApp.Models
{
    public class CommentPostUserCommentList
    {
        public Comment CommentModel { get; set; }
        public IEnumerable<Comment> CommentListModel { get; set; }
        public IEnumerable<Post> PostModel { get; set; }
        public IEnumerable<User> UserModel { get; set; }
    }
}
