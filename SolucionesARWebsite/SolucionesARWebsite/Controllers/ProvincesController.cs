using System.Linq;
using System.Web.Mvc;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Forms.Provinces;
using SolucionesARWebsite.ViewModels.Lists;
using SolucionesARWebsite.ViewModels.Views.Provinces;

namespace SolucionesARWebsite.Controllers
{
    public class ProvincesController : Controller
    {
        private DbModel db = new DbModel();

        //
        // GET: /Provinces/

        public ActionResult Index()
        {
            var provinces = db.Provinces.ToList();
            var indexViewModel = new IndexViewModel
            {
                ProvincesList = new ProvincesList()
                {
                    Items = provinces
                }
            };
            return View(indexViewModel);
        }

        //
        // GET: /Provinces/Details/5

        public ActionResult Details(int id)
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
            var editViewModel = new EditViewModel
            {
                ProvinceId = 0,
                ProvinceName = "",
            };
            return View("Edit", editViewModel);
        }

        //
        // POST: /Provinces/Create

      /*  [HttpPost]
        public ActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                db.Provinces.Add(province);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(province);
        }*/

        //
        // GET: /Provinces/Edit/5

        public ActionResult Edit(int id)
        {
            var provinces = db.Provinces.ToList();
            var provinceInfo = provinces.FirstOrDefault(p => p.ProvinceId == id);
            var editViewModel = new EditViewModel
            {
                ProvinceId = provinceInfo.ProvinceId,
                ProvinceName = provinceInfo.Name,
            };
            return View(editViewModel);
        }
        
        //
        // POST: /Provinces/Edit/5

     /*   [HttpPost]
        public ActionResult Edit(Province province)
        {
            if (ModelState.IsValid)
            {
                db.Entry(province).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(province);
        }*/

        [HttpPost]
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {

                if (editFormModel.ProvinceId==0)
                {
                    db.Provinces.Add(new Province { ProvinceId = editFormModel.ProvinceId, Name = editFormModel.ProvinceName });
                    
                }
                else
                {
                    var province = db.Provinces.Find(editFormModel.ProvinceId);
                    province.Name = editFormModel.ProvinceName;
                }
                db.SaveChanges();
            }

            return View("Edit", editViewModel);
        }

        //
        // GET: /Provinces/Delete/5

     /*   public ActionResult Delete(int id)
        {
            Province province = db.Provinces.Find(id);
            if (province == null)
            {
                return HttpNotFound();
            }
            return View(province);
        }*/

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



        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
            {
                ProvinceId = editFormModel.ProvinceId,
                ProvinceName = editFormModel.ProvinceName
            };
        }
    }
}