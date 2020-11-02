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
        public int FollowingID { get; set; }


        public int PrimaryID { get; set; }
        
        public int AccountID { get; set; }



    }
}
