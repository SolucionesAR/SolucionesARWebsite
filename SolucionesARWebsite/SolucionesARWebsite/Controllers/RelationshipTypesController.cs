using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Lists;
using SolucionesARWebsite.ViewModels.Views.RelationshipTypes;

namespace SolucionesARWebsite.Controllers
{
    public class RelationshipTypesController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /RelationshipTypes/

        public ActionResult Index()
        {
            var relationshipTypes = db.RelationshipTypes.ToList();
            var indexViewModel = new IndexViewModel
            {
                RelationshipTypesList = new RelationshipTypeList()
                {
                    Items = relationshipTypes
                }
            };
            return View(indexViewModel);
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

        //public ActionResult Create()
        //{
        //    var editViewModel = new EditViewModel
        //    {
        //        RelationshipTypesId = 0,
        //        Description = "",
        //    };
        //    return View("Edit", editViewModel);
        //}

        //
        // POST: /RelationshipTypes/Create

        //[HttpPost]
        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
            {
                RelationshipTypesId = 0,
                Description = "",
            };
            return View("Edit", editViewModel);
        }


        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                if (editViewModel.RelationshipTypesId == 0)
                {
                    db.RelationshipTypes.Add(new RelationshipType(){CreatetedAt = DateTime.UtcNow, Description = editViewModel.Description, UpdatedAt = DateTime.UtcNow});
                }
                else
                {
                    var relationship = db.RelationshipTypes.Find(editViewModel.RelationshipTypesId);
                    relationship.Description = editViewModel.Description;
                }
                db.SaveChanges();
            }

            return View("Edit", editViewModel);
        }
        //
        // GET: /RelationshipTypes/Edit/5

        public ActionResult Edit(int id)
        {
            var relationshipTyeps = db.RelationshipTypes.ToList();
            var relationshipTypeInfo = relationshipTyeps.FirstOrDefault(p => p.RelationshipTypeId == id);
            var editViewModel = new EditViewModel
            {
                RelationshipTypesId = relationshipTypeInfo.RelationshipTypeId,
                Description = relationshipTypeInfo.Description,
            };
            return View(editViewModel);
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