using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using My_Core_4Table.Models;
using My_Core_4Table.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace My_Core_4Table.Controllers
{
    public class PersonellerController : Controller
    {
        private readonly MagazaDBContext _context;

        public PersonellerController(MagazaDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Personeller> applicants;
            applicants = _context.Personellers.ToList();
            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Personeller personeller = new Personeller();
            //basvuruSahibi.Deneyim.Add(new Deneyim() { DeneyimId = 1 });
            return View(personeller);
        }
        [HttpPost]
        public IActionResult Create(Personeller personeller)
        {
            _context.Add(personeller);
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
            var applicant = await _context.Personellers.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ADSOYAD,YAS,CINSIYET,TOPLAMCALISMA")] Personeller personeller)
        {

            _context.Update(personeller);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Personellers.FirstOrDefaultAsync(m => m.ID == id);
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
            var user = await _context.Personellers.FirstOrDefaultAsync(m => m.ID == id);
            _context.Personellers.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
