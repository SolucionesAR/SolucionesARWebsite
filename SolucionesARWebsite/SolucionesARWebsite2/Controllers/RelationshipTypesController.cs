using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.ViewModels.RelationshipTypes;

namespace SolucionesARWebsite2.Controllers
{
    public class RelationshipTypesController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly RelationshipTypesManagement _relationshipTypesManagement;

        #endregion

        #region Constructors

        public RelationshipTypesController(RelationshipTypesManagement relationshipTypesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _relationshipTypesManagement = relationshipTypesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _relationshipTypesManagement.GetRelationshipTypesList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        RelationshipTypesId = 0,
                                        Description = string.Empty,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var relationshipTypeInformation = _relationshipTypesManagement.GetRelationshipType(id);
            var editViewModel = new EditViewModel
                                    {
                                        RelationshipTypesId = relationshipTypeInformation.RelationshipTypeId,
                                        Description = relationshipTypeInformation.Description,
                                    };
            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                _relationshipTypesManagement.Save(editFormModel);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Private Members
        #endregion
    }
}