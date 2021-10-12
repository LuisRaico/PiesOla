using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PiesOla.Models;
using PiesOla.Data;
using Microsoft.AspNetCore.Identity;
namespace PiesOla.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<HomeController> _logger;
private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CatalogoController(ILogger<HomeController> logger,
            ApplicationDbContext context , UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var listContactos=_context.Productos.OrderBy(y => y.Codigo).OrderBy(x => x.Descripcion).ToList();
            return View(listContactos);
        }

        

        // GET: Contacto/Edit/5
        public async Task<IActionResult> Info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context. Productos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }
            return View(contacto);
        }

         public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  View("Index",productos);
            }else{
                var producto = await _context.Productos.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Precio = producto.Precio;
                proforma.Stock = 1;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Index));
            }
        }

    }
}