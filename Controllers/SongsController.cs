using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicShopProject.Data;
using MusicShopProject.Models;

namespace MusicShopProject.Controllers
{
    public class SongsController : Controller
    {
        private readonly MusicShopProjectContext _context;

        public SongsController(MusicShopProjectContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index(string SearchName, string SearchArtist, string SearchGenre)
        {
            var showAll = from m in _context.Songs
                          select m;

            if (!String.IsNullOrEmpty(SearchName))
            {
                showAll = showAll.Where(s => s.Name.Contains(SearchName));

            }
            if (!String.IsNullOrEmpty(SearchArtist))
            {

                showAll = showAll.Where(s => s.Artist.Contains(SearchArtist));
            }
            if (!String.IsNullOrEmpty(SearchGenre))
            {

                showAll = showAll.Where(s => s.Genre.Contains(SearchGenre));
            }

            return View(await showAll.ToListAsync());

        }

        // GET: Songs/Details/5
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

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
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

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }
            return View(songs);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SongsID,Name,Artist,Genre,Date_Added,Song_Length,Download_Size,Price")] Songs songs)
        {
            if (id != songs.SongsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongsExists(songs.SongsID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(songs);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            if (songs != null)
            {
                _context.Songs.Remove(songs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.SongsID == id);
        }
    }
}
