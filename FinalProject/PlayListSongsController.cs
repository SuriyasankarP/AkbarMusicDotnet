﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models.Song;
using FinalProject.Models;

namespace FinalProject
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayListSongsController : ControllerBase
    {
        private readonly FinalProjectContext _context;

        public PlayListSongsController(FinalProjectContext context)
        {
            _context = context;
        }

        // GET: api/PlayListSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayListSong>>> GetPlayListSong(int UserId,int PlayListId)
        {
            var ListSongs= await _context.PlayListSong.Where(u => u.UserId == UserId && u.PlayListId==PlayListId ).ToListAsync();

            return ListSongs;
        }

        

        // POST: api/PlayListSongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlayListSong>> PostPlayListSong(PlayListSong playListSong)
        {
            _context.PlayListSong.Add(playListSong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayListSong", new { id = playListSong.Id }, playListSong);
        }

        // DELETE: api/PlayListSongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayListSong(int id)
        {
            var playListSong = await _context.PlayListSong.FindAsync(id);
            if (playListSong == null)
            {
                return NotFound();
            }

            _context.PlayListSong.Remove(playListSong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlayListSongExists(int id)
        {
            return _context.PlayListSong.Any(e => e.Id == id);
        }
    }
}
