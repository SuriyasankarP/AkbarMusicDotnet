using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;

namespace FinalProject
{
    [Route("playlist")]
    [ApiController]
    public class PlayListsController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public PlayListsController(FinalProjectContext context)
        {
            _context = context;
        }

      
        

        
        [HttpGet]
        public async Task<ActionResult<List<PlayList>>> GetPlayList(int UserId)
        {
            var playList = await _context.PlayList.Where(u => u.UserId == UserId).ToListAsync();

            if (playList == null)
            {
                return Ok("No Playlist");
            }

            return playList;
        }
        [HttpPost]
        public async Task<ActionResult<List<PlayList>>> Create(PlayList Playlist)
        {
            var user = await _context.User.FindAsync(Playlist.UserId);
            if (user == null)
            {
                return NotFound();
            }

            _context.PlayList.Add(Playlist);
            await _context.SaveChangesAsync();
            return Ok();
    }


    [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayList(int id)
        {
            var playList = await _context.PlayList.FindAsync(id);
            if (playList == null)
            {
                return NotFound();
            }

            _context.PlayList.Remove(playList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayListExists(int id)
        {
            return _context.PlayList.Any(e => e.Id == id);
        }
    }
}
