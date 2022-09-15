using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Core_4Table.Data;
using My_Core_4Table.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Core_4Table.Controllers
{
    public class UrunlerController : Controller
    {
        private readonly MagazaDBContext _context;

        public UrunlerController(MagazaDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Urunler> applicants;
            applicants = _context.Urunlers.ToList();
            return View(applicants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Urunler urunler = new Urunler();
            //basvuruSahibi.Deneyim.Add(new Deneyim() { DeneyimId = 1 });
            return View(urunler);
        }
        [HttpPost]
        public IActionResult Create(Urunler urunler)
        {
            _context.Add(urunler);
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
            var applicant = await _context.Urunlers.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ADI,FIYAT,MARKA,EKOZELLIKLER")] Urunler urunler)
        {

            _context.Update(urunler);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Urunlers.FirstOrDefaultAsync(m => m.ID == id);
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
            var user = await _context.Urunlers.FirstOrDefaultAsync(m => m.ID == id);
            _context.Urunlers.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
