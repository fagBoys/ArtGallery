using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class PostTag
    {

        [Key]
        public int PostTagId { get; set; }
 
        public int PostId { get; set; }

        public int TagId { get; set; }

        public Post Post { get; set; }

        public  Tag  Tag{ get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
