using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CommentLike
    {
        [Key]
        public int CommentLikeId { get; set; }
        [StringLength(5)]
        public string CommentLikeTime { get; set; }
    }
}
