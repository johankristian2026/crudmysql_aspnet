using Microsoft.AspNetCore.Mvc;
using CrudApp.Data;
using CrudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Controllers
{
    public class SiswaController : Controller
    {
        private readonly AppDbContext _context;

        public SiswaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Siswas.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Siswa siswa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siswa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siswa);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var siswa = await _context.Siswas.FindAsync(id);
            if (siswa == null) return NotFound();

            return View(siswa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Siswa siswa)
        {
            if (id != siswa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siswa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Siswas.Any(e => e.Id == siswa.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(siswa);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var siswa = await _context.Siswas.FirstOrDefaultAsync(m => m.Id == id);
            if (siswa == null) return NotFound();

            return View(siswa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siswa = await _context.Siswas.FindAsync(id);
            _context.Siswas.Remove(siswa!);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
