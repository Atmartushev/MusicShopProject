using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicShopProject.Data;
using MusicShopProject.Models;

namespace MusicShopProject.Controllers
{
    public class MusicStoreController : Controller
    {
        private readonly MusicShopProjectContext _context;

        public MusicStoreController(MusicShopProjectContext context)
        {
            _context = context;
        }

        // GET: MusicStore
        public async Task<IActionResult> Index(string searchName, string searchArtist, string searchGenre)
        {
            var query = _context.Songs.AsQueryable();

            // Apply filters based on the search criteria
            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(s => s.Name.Contains(searchName));
            }

            if (!string.IsNullOrEmpty(searchArtist))
            {
                query = query.Where(s => s.Artist.Contains(searchArtist));
            }

            if (!string.IsNullOrEmpty(searchGenre))
            {
                query = query.Where(s => s.Genre.Contains(searchGenre));
            }

            var filteredSongs = await query.ToListAsync();

            return View(filteredSongs);
        }


    }
}
