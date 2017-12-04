using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RecetAgro_WS.Models;

namespace RecetAgro_WS.Controllers
{
    public class ProductorController : Controller
    {

        private ApplicationDbContext _context;

        public ProductorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Productor
        [Route("Productor/Index")]
        public ActionResult Index()
        {
            var productores = _context.Productores.ToList();                   

            return View(productores);
        }

        [Route("Productor/New")]
        public ActionResult New()
        {
            //We initilize the object for validation purposes(Id field = 0)
            var productores = new Productor();
            return View("ProductorForm", productores);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Productor productor)
        {
            if (!ModelState.IsValid)
            {
                var prod = new Productor
                {
                    Nombre = productor.Nombre,
                    ApellidoPaterno = productor.ApellidoPaterno,
                    ApellidoMaterno = productor.ApellidoMaterno,
                    Telefono = productor.Telefono,
                    Email = productor.Email
                };

                return View("ProductorForm", prod);
            }


            if (productor.Id == 0)
                _context.Productores.Add(productor);
            else
            {
                var prodInDb = _context.Productores.Single(p => p.Id == productor.Id);
                prodInDb.Nombre = productor.Nombre;
                prodInDb.ApellidoPaterno = productor.ApellidoPaterno;
                prodInDb.ApellidoMaterno = productor.ApellidoMaterno;
                prodInDb.Telefono = productor.Telefono;
                prodInDb.Email = productor.Email;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Productor");
        }
       

        public ActionResult Edit(int id)
        {
            var productor = _context.Productores.SingleOrDefault(p => p.Id == id);

            if (productor == null)
                return HttpNotFound();

            var prod = new Productor
            {
                Id = productor.Id,
                Nombre = productor.Nombre,
                ApellidoPaterno = productor.ApellidoPaterno,
                ApellidoMaterno = productor.ApellidoMaterno,
                Telefono = productor.Telefono,
                Email = productor.Email
            };

            return View("ProductorForm", prod);
        }

    }
}