using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.ViewModels.Provinces;

namespace SolucionesARWebsite2.Controllers
{
    public class ProvincesController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ProvincesManagement _cantonsManagement;

        #endregion

        #region Constructors

        public ProvincesController(ProvincesManagement cantonsManagement, UsersManagement usersManagement)
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
            var results = _cantonsManagement.GetProvinces();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        ProvinceId = 0,
                                        ProvinceName = string.Empty,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var cantonInformation = _cantonsManagement.GetProvince(id);
            var editViewModel = new EditViewModel
                                    {
                                        ProvinceId = cantonInformation.ProvinceId,
                                        ProvinceName = cantonInformation.Name,
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
            //return RedirectToAction("Index");
        }

        #endregion

        #region Private Members
        #endregion
    }
}