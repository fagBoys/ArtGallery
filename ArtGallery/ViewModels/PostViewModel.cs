using ArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.ViewModels
{
    public class PostViewModel
    {
        public Post Post { get; set; }

        public ICollection<Comment> PostComments { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
