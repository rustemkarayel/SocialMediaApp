﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EntityLayer
{
    public class Admin : BaseEntity
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
        [StringLength(100)]
        public string imgUrl { get; set; }

        [NotMapped]
        public IFormFile imgFile { get; set; }
        public bool IsActive { get; set; }

    }
}
