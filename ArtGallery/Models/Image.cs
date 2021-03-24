using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Image
    {
        [Key]
        public int Imageid { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImageAddress { get; set; }

      
        public string Postid { get; set; }

    }
}
