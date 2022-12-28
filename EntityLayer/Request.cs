using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }        
        public DateTime RequestTime { get; set; }
        public bool RequestState { get; set; }
        //User ile ilişkilendirilecek.
        [ForeignKey("Follower")]
        public int  FollowerId{ get; set; }
        public User Follower { get; set; }
        [ForeignKey("Following")]
        public int FollowingId { get; set; }
        public User Following { get; set; }
    }
}
