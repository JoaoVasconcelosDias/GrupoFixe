using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project1.Data;
using Project1.Models;
using PagedList;


namespace Project1.Controllers
{
    public class HTMLController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HTMLController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HTML
        public async Task<IActionResult> Index()
        {
            return View(await _context.HTMLModel.ToListAsync());
        }

        // GET: HTML/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hTMLModel = await _context.HTMLModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hTMLModel == null)
            {
                return NotFound();
            }

            return View(hTMLModel);
        }

        // GET: HTML/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HTML/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,RespostaCerta,Respostadada,IDuser")] HTMLModel hTMLModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hTMLModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hTMLModel);
        }

        // GET: HTML/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hTMLModel = await _context.HTMLModel.SingleOrDefaultAsync(m => m.ID == id);
            if (hTMLModel == null)
            {
                return NotFound();
            }
            return View(hTMLModel);
        }

        // POST: HTML/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,RespostaCerta,Respostadada,IDuser")] HTMLModel hTMLModel)
        {
            if (id != hTMLModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hTMLModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HTMLModelExists(hTMLModel.ID))
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
            return View(hTMLModel);
        }

        // GET: HTML/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hTMLModel = await _context.HTMLModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (hTMLModel == null)
            {
                return NotFound();
            }

            return View(hTMLModel);
        }

        // POST: HTML/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hTMLModel = await _context.HTMLModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.HTMLModel.Remove(hTMLModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HTMLModelExists(int id)
        {
            return _context.HTMLModel.Any(e => e.ID == id);
        }
    }
}
