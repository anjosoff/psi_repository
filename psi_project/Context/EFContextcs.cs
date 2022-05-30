using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using psi_project.Models;

namespace psi_project.Models
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}
