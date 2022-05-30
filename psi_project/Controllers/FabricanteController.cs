using psi_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace psi_project.Controllers
{
    public class FabricanteController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Fabricante
        public ActionResult Index()
        {
            return View(context.Fabricantes.OrderBy(c=>c.Nome));
        }
    }
}