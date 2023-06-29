using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiNVT.Models;
// using BaiThiNVT.Models.Process;

namespace BaiThiNVT.Controllers
{
    public class NVTCau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        ToUper abc = new ToUper();

        public NVTCau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NVTCau3
        public async Task<IActionResult> Index()
        {
              return _context.NVTCau3 != null ? 
                          View(await _context.NVTCau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NVTCau3'  is null.");
        }

        // GET: NVTCau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NVTCau3 == null)
            {
                return NotFound();
            }

            var nVTCau3 = await _context.NVTCau3
                .FirstOrDefaultAsync(m => m.IDNhanVien == id);
            if (nVTCau3 == null)
            {
                return NotFound();
            }

            return View(nVTCau3);
        }

        // GET: NVTCau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NVTCau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDNhanVien,TenNhanVien,TuoiNhanVien")] NVTCau3 nVTCau3)
        {
            if (ModelState.IsValid)
            {

                nVTCau3.TenNhanVien = abc.AutoUpper(nVTCau3.TenNhanVien);
                _context.Add(nVTCau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nVTCau3);
        }

        // GET: NVTCau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NVTCau3 == null)
            {
                return NotFound();
            }

            var nVTCau3 = await _context.NVTCau3.FindAsync(id);
            if (nVTCau3 == null)
            {
                return NotFound();
            }
            return View(nVTCau3);
        }

        // POST: NVTCau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IDNhanVien,TenNhanVien,TuoiNhanVien")] NVTCau3 nVTCau3)
        {
            if (id != nVTCau3.IDNhanVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVTCau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVTCau3Exists(nVTCau3.IDNhanVien))
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
            return View(nVTCau3);
        }

        // GET: NVTCau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NVTCau3 == null)
            {
                return NotFound();
            }

            var nVTCau3 = await _context.NVTCau3
                .FirstOrDefaultAsync(m => m.IDNhanVien == id);
            if (nVTCau3 == null)
            {
                return NotFound();
            }

            return View(nVTCau3);
        }

        // POST: NVTCau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NVTCau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NVTCau3'  is null.");
            }
            var nVTCau3 = await _context.NVTCau3.FindAsync(id);
            if (nVTCau3 != null)
            {
                _context.NVTCau3.Remove(nVTCau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVTCau3Exists(string id)
        {
          return (_context.NVTCau3?.Any(e => e.IDNhanVien == id)).GetValueOrDefault();
        }
    }
}
