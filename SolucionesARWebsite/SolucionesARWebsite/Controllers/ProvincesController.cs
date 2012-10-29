using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Provinces;

namespace SolucionesARWebsite.Controllers
{
    public class ProvincesController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /Provinces/

        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
            {
                ProvincesList = new ProvincesList()
                {
                    Items = new List<Province>()
                }
            };
            return View(indexViewModel);
        }

        //
        // GET: /Provinces/Details/5

        public ActionResult Details(int id = 0)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        //
        // GET: /Provinces/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Provinces/Create

        [HttpPost]
        public ActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                db.Provinces.Add(province);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(province);
        }

        //
        // GET: /Provinces/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        //
        // POST: /Provinces/Edit/5

        [HttpPost]
        public ActionResult Edit(Province province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(province).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(province);
        }

        //
        // GET: /Provinces/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }

        //
        // POST: /Provinces/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Province province = db.Provinces.Find(id);
            db.Provinces.Remove(province);
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