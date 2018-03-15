using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JDR.Data;
using VousEtesLeHeros.Models.BO.Personnes;

namespace JDR.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonnesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personnes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Personnes.Include(p => p.CategoriePersonne);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Personnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes
                .Include(p => p.CategoriePersonne)
                .SingleOrDefaultAsync(m => m.PersonneID == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // GET: Personnes/Create
        public IActionResult Create()
        {
            ViewData["CategoriePersonneID"] = new SelectList(_context.CategoriePersonnes, "CategoriePersonneId", "CategoriePersonneId");
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonneID,Nom,Intelligence,Dexterite,Force,Vie,Experience,Niveau,CategoriePersonneID")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoriePersonneID"] = new SelectList(_context.CategoriePersonnes, "CategoriePersonneId", "Titre", personne.CategoriePersonneID);
            ViewBag.CategoriePersonneID = new SelectList(_context.CategoriePersonnes, "toto", "caca", personne.CategoriePersonneID);
            return View(personne);
        }

        // GET: Personnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes.SingleOrDefaultAsync(m => m.PersonneID == id);
            if (personne == null)
            {
                return NotFound();
            }
            ViewData["CategoriePersonneID"] = new SelectList(_context.CategoriePersonnes, "CategoriePersonneId", "CategoriePersonneId", personne.CategoriePersonneID);
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonneID,Nom,Intelligence,Dexterite,Force,Vie,Experience,Niveau,CategoriePersonneID")] Personne personne)
        {
            if (id != personne.PersonneID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(personne.PersonneID))
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
            ViewData["CategoriePersonneID"] = new SelectList(_context.CategoriePersonnes, "CategoriePersonneId", "CategoriePersonneId", personne.CategoriePersonneID);
            return View(personne);
        }

        // GET: Personnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Personnes
                .Include(p => p.CategoriePersonne)
                .SingleOrDefaultAsync(m => m.PersonneID == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personne = await _context.Personnes.SingleOrDefaultAsync(m => m.PersonneID == id);
            _context.Personnes.Remove(personne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneExists(int id)
        {
            return _context.Personnes.Any(e => e.PersonneID == id);
        }
    }
}
