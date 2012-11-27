using System.Linq;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Forms.Districts;
using SolucionesARWebsite.ViewModels.Views.Districts;

namespace SolucionesARWebsite.Controllers
{
    public class DistrictsController : BaseController
    {
        private DbModel db = new DbModel();

        //
        // GET: /Districts/

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = db.Districts.ToList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        //
        // GET: /Districts/Details/5

        public ActionResult Details(int id)
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
            var editViewModel = new EditViewModel
            {
                DistrictId = 0,
                DistrictName = "",
                CantonId = 0,
            };
            return View("Edit", editViewModel);
        }


        //
        // POST: /Districts/Create

        /*    [HttpPost]
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
            }*/

        //
        // GET: /Districts/Edit/5

        public ActionResult Edit(int id)
        {
            var districts = db.Districts.ToList();
            var districtsInfo = districts.FirstOrDefault(p => p.DistrictId == id);
            var editViewModel = new EditViewModel
            {
                DistrictId = districtsInfo.DistrictId,
                CantonId = districtsInfo.CantonId,
                DistrictName = districtsInfo.Name,
            };
            return View(editViewModel);
        }

        //
        // POST: /Districts/Edit/5

        /*  [HttpPost]
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
          }*/

        //
        // GET: /Districts/Delete/5

        /*      public ActionResult Delete(int id)
              {
                  District district = db.Districts.Find(id);
                  if (district == null)
                  {
                      return HttpNotFound();
                  }
                  return View(district);
              }
              */

        [HttpPost]
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                if (editFormModel.DistrictId == 0)
                {
                    db.Districts.Add(new District
                    {
                        DistrictId = editFormModel.DistrictId,
                        CantonId = editFormModel.CantonId,
                        Name = editFormModel.DistrictName
                    });
                }
                else
                {
                    var district = db.Districts.Find(editFormModel.DistrictId);
                    district.Name = editFormModel.DistrictName;
                    district.CantonId = editFormModel.CantonId;
                }
                db.SaveChanges();
            }

            return View("Edit", editViewModel);
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

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
            {
                DistrictId = editFormModel.DistrictId,
                CantonId = editFormModel.CantonId,
                DistrictName = editFormModel.DistrictName
            };
        }
    }
}