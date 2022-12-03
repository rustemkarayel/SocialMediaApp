using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PostLike
    {
        [Key]
        public int PostLikeId { get; set; }
        [StringLength(5)]
        public string LikeTime { get; set; }
    }
}
