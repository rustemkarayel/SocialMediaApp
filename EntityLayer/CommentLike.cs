using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CommentLike
    {
        [Key]
        public int CommentLikeId { get; set; }        
        public DateTime CommentLikeTime { get; set; }
<<<<<<< HEAD

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public User CommentLiker { get; set; }

        //Comment ile ilişkilendirilecek.
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
=======
        //User ile ilişkilendirilecek.        
        public int CommentLikerId { get; set; }
        public User CommentLiker { get; set; }
        //Comment ile ilişkilendirilecek.
        public int CommentId {get; set;}
        public Comment Comment {get; set;}
>>>>>>> 7c22d1494c4d32f53d7ca8e373adcb54a336d9fa
    }
}
