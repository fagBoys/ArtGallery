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
        public int ImageId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImageAddress { get; set; }

      
        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<Image> Images { get; set; }

    }
}
