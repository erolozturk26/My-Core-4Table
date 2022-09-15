using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Core_4Table.Data;
using My_Core_4Table.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Core_4Table.Controllers
{
    public class ToptancilarController : Controller
    {
        private readonly MagazaDBContext _context;

        public ToptancilarController(MagazaDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Toptancilar> applicants;
            applicants = _context.Toptancilars.ToList();
            return View(applicants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Toptancilar toptancilar = new Toptancilar();
            //basvuruSahibi.Deneyim.Add(new Deneyim() { DeneyimId = 1 });
            return View(toptancilar);
        }
        [HttpPost]
        public IActionResult Create(Toptancilar toptancilar)
        {
            _context.Add(toptancilar);
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
            var applicant = await _context.Toptancilars.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ADISOYADI,KONUMU,TELEFONNO,TOPLAMCALISMA")] Toptancilar toptancilar)
        {

            _context.Update(toptancilar);
            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var user = await _context.Toptancilars.FirstOrDefaultAsync(m => m.ID == id);
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
            var user = await _context.Toptancilars.FirstOrDefaultAsync(m => m.ID == id);
            _context.Toptancilars.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
