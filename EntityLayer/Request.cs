using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        [StringLength(5)]
        public string RequestTime { get; set; }
        public bool RequestState { get; set; }
        //Users ile ilişkilendirilecek.
    }
}
