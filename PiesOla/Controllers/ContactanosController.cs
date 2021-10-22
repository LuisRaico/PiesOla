using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PiesOla.Models;
using PiesOla.Data;
using Microsoft.EntityFrameworkCore;

namespace PiesOla.Controllers
{
    
    public class ContactanosController : Controller
    {
        private readonly ILogger<ContactanosController> _logger;
        private readonly ApplicationDbContext _context;

        public ContactanosController(ILogger<ContactanosController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Contactanos()
        {
            return View();
        }
        public IActionResult Index()
        {
            var listacontactanos = _context.DataContactanos.ToList();
            ViewData["message"]="";
            return View(listacontactanos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(Contactanos objContactanos)
        {
            _context.Add(objContactanos);
            _context.SaveChanges();
            ViewData["Message"] = "El Mensaje se envio con éxito";
            return View();
        }
         public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactanos = await _context.DataContactanos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactanos == null)
            {
                return NotFound();
            }

            return View(contactanos);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactanos = await _context.DataContactanos.FindAsync(id);
            _context.DataContactanos.Remove(contactanos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    
    }
}