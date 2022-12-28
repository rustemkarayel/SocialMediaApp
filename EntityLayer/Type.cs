using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Type
    {
        [Key]
        public int TypeId { get; set; }

        [StringLength(25)]
        public string TypeName { get; set; }

        //Post ile ilişkilendirilecek.
        public ICollection<Post> Posts { get; set; }
    }
}
