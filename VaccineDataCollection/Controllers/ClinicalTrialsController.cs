using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccineDataCollection.Data;
using VaccineDataCollection.Models;
using VaccineDataCollection.ViewModels;

namespace VaccineDataCollection.Controllers
{
    public class ClinicalTrialsController : Controller
    {
        private readonly VaccineDataCollectionContext _context;

        public ClinicalTrialsController(VaccineDataCollectionContext context)
        {
            _context = context;
        }

        // GET: ClinicalTrials
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClinicalTrial.ToListAsync());
        }

        // GET: ClinicalTrials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalTrial = await _context.ClinicalTrial
                .FirstOrDefaultAsync(m => m.TrialID == id);
            if (clinicalTrial == null)
            {
                return NotFound();
            }

            return View(clinicalTrial);
        }

        // GET: ClinicalTrials/Create
        public IActionResult Create()
        {
            var clinicalTrialForm = new ClinicalTrialForm();
            clinicalTrialForm.VaccineList = _context.Vaccine
                          .Select(a => new SelectListItem()
                          {
                              Value = a.VaccineID.ToString(),
                              Text = a.VaccineName
                          })
                          .ToList();
            return View(clinicalTrialForm);
        }

        // POST: ClinicalTrials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrialID,TrialName,TrialDesc,TrialLocation,VaccineID")] ClinicalTrial clinicalTrial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicalTrial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(clinicalTrial);
        }

        // GET: ClinicalTrials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var clinicalTrialForm = new ClinicalTrialForm();
            clinicalTrialForm.ClinicalTrial = await _context.ClinicalTrial.FindAsync(id);
            if (clinicalTrialForm == null)
            {
                return NotFound();
            }
            clinicalTrialForm.VaccineList = _context.Vaccine
                         .Select(a => new SelectListItem()
                         {
                             Value = a.VaccineID.ToString(),
                             Text = a.VaccineName
                         })
                         .ToList();
            return View(clinicalTrialForm);
        }

        // POST: ClinicalTrials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrialID,TrialName,TrialDesc,TrialLocation,VaccineID")] ClinicalTrial clinicalTrial)
        {
            if (id != clinicalTrial.TrialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicalTrial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicalTrialExists(clinicalTrial.TrialID))
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
            return View(clinicalTrial);
        }

        // GET: ClinicalTrials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalTrial = await _context.ClinicalTrial
                .FirstOrDefaultAsync(m => m.TrialID == id);
            if (clinicalTrial == null)
            {
                return NotFound();
            }

            return View(clinicalTrial);
        }

        // POST: ClinicalTrials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinicalTrial = await _context.ClinicalTrial.FindAsync(id);
            _context.ClinicalTrial.Remove(clinicalTrial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicalTrialExists(int id)
        {
            return _context.ClinicalTrial.Any(e => e.TrialID == id);
        }
        public IEnumerable<Vaccine> GetVaccines()
        {
            return _context.Vaccine.ToList();
        }
    }
}
