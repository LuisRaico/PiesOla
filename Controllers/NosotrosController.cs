using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PiesOla.Models;

namespace PiesOla.Controllers
{
    public class NosotrosController:Controller
    {
        private readonly ILogger<NosotrosController> _logger;

        public NosotrosController(ILogger<NosotrosController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}