using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.ViewModels.Districts;

namespace SolucionesARWebsite2.Controllers
{
    public class DistrictsController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CantonsManagement _cantonsManagement;
        private readonly DistrictsManagement _districtsManagement;
        private readonly ProvincesManagement _provincesManagement;

        #endregion

        #region Constructors

        public DistrictsController(CantonsManagement cantonsManagement, DistrictsManagement districtsManagement, ProvincesManagement provincesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _cantonsManagement = cantonsManagement;
            _districtsManagement = districtsManagement;
            _provincesManagement = provincesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _districtsManagement.GetDistricts();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);
            
            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        DistrictId = 0,
                                        DistrictName = string.Empty,
                                        CantonId = 0,
                                        ProvinceId = 1,
                                    };
            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons((int)Constants.DefaultProvince);
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var districtInformation = _districtsManagement.GetDistrict(id);
            var editViewModel = new EditViewModel
                                    {
                                        CantonId = districtInformation.CantonId,
                                        DistrictId = districtInformation.DistrictId,
                                        DistrictName = districtInformation.Name,
                                        ProvinceId = districtInformation.Canton.ProvinceId
                                    };
            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons(editViewModel.ProvinceId);
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _districtsManagement.Save(editFormModel);
                return RedirectToAction("Index");
            }

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons(editFormModel.ProvinceId);
            return View("Edit", editFormModel);
        }

        [HttpGet]
        public JsonResult GetDistrictsByCanton(string cantonId)
        {
            var districtsList = _districtsManagement.GetDistricts(Convert.ToInt32(cantonId));

            var modelData = districtsList.Select(c => new SelectListItem
                                                      {
                                                          Text = c.Name,
                                                          Value = Convert.ToString(c.CantonId),
                                                      });

            return Json(modelData, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Private Members
        #endregion
    }
}