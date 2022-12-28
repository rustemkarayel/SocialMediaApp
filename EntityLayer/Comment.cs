using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [StringLength(100)]
        public string Content { get; set; }

        public DateTime CommentTime { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public Post Post { get; set; }

        //User ile ilişkilendirilecek.
<<<<<<< HEAD
        public int UserId { get; set; }
=======
        public int CommentorId { get; set; }
>>>>>>> 49ccecc3040512942bb3ab516169c1e3a7ff2cb6
        public User Commentor { get; set; }

        //Kendiyle ilişkilenecek.
        [ForeignKey("ParentComment")]
        public int ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
    }
}
