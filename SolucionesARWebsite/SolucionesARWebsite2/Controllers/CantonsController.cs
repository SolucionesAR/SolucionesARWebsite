using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Cantons;

namespace SolucionesARWebsite2.Controllers
{
    public class CantonsController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CantonsManagement _cantonsManagement;
        private readonly ProvincesManagement _provincesManagement;

        #endregion

        #region Constructors

        public CantonsController(CantonsManagement cantonsManagement, ProvincesManagement provincesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _cantonsManagement = cantonsManagement;
            _provincesManagement = provincesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _cantonsManagement.GetCantons();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        CantonId = 0,
                                        Name = string.Empty,
                                        ProvinceId = 1,
                                    };
            ViewBag.ProvincesList = _provincesManagement.GetProvinces();

            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var canton = _cantonsManagement.GetCanton(id);
            
            Mapper.CreateMap<Canton, EditViewModel>();
            var editViewModel = Mapper.Map<Canton, EditViewModel>(canton);

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<EditViewModel, Canton>()
                      .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToUpper()));
                var canton = Mapper.Map<EditViewModel, Canton>(editFormModel);

                _cantonsManagement.Save(canton);

                return RedirectToAction("Index");
            }

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();

            return View("Edit", editFormModel);
        }

        [HttpGet]
        public JsonResult GetCantonsByProvice(string provinceId)
        {
            var cantonsList = _cantonsManagement.GetCantons(Convert.ToInt32(provinceId));

            var modelData = cantonsList.Select(c => new SelectListItem
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