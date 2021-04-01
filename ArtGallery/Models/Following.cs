using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Following
    {
        [Key]
        public int FollowingId { get; set; }


        public int PrimaryId { get; set; }
        
        public int AccountId { get; set; }



    }
}
