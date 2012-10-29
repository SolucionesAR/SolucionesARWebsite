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
    public class DistrictsController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /Districts/

        public ActionResult Index()
        {
            var districts = db.Districts.Include(d => d.Canton);
            return View(districts.ToList());
        }

        //
        // GET: /Districts/Details/5

        public ActionResult Details(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // GET: /Districts/Create

        public ActionResult Create()
        {
            ViewBag.CantonId = new SelectList(db.Cantons, "CantonId", "Name");
            return View();
        }

        //
        // POST: /Districts/Create

        [HttpPost]
        public ActionResult Create(District district)
        {
            if (ModelState.IsValid)
            {
                db.Districts.Add(district);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CantonId = new SelectList(db.Cantons, "CantonId", "Name", district.CantonId);
            return View(district);
        }

        //
        // GET: /Districts/Edit/5

        public ActionResult Edit(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            ViewBag.CantonId = new SelectList(db.Cantons, "CantonId", "Name", district.CantonId);
            return View(district);
        }

        //
        // POST: /Districts/Edit/5

        [HttpPost]
        public ActionResult Edit(District district)
        {
            if (ModelState.IsValid)
            {
                db.Entry(district).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CantonId = new SelectList(db.Cantons, "CantonId", "Name", district.CantonId);
            return View(district);
        }

        //
        // GET: /Districts/Delete/5

        public ActionResult Delete(int id = 0)
        {
            District district = db.Districts.Find(id);
            if (district == null)
            {
                return HttpNotFound();
            }
            return View(district);
        }

        //
        // POST: /Districts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            District district = db.Districts.Find(id);
            db.Districts.Remove(district);
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