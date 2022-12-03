using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [StringLength(10)]
        public string GenerateDate { get; set; }
        public int Content { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
    }
}
