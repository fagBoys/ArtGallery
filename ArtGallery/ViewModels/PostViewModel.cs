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

        public Account Account { get; set; }

        public ICollection<Image> Images { get; set; }

        public ICollection<Comment> PostComments { get; set; }

        public ICollection<PostTag> Tags { get; set; }
    }
}
