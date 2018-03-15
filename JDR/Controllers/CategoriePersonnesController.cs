using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JDR.Data;

namespace JDR.Controllers
{
    public class CategoriePersonnesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriePersonnesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriePersonnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriePersonnes.ToListAsync());
        }

        // GET: CategoriePersonnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriePersonne = await _context.CategoriePersonnes
                .SingleOrDefaultAsync(m => m.CategoriePersonneId == id);
            if (categoriePersonne == null)
            {
                return NotFound();
            }

            return View(categoriePersonne);
        }

        // GET: CategoriePersonnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriePersonnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriePersonneId,Titre")] CategoriePersonne categoriePersonne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriePersonne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriePersonne);
        }

        // GET: CategoriePersonnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriePersonne = await _context.CategoriePersonnes.SingleOrDefaultAsync(m => m.CategoriePersonneId == id);
            if (categoriePersonne == null)
            {
                return NotFound();
            }
            return View(categoriePersonne);
        }

        // POST: CategoriePersonnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriePersonneId,Titre")] CategoriePersonne categoriePersonne)
        {
            if (id != categoriePersonne.CategoriePersonneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriePersonne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriePersonneExists(categoriePersonne.CategoriePersonneId))
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
            return View(categoriePersonne);
        }

        // GET: CategoriePersonnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriePersonne = await _context.CategoriePersonnes
                .SingleOrDefaultAsync(m => m.CategoriePersonneId == id);
            if (categoriePersonne == null)
            {
                return NotFound();
            }

            return View(categoriePersonne);
        }

        // POST: CategoriePersonnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriePersonne = await _context.CategoriePersonnes.SingleOrDefaultAsync(m => m.CategoriePersonneId == id);
            _context.CategoriePersonnes.Remove(categoriePersonne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriePersonneExists(int id)
        {
            return _context.CategoriePersonnes.Any(e => e.CategoriePersonneId == id);
        }
    }
}
