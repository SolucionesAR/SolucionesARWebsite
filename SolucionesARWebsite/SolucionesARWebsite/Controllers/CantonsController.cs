using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Controllers
{
    public class CantonsController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /Cantons/

        public ActionResult Index()
        {
            var cantons = db.Cantons.Include(c => c.Provinceanton);
            return View(cantons.ToList());
        }

        //
        // GET: /Cantons/Details/5

        public ActionResult Details(int id = 0)
        {
            Canton canton = db.Cantons.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            return View(canton);
        }

        //
        // GET: /Cantons/Create

        public ActionResult Create()
        {
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name");
            return View();
        }

        //
        // POST: /Cantons/Create

        [HttpPost]
        public ActionResult Create(Canton canton)
        {
            if (ModelState.IsValid)
            {
                db.Cantons.Add(canton);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name", canton.ProvinceId);
            return View(canton);
        }

        //
        // GET: /Cantons/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Canton canton = db.Cantons.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name", canton.ProvinceId);
            return View(canton);
        }

        //
        // POST: /Cantons/Edit/5

        [HttpPost]
        public ActionResult Edit(Canton canton)
        {
            if (ModelState.IsValid)
            {
                db.Entry(canton).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProvinceId = new SelectList(db.Provinces, "ProvinceId", "Name", canton.ProvinceId);
            return View(canton);
        }

        //
        // GET: /Cantons/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Canton canton = db.Cantons.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            return View(canton);
        }

        //
        // POST: /Cantons/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Canton canton = db.Cantons.Find(id);
            db.Cantons.Remove(canton);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}