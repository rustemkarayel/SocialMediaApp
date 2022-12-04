using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }        
        public DateTime GenerateDate { get; set; }
        public int Content { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        //User ile ilişkilendirilecek.
        [ForeignKey("Creator")]
        public int CreatorId { get; set; }
        public User Creator { get; set; }
    }
}
