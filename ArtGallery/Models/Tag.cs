using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public int PostTagId { get; set; }
        public ICollection<PostTag> PostTags { get; set; }

    }
}
