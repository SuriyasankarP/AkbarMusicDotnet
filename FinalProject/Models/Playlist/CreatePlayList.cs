using Microsoft.Build.Framework;

namespace FinalProject.Models.Playlist
{
    public class CreatePlayList
    {
        [Required]
        public string PlaylistName { get; set; } = "Default";
        [Required]
        public int UserId { get; set; } = 1;
    }
}
