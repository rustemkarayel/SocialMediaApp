using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string NickName { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(50)]
        public string PhotoUrl{ get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }
        [StringLength(50)]
        public string Country { get; set; }
        public bool Gender { get; set; }

        //Request ile ilişkilendirilecek.
        [InverseProperty("Follower")]
        public ICollection<Request> FollowerRequests { get; set; }
        [InverseProperty("Following")]
        public ICollection<Request> FollowingRequests { get; set; }

        //Message ile ilişkilendirilecek.
        [InverseProperty("Sender")]
        public ICollection<Message> SenderMessages { get; set; }
        [InverseProperty("Receiver")]
        public ICollection<Message> ReceiverMessages { get; set; }

        //CommentLike ile ilişkilendirilecek.
        public ICollection<CommentLike> CommentLikes { get; set; }

        //Comment ile ilişkilendirilecek.
        public ICollection<Comment> Comments { get; set; }

        //Post ile ilişkilendirilecek.
        public ICollection<Post> Posts { get; set; }

        //Tag ile ilişkilendirilecek.
        public ICollection<Tag> Tags { get; set; }

        //PostLike ile ilişkilendirilecek.
        public ICollection<PostLike> PostLikes { get; set; }

        //Saved ile ilişkilendirilecek.
        public ICollection<Saved> Saveds { get; set; }

    }
}
