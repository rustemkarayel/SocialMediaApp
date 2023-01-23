using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PostLike : BaseEntity
	{
        [Key]
        public int PostLikeId { get; set; }        
        public DateTime LikeTime { get; set; }
        public bool IsActive { get; set; }

        //User ile ilişkilendirilecek.        
        public int UserId { get; set; }
        public virtual User PostLiker { get; set; }

        //Post ile ilişkilendirilecek.
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

    }
}
