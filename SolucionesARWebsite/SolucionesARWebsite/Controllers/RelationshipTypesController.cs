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
    public class RelationshipTypesController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /RelationshipTypes/

        public ActionResult Index()
        {
            return View(db.RelationshipTypes.ToList());
        }

        //
        // GET: /RelationshipTypes/Details/5

        public ActionResult Details(int id)
        {
            RelationshipType relationshiptype = db.RelationshipTypes.Find(id);
            if (relationshiptype == null)
            {
                return HttpNotFound();
            }
            return View(relationshiptype);
        }

        //
        // GET: /RelationshipTypes/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /RelationshipTypes/Create

        [HttpPost]
        public ActionResult Create(RelationshipType relationshiptype)
        {
            if (ModelState.IsValid)
            {
                db.RelationshipTypes.Add(relationshiptype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relationshiptype);
        }

        //
        // GET: /RelationshipTypes/Edit/5

        public ActionResult Edit(int id)
        {
            RelationshipType relationshiptype = db.RelationshipTypes.Find(id);
            if (relationshiptype == null)
            {
                return HttpNotFound();
            }
            return View(relationshiptype);
        }

        //
        // POST: /RelationshipTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(RelationshipType relationshiptype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationshiptype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relationshiptype);
        }

        //
        // GET: /RelationshipTypes/Delete/5

        public ActionResult Delete(int id)
        {
            RelationshipType relationshiptype = db.RelationshipTypes.Find(id);
            if (relationshiptype == null)
            {
                return HttpNotFound();
            }
            return View(relationshiptype);
        }

        //
        // POST: /RelationshipTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            RelationshipType relationshiptype = db.RelationshipTypes.Find(id);
            db.RelationshipTypes.Remove(relationshiptype);
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