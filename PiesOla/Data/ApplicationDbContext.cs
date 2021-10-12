using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PiesOla.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PiesOla.Models.Contactanos> DataContactanos { get; set; }
         public DbSet<PiesOla.Models.Producto> Productos { get; set; }
             public DbSet<PiesOla.Models.Proforma> DataProforma { get; set; }
    }
}
