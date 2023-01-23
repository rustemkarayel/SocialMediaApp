using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CommentLike : BaseEntity
	{
        [Key]
        public int CommentLikeId { get; set; }        
        public DateTime CommentLikeTime { get; set; }
        public bool IsActive { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public virtual User CommentLiker { get; set; }

        //Comment ile ilişkilendirilecek.
        public int CommentId {get; set;}
        public virtual Comment Comment {get; set;}

    }
}
