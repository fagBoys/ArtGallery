using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.ViewModels
{
    public class AddPostViewModel
    {
        public IFormFile PostImage { get; set; }
        
        public string Caption { get; set; }
    }
}
