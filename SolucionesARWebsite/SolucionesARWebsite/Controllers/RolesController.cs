using System.Data;
using System.Linq;
using System.Web.Mvc;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Controllers
{
    public class RolesController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /Roles/

        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }

        //
        // GET: /Roles/Details/5

        public ActionResult Details(int id)
        {
            Rol rol = db.Roles.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // GET: /Roles/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Roles/Create

        [HttpPost]
        public ActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rol);
        }

        //
        // GET: /Roles/Edit/5

        public ActionResult Edit(int id)
        {
            Rol rol = db.Roles.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // POST: /Roles/Edit/5

        [HttpPost]
        public ActionResult Edit(Rol rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rol);
        }

        //
        // GET: /Roles/Delete/5

        public ActionResult Delete(int id)
        {
            Rol rol = db.Roles.Find(id);
            if (rol == null)
            {
                return HttpNotFound();
            }
            return View(rol);
        }

        //
        // POST: /Roles/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Rol rol = db.Roles.Find(id);
            db.Roles.Remove(rol);
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