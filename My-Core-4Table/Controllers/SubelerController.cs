using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using My_Core_4Table.Models;
using My_Core_4Table.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace My_Core_4Table.Controllers
{
    public class SubelerController : Controller
    {
        private readonly MagazaDBContext _context;

        public SubelerController(MagazaDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Subeler> applicants;
            applicants = _context.Subelers.ToList();
            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Subeler subeler = new Subeler();
            return View(subeler);
        }
        [HttpPost]
        public IActionResult Create(Subeler subeler)
        {
            _context.Add(subeler);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var applicant = await _context.Subelers.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ADI,KONUM,YILLIKCIRO,TOPLAMCALISAN")] Subeler subeler)
        {

            _context.Update(subeler);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Subelers.FirstOrDefaultAsync(m => m.ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Subelers.FirstOrDefaultAsync(m => m.ID == id);
            _context.Subelers.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
