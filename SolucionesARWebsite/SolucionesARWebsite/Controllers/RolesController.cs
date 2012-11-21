using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Roles;
using SolucionesARWebsite.ModelsWebsite.Forms.Roles;

namespace SolucionesARWebsite.Controllers
{
    public class RolesController : Controller
    {
        
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members
        
        private readonly RolesManagement _rolesManagement;

        #endregion

        #region Constructors

        public RolesController()
        {
            _rolesManagement = new RolesManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         RolesList = new RolesList
                                                         {
                                                             Items = _rolesManagement.GetRoles(),
                                                         }
                                     };
            return View(indexViewModel);
        }

        //
        // GET: /Users/Create/
        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        RolId = 0,
                                        RolName = string.Empty,
                                    };
            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id)
        {
            var rolInformation = _rolesManagement.GetRol(id);
            var editViewModel = new EditViewModel
                                    {
                                        RolId = rolInformation.RolId,
                                        RolName = rolInformation.Name,
                                    };
            return View(editViewModel);
        }

        //
        // POST: /Users/Save/{editeditFormModel}
        [HttpPost]
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                _rolesManagement.Save(editFormModel);
            }
            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Delete/{id}
        public ActionResult Delete(int id)
        {
            _rolesManagement.Delete(id);

            return RedirectToAction("Index");
        }

        #endregion

        #region Private Members

        private EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
                       {
                           RolId = editFormModel.RolId,
                           RolName = editFormModel.RolName,
                       };
        }

        #endregion
    }
}