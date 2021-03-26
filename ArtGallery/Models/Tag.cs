﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models
{
    public class Tag
    {
        [Key]
        public int Tagid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


    }
}