using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        public Byte[] PostImage { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Caption { get; set; }

        [Required]
        [MaxLength(50)]
        public DateTime Date { get; set; }
    }
}
