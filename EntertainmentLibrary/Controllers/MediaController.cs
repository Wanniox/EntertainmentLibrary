using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntertainmentLibrary.Data;
using EntertainmentLibrary.Models;

namespace EntertainmentLibrary.Controllers
{
    public class MediaController : Controller
    {
        private readonly EntertainmentLibraryContext _context;

        public MediaController(EntertainmentLibraryContext context)
        {
            _context = context;
        }

        // GET: MediaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.MediaModel.ToListAsync());
        }

        // GET: MediaModels/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaModel = await _context.MediaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaModel == null)
            {
                return NotFound();
            }

            return View(mediaModel);
        }

        // GET: MediaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MediaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Quality,hasSubs,uploader")] MediaModel mediaModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mediaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mediaModel);
        }

        // GET: MediaModels/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaModel = await _context.MediaModel.FindAsync(id);
            if (mediaModel == null)
            {
                return NotFound();
            }
            return View(mediaModel);
        }

        // POST: MediaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Title,Quality,hasSubs,uploader")] MediaModel mediaModel)
        {
            if (id != mediaModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mediaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MediaModelExists(mediaModel.Id))
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
            return View(mediaModel);
        }

        // GET: MediaModels/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mediaModel = await _context.MediaModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mediaModel == null)
            {
                return NotFound();
            }

            return View(mediaModel);
        }

        // POST: MediaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var mediaModel = await _context.MediaModel.FindAsync(id);
            if (mediaModel != null)
            {
                _context.MediaModel.Remove(mediaModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MediaModelExists(string id)
        {
            return _context.MediaModel.Any(e => e.Id == id);
        }
    }
}
