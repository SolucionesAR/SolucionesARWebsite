using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Cantons;

namespace SolucionesARWebsite.Controllers
{
    public class CantonsController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CantonsManagement _cantonsManagement;

        #endregion

        #region Constructors

        public CantonsController(CantonsManagement cantonsManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _cantonsManagement = cantonsManagement;
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
                                        CantonName = string.Empty,
                                        ProvinceId = 0,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var cantonInformation = _cantonsManagement.GetCanton(id);
            var editViewModel = new EditViewModel
                                    {
                                        CantonId = cantonInformation.CantonId,
                                        CantonName = cantonInformation.Name,
                                        ProvinceId = cantonInformation.ProvinceId,
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _cantonsManagement.Save(editFormModel);
            }
            return View("Edit", editFormModel);
        }

        #endregion

        #region Private Members
        #endregion
    }
}