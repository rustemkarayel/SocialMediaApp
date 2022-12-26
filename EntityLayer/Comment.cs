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

        [StringLength(5)]
        public string Content { get; set; }
        public DateTime CommentTime { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public Post Post { get; set; }

        //User ile ilişkilendirilecek.
        [ForeignKey("User")]
        public int CommentorId { get; set; }
        public User Commentor { get; set; }

        //Kendiyle ilişkilenecek.
        [ForeignKey("ParentComment")]
        public int ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }
    }
}
