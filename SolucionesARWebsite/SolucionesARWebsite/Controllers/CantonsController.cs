using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Cantons;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Cantons;

namespace SolucionesARWebsite.Controllers
{
    public class CantonsController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /Cantons/

        public ActionResult Index()
        {
            var cantons = db.Cantons.ToList();
            var indexViewModel = new IndexViewModel
            {
                CantonsList = new CantonsList()
                {
                    Items = cantons
                }
            };
            return View(indexViewModel);
        }

        //
        // GET: /Cantons/Details/5

        public ActionResult Details(int id)
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
            var editViewModel = new EditViewModel
            {
                CantonId = 0,
                CantonName = "",
                ProvinceId = 0,
            };
            return View("Edit", editViewModel);
        }


        //
        // POST: /Cantons/Create

    /*    [HttpPost]
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
        }*/

        //
        // GET: /Cantons/Edit/5

        public ActionResult Edit(int id)
        {
            var cantons = db.Cantons.ToList();
            var cantonsInfo = cantons.FirstOrDefault(p => p.CantonId == id);
            var editViewModel = new EditViewModel
            {
                CantonId = cantonsInfo.CantonId,
                ProvinceId = cantonsInfo.ProvinceId,
                CantonName = cantonsInfo.Name,
            };
            return View(editViewModel);
        }

        //
        // POST: /Cantons/Edit/5

      /*  [HttpPost]
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
        }*/

        //
        // GET: /Cantons/Delete/5

  /*      public ActionResult Delete(int id)
        {
            Canton canton = db.Cantons.Find(id);
            if (canton == null)
            {
                return HttpNotFound();
            }
            return View(canton);
        }
        */

        [HttpPost]
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                if (editFormModel.CantonId == 0)
                {
                    var canton = new Canton
                                     {
                                         CantonId = editFormModel.CantonId,
                                         ProvinceId = editFormModel.ProvinceId,
                                         Name = editFormModel.CantonName
                                     };
                    db.Cantons.Add(canton);
                }
                else
                {
                    var canton = db.Cantons.Find(editFormModel.CantonId);
                    canton.Name = editFormModel.CantonName;
                    canton.ProvinceId = editFormModel.ProvinceId;
                }
                db.SaveChanges();
            }

            return View("Edit", editViewModel);
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

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
            {
                CantonId = editFormModel.CantonId,
                ProvinceId = editFormModel.ProvinceId,
                CantonName = editFormModel.CantonName
            };
        }
    }
}