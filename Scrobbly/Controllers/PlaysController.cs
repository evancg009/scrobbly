using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Scrobbly.Models;

namespace Scrobbly.Controllers
{
    public class PlaysController : Controller
    {
        private readonly musicContext _context;

        public PlaysController(musicContext context)
        {
            _context = context;
        }

        // GET: Plays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Play.ToListAsync());
        }

        // GET: Plays/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Play
                .FirstOrDefaultAsync(m => m.Id == id);
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // GET: Plays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,AlbumName,ArtistIds,ArtistNames,Dirty,ListenTime,Popularity,TrackId,TrackName,SourceOf")] Play play)
        {
            if (ModelState.IsValid)
            {
                play.Id = Guid.NewGuid();
                _context.Add(play);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(play);
        }

        // GET: Plays/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Play.FindAsync(id);
            if (play == null)
            {
                return NotFound();
            }
            return View(play);
        }

        // POST: Plays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,AlbumId,AlbumName,ArtistIds,ArtistNames,Dirty,ListenTime,Popularity,TrackId,TrackName,SourceOf")] Play play)
        {
            if (id != play.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(play);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayExists(play.Id))
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
            return View(play);
        }

        // GET: Plays/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Play
                .FirstOrDefaultAsync(m => m.Id == id);
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // POST: Plays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var play = await _context.Play.FindAsync(id);
            _context.Play.Remove(play);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayExists(Guid id)
        {
            return _context.Play.Any(e => e.Id == id);
        }
    }
}
