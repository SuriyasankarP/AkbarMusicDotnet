using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Models.Song;
using FinalProject.Models.Playlist;

namespace FinalProject.Data
{
    public class FinalProjectContext : DbContext
    {
        public FinalProjectContext (DbContextOptions<FinalProjectContext> options)
            : base(options)
        {
        }

        public DbSet<FinalProject.Models.User> User { get; set; } = default!;

        public DbSet<FinalProject.Models.Song.Song> Song { get; set; }

        public DbSet<FinalProject.Models.Playlist.PlayList> PlayList { get; set; }
        public DbSet<FinalProject.Models.Song.PlayListSong> PlayListSong { get; set; }

    }
}
