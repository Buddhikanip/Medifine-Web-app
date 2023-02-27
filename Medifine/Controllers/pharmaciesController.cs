using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Medifine.Models;

namespace Medifine.Controllers
{
    public class pharmaciesController : Controller
    {
        private readonly MedifineContext _context;

        public pharmaciesController(MedifineContext context)
        {
            _context = context;
        }

        // GET: pharmacies
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pharmacies.ToListAsync());
        }

        // GET: pharmacies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pharmacies == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.PharmacyId == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // GET: pharmacies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: pharmacies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PharmacyId,PharmacyName,Email,Phone_Number,Pharmacy_License_Number,Password,Confirm_Password")] pharmacy pharmacy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pharmacy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pharmacy);
        }

        // GET: pharmacies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pharmacies == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }
            return View(pharmacy);
        }

        // POST: pharmacies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PharmacyId,PharmacyName,Email,Phone_Number,Pharmacy_License_Number,Password,Confirm_Password")] pharmacy pharmacy)
        {
            if (id != pharmacy.PharmacyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pharmacy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!pharmacyExists(pharmacy.PharmacyId))
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
            return View(pharmacy);
        }

        // GET: pharmacies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pharmacies == null)
            {
                return NotFound();
            }

            var pharmacy = await _context.Pharmacies
                .FirstOrDefaultAsync(m => m.PharmacyId == id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            return View(pharmacy);
        }

        // POST: pharmacies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pharmacies == null)
            {
                return Problem("Entity set 'MedifineContext.Pharmacies'  is null.");
            }
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy != null)
            {
                _context.Pharmacies.Remove(pharmacy);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool pharmacyExists(int id)
        {
          return _context.Pharmacies.Any(e => e.PharmacyId == id);
        }

        /*
        private readonly MedifineContext myDb;
        public pharmaciesController(MedifineContext schoolContext)
        {
            myDb = schoolContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = myDb.Pharmacies.Where(i => i.PharmacyName == "Asiri" && i.Phone_Number == "0713270510").OrderByDescending(i => i.PharmacyName);
            ViewBag.students = data;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(pharmacy PharmacyData)
        {
            pharmacy newPharmacy = new pharmacy()
            {
                PharmacyName = PharmacyData.PharmacyName,
                Email = PharmacyData.Email,
                Phone_Number = PharmacyData.Phone_Number,
                Pharmacy_License_Number = PharmacyData.Pharmacy_License_Number,
                Password = PharmacyData.Password,
                Confirm_Password = PharmacyData.Confirm_Password,
            };
            myDb.Pharmacies.Add(newPharmacy);
            myDb.SaveChanges();
            return RedirectToAction("Create");
        }
        //Update
        //1.Request data (Which data) by using ID
        //2.View data
        //3.Edit data
        //4.Post edited data to the table
        public IActionResult Edit(pharmacy pharmacy)
        {
            return View(pharmacy);
        }
        [HttpPost]
        public IActionResult Details(pharmacy d)
        {
            d = myDb.Pharmacies.Where(i => i.PharmacyId == d.PharmacyId).First();
            //ModelState.Clear();
            //return View("UpdateStudent", new { d = itemData});
            return RedirectToAction("Edit", d);
        }
        [HttpPost]
        public IActionResult edit(pharmacy d)
        {
            myDb.Update(d);
            myDb.SaveChanges();
            return RedirectToAction("Edit");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            //myDb.Remove();
            myDb.SaveChanges();
            return RedirectToAction("Edit");
        }
        */
    }
}
