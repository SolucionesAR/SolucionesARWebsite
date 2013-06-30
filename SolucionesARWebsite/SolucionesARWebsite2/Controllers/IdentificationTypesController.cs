using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.ViewModels.IdentificationTypes;

namespace SolucionesARWebsite2.Controllers
{
    public class IdentificationTypesController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IdentificationTypesManagement _identificationTypesManagement;

        #endregion

        #region Constructors

        public IdentificationTypesController(IdentificationTypesManagement identificationTypesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _identificationTypesManagement = identificationTypesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _identificationTypesManagement.GetIdentificationTypes();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        IdentificationTypeId = 0,
                                        Description = string.Empty,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var identificationType = _identificationTypesManagement.GetIdentificationType(id);
            var editViewModel = new EditViewModel
                                    {
                                        IdentificationTypeId = identificationType.IdentificationTypeId,
                                        Description = identificationType.IdentificationDescription,
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _identificationTypesManagement.Save(editFormModel);
                return RedirectToAction("Index");
            }

            return View("Edit", editFormModel);
        }

        #endregion

        #region Private Members
        #endregion
    }
}