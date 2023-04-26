using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightNovel.Models;

namespace Lightnovel.Controllers
{
    public class LightNovelsController : Controller
    {
        private readonly LightNovelDBContext _context;

        public LightNovelsController(LightNovelDBContext context)
        {
            _context = context;
        }

        // GET: LightNovels
        public async Task<ActionResult<Models.Response>> Index()
        {
            var lightNovelDBContext = _context.Novels.Include(n => n.Comic).Include(n => n.Creator).Include(n => n.Raw);
            var response = new Models.Response();
            response.statusCode = 200;
            response.statusDescription = "Success. All novels displayed.";
            response.novels = await lightNovelDBContext.OrderBy(b => b.Title).ToListAsync();
            return View(response);
        }

        // GET: LightNovels/Details/5
        public async Task<ActionResult<Models.Response>> Details(int? id)
        {
            var response = new Models.Response();
            // set as successful
            response.statusCode = 200;
            response.statusDescription = $"Novels {id}";
            response.statusDescription = "Success. Below is the novel for id " + id;
            if (id == null || _context.Novels == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Novel Id must be an integar.";
            }

            var novel = await _context.Novels
                .Include(n => n.Comic)
                .Include(n => n.Creator)
                .Include(n => n.Raw)
                .FirstOrDefaultAsync(m => m.NovelId == id);
            if (novel == null)
            {
                response.statusCode = 400;
                response.statusDescription = "The novel at the id you selected does not exist.";
            }

            response.novels.Add(novel);

            return View(response);
        }

        // GET: LightNovels/Create
        public IActionResult Create()
        {
            ViewData["ComicId"] = new SelectList(_context.Comics, "ComicId", "ComicId");
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "CreatorId");
            ViewData["RawId"] = new SelectList(_context.Raws, "RawId", "RawId");
            return View();
        }

        // POST: LightNovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovelId,Title,OriginalLanguage,Blurb,Rating,Genre,BookStatus,Link,CreatorId,ComicId,RawId")] Novel novel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComicId"] = new SelectList(_context.Comics, "ComicId", "ComicId", novel.ComicId);
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "CreatorId", novel.CreatorId);
            ViewData["RawId"] = new SelectList(_context.Raws, "RawId", "RawId", novel.RawId);
            return View(novel);
        }

        // GET: LightNovels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Novels == null)
            {
                return NotFound();
            }

            var novel = await _context.Novels.FindAsync(id);
            if (novel == null)
            {
                return NotFound();
            }
            ViewData["ComicId"] = new SelectList(_context.Comics, "ComicId", "ComicId", novel.ComicId);
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "CreatorId", novel.CreatorId);
            ViewData["RawId"] = new SelectList(_context.Raws, "RawId", "RawId", novel.RawId);
            return View(novel);
        }

        // POST: LightNovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovelId,Title,OriginalLanguage,Blurb,Rating,Genre,BookStatus,Link,CreatorId,ComicId,RawId")] Novel novel)
        {
            if (id != novel.NovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovelExists(novel.NovelId))
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
            ViewData["ComicId"] = new SelectList(_context.Comics, "ComicId", "ComicId", novel.ComicId);
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "CreatorId", novel.CreatorId);
            ViewData["RawId"] = new SelectList(_context.Raws, "RawId", "RawId", novel.RawId);
            return View(novel);
        }

        // GET: LightNovels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Novels == null)
            {
                return NotFound();
            }

            var novel = await _context.Novels
                .Include(n => n.Comic)
                .Include(n => n.Creator)
                .Include(n => n.Raw)
                .FirstOrDefaultAsync(m => m.NovelId == id);
            if (novel == null)
            {
                return NotFound();
            }

            return View(novel);
        }

        // POST: LightNovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Novels == null)
            {
                return Problem("Entity set 'LightNovelDBContext.Novels'  is null.");
            }
            var novel = await _context.Novels.FindAsync(id);
            if (novel != null)
            {
                _context.Novels.Remove(novel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovelExists(int id)
        {
          return (_context.Novels?.Any(e => e.NovelId == id)).GetValueOrDefault();
        }
    }
}
