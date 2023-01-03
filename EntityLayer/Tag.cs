using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        //Post ile ilikilendirilecek.
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        //User ile ilişkilendirilecek.
        public int UserId { get; set; }
        public virtual User TaggedUser { get; set; }
    }
}
