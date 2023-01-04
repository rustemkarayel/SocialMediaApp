using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(30)]
        public string AdminFirstName { get; set; }

        [StringLength(30)]
        public string AdminLastName { get; set; }

        [StringLength(30)]
        public string AdminMail { get; set; }

        [StringLength(15)]
        public string AdminPassword { get; set; }

        [StringLength(15)]
        public string AdminType { get; set; }
        public bool IsActive { get; set; }
    }
}
