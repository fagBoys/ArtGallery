using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Comment
    {
            [Key]
            public int Commentid { get; set; }

            [Required]
            [MaxLength(50)]
            public string  Text { get; set; }
         
            public int    postid { get; set; }

            public string  Userid { get; set; }

            [Required]
            [MaxLength(50)]
            public string Confirmation { get; set; }
    }
}
