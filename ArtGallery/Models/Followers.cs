using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Followers
    {
        [Key]
        public int FollowersID { get; set; }

        public int PrimaryID { get; set; }


        public int AID { get; set; }

    }
}
