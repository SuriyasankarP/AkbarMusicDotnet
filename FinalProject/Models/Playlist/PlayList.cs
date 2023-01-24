using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.Playlist
{
    public class PlayList
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PlaylistName { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
