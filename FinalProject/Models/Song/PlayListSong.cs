using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models.Song
{
    public class PlayListSong
    {
        [Key]
        public int Id { get; set; }

        public int SongId { get; set; }

        public int PlayListId { get; set; }

        public int UserId { get; set; }
    }
}
