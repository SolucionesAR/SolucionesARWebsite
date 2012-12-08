using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.ViewModels.Districts;

namespace SolucionesARWebsite.Controllers
{
    public class DistrictsController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DistrictsManagement _districtsManagement;

        #endregion

        #region Constructors

        public DistrictsController(DistrictsManagement districtsManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _districtsManagement = districtsManagement;
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
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var districtInformation = _districtsManagement.GetDistrict(id);
            var editViewModel = new EditViewModel
                                    {
                                        DistrictId = districtInformation.DistrictId,
                                        CantonId = districtInformation.CantonId,
                                        DistrictName = districtInformation.Name,
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _districtsManagement.Save(editFormModel);
            }
            return View("Edit", editFormModel);
        }

        #endregion

        #region Private Members
        #endregion
    }
}