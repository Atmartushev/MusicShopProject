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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Songs.ToListAsync());
        }

        // GET: MusicStore/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs
                .FirstOrDefaultAsync(m => m.SongsID == id);
            if (songs == null)
            {
                return NotFound();
            }

            return View(songs);
        }

        // GET: MusicStore/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusicStore/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongsID,Name,Artist,Genre,Date_Added,Song_Length,Download_Size,Price")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(songs);
        }
    }
}
