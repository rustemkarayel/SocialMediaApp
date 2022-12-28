using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class PostLike
    {
        [Key]
        public int PostLikeId { get; set; }        
        public DateTime LikeTime { get; set; }
       
        //User ile ilişkilendirilecek.        
        public ICollection<User> PostLikers;
       
        //Post ile ilişkilendirilecek.
        public ICollection<Post> Posts {get; set;}
    }
}
