using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.ViewModels.Roles;

namespace SolucionesARWebsite2.Controllers
{
    public class RolesController : BaseController
    {
        #region Private Members

        private readonly RolesManagement _rolesManagement;

        #endregion

        #region Constructors

        public RolesController(RolesManagement rolesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _rolesManagement = rolesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int) indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _rolesManagement.GetRoles();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        RolId = 0,
                                        RolName = string.Empty,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var rolInformation = _rolesManagement.GetRol(id);
            var editViewModel = new EditViewModel
                                    {
                                        RolId = id,
                                        RolName = rolInformation.Name,
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _rolesManagement.Save(editViewModel);
            }
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members
        #endregion
    }
}