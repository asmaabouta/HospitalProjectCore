using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientWebApp.Data;
using PatientWebApp.Models;

namespace PatientWebApp.Controllers
{
    public class RendezVousController : Controller
    {
        private readonly PatientDbContext _context;

        public RendezVousController(PatientDbContext context)
        {
            _context = context;
        }

        // GET: RendezVous
        public async Task<IActionResult> Index()
        {
            var patientDbContext = _context.RendezVous.Include(r => r.Medecin).Include(r => r.Patient);
            return View(await patientDbContext.ToListAsync());
        }

        // GET: RendezVous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _context.RendezVous
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            return View(rendezVous);
        }

        // GET: RendezVous/Create
        public IActionResult Create()
        {
            ViewData["MedecinID"] = new SelectList(_context.Medecin, "ID", "ID");
            ViewData["PatientID"] = new SelectList(_context.Set<Patient>(), "Id", "Id");
            return View();
        }

        // POST: RendezVous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,dateRendezVous,Valider,PatientID,MedecinID")] RendezVous rendezVous)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rendezVous);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MedecinID"] = new SelectList(_context.Medecin, "ID", "ID", rendezVous.MedecinID);
            ViewData["PatientID"] = new SelectList(_context.Set<Patient>(), "Id", "Id", rendezVous.PatientID);
            return View(rendezVous);
        }

        // GET: RendezVous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _context.RendezVous.FindAsync(id);
            if (rendezVous == null)
            {
                return NotFound();
            }
            ViewData["MedecinID"] = new SelectList(_context.Medecin, "ID", "ID", rendezVous.MedecinID);
            ViewData["PatientID"] = new SelectList(_context.Set<Patient>(), "Id", "Id", rendezVous.PatientID);
            return View(rendezVous);
        }

        // POST: RendezVous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,dateRendezVous,Valider,PatientID,MedecinID")] RendezVous rendezVous)
        {
            if (id != rendezVous.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rendezVous);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RendezVousExists(rendezVous.ID))
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
            ViewData["MedecinID"] = new SelectList(_context.Medecin, "ID", "ID", rendezVous.MedecinID);
            ViewData["PatientID"] = new SelectList(_context.Set<Patient>(), "Id", "Id", rendezVous.PatientID);
            return View(rendezVous);
        }

        // GET: RendezVous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rendezVous = await _context.RendezVous
                .Include(r => r.Medecin)
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (rendezVous == null)
            {
                return NotFound();
            }

            return View(rendezVous);
        }

        // POST: RendezVous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rendezVous = await _context.RendezVous.FindAsync(id);
            _context.RendezVous.Remove(rendezVous);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RendezVousExists(int id)
        {
            return _context.RendezVous.Any(e => e.ID == id);
        }
    }
}
