using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiesOla.Data;
using PiesOla.Models;
using Microsoft.AspNetCore.Identity;

namespace PiesOla.Controllers
{
    public class ProformaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
               // GET: Proforma
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataProforma select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            
            return View(await items.ToListAsync());
        }

        // GET: Proforma/Delete/5
       
      
         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (proforma == null)
            {
                return NotFound();
            }

            return View(proforma);
        }

        // POST: Proforma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proforma = await _context.DataProforma.FindAsync(id);
            _context.DataProforma.Remove(proforma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // GET: Proforma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proforma = await _context.DataProforma.FindAsync(id);
            if (proforma == null)
            {
                return NotFound();
            }
            return View(proforma);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Stock,Precio,UserID")] Proforma proforma)
        {
            if (id != proforma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proforma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProformaExists(proforma.Id))
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
            return View(proforma);
        }
        private bool ProformaExists(int id)
        {
            return _context.DataProforma.Any(e => e.Id == id);
        }

    }
}