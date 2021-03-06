﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace ArtGallery.Models
{
    public class Comment
    {
            [Key]
            public int CommentId { get; set; }

            [Required]
            [MaxLength(500)]
            public string Text { get; set; }
         
            public int PostId { get; set; }

            public string  UserId { get; set; }

            [Required]
            [MaxLength(50)]
            public string Confirmation { get; set; }

            public Post Post { get; set; }
         
        
            [Required]
            [MaxLength(50)]
            public DateTime Date { get; set; }


            public Account Account { get; set; }

    }
}
