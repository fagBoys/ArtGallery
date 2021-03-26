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
        public int PostTagid { get; set; }
 
        public int Postid { get; set; }

        public int Tagid { get; set; }
    }
}
