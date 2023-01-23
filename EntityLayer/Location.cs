using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Location : BaseEntity
	{
        [Key]
        public int LocationId { get; set; }

        [StringLength(50)]
        public string LocationName { get; set; }
        public bool IsActive { get; set; }

        //Post ile ilişkilendirilecek.
        public virtual ICollection<Post> Posts { get; set; }
    }
}
