

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.Models.Song
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
       
        public string PosterLink { get; set; } 

        public string Name { get; set; }

        public string Album { get; set; }

        public string Director { get; set; }
        
        public string FileLink { get; set; }




    }
}
