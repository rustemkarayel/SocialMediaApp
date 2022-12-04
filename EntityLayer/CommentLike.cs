﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class CommentLike
    {
        [Key]
        public int CommentLikeId { get; set; }        
        public DateTime CommentLikeTime { get; set; }
        //User ile ilişkilendirilecek.
        [ForeignKey("CommentLiker")]
        public int CommentLikerId { get; set; }
        public User CommentLiker { get; set; }
    }
}
