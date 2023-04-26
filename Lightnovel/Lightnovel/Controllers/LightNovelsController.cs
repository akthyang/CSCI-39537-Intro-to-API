using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightNovel.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            response.statusDescription = "Success. Below is the novel for id " + id;
            if (id == null || _context.Novels == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: Id is invalid or the database is empty";
            }

            var novel = await _context.Novels
                .Include(n => n.Comic)
                .Include(n => n.Creator)
                .Include(n => n.Raw)
                .FirstOrDefaultAsync(m => m.NovelId == id);
            if (novel == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: The novel at id " + id + " does not exist.";
            }

            response.novels.Add(novel);

            return View(response);
        }

        // GET: LightNovels/Create
        public IActionResult Create()
        {
            var response = new Models.Response();
            response.statusCode = 200;
            response.statusDescription = "Success: You are currently adding a new novel to the database.";

            var newNovel = new Novel();
            response.novels.Add(newNovel);
            ViewData["Comic"] = new SelectList(_context.Comics, "ComicId", "Title");
            ViewData["Creator"] = new SelectList(_context.Creators, "CreatorId", "FullName");
            ViewData["Raw"] = new SelectList(_context.Raws, "RawId", "Title");
            return View(response);
        }

        // POST: LightNovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Models.Response>> Create(Models.Response response)
        {
            Novel novel = response.novels[0];
            response.statusCode = 400;
            response.statusDescription = "Opps. We weren't able to create this novel. Please try again.";
            if (novel != null)
            {
                _context.Add(novel);
                await _context.SaveChangesAsync();
                response.statusCode = 200;
                response.statusDescription = "We have successfully created your novel";
            }

            ViewData["Comic"] = new SelectList(_context.Comics, "ComicId", "Title", novel.ComicId);
            ViewData["Creator"] = new SelectList(_context.Creators, "CreatorId", "FullName", novel.CreatorId);
            ViewData["Raw"] = new SelectList(_context.Raws, "RawId", "Title", novel.RawId);

            return View(response);
        }

        // GET: LightNovels/Edit/5
        public async Task<ActionResult<Models.Response>> Edit(int? id)
        {
            var response = new Models.Response();
            response.statusCode = 200;
            response.statusDescription = "You are currently editing novel at id " + id;
            if (id == null || _context.Novels == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: Id is empty or database is empty.";
            }

            var novel = await _context.Novels.FindAsync(id);
            response.novels.Add(novel);

            if (novel == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: Novel at id " + id + "does not exist.";
            }
            ViewData["ComicId"] = new SelectList(_context.Comics, "ComicId", "Title", novel.ComicId);
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "FullName", novel.CreatorId);
            ViewData["RawId"] = new SelectList(_context.Raws, "RawId", "Title", novel.RawId);
            return View(response);
        }

        // POST: LightNovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Models.Response>> Edit(Models.Response response)
        {
            response.statusCode = 200;
            Novel novel = response.novels[0];
            response.statusDescription = "Your novel was successfully added";
            if (novel != null)
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
                        response.statusCode = 400;
                        response.statusDescription = "Failed: The novel you are trying to edit does not exist.";
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ComicId"] = new SelectList(_context.Comics, "ComicId", "Title", novel.ComicId);
            ViewData["CreatorId"] = new SelectList(_context.Creators, "CreatorId", "FullName", novel.CreatorId);
            ViewData["RawId"] = new SelectList(_context.Raws, "RawId", "Title", novel.RawId);
            return View(response);
        }

        // GET: LightNovels/Delete/5
        public async Task<ActionResult<Models.Response>> Delete(int? id)
        {
            var response = new Models.Response();
            response.statusCode = 200;
            response.statusDescription = "Success: You are currently deleting the novel at id " + id;
            if (id == null || _context.Novels == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: Id is empty or the database is empty.";
            }

            var novel = await _context.Novels
                .Include(n => n.Comic)
                .Include(n => n.Creator)
                .Include(n => n.Raw)
                .FirstOrDefaultAsync(m => m.NovelId == id);

            response.novels.Add(novel);

            if (novel == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: The novel at id " + id + "does not exist";
            }

            return View(response);
        }

        // POST: LightNovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Models.Response>> DeleteConfirmed(int id)
        {
            var response = new Models.Response();
            response.statusCode = 200;
            response.statusDescription = "Success: You have deleted the novel at id " + id;

            if (_context.Novels == null)
            {
                response.statusCode = 400;
                response.statusDescription = "Failed: Entity set 'LightNovelDBContext.Novels'  is null.";
            }
            var novel = await _context.Novels.FindAsync(id);
            if (novel != null)
            {
                _context.Novels.Remove(novel);
            }
            
            await _context.SaveChangesAsync();
            return View(response);
        }

        private bool NovelExists(int id)
        {
          return (_context.Novels?.Any(e => e.NovelId == id)).GetValueOrDefault();
        }
    }
}
