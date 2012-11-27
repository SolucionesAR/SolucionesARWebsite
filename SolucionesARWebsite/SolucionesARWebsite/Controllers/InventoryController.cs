﻿using System.Collections.Generic;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Forms.Inventory;
using SolucionesARWebsite.ViewModels.Lists;
using SolucionesARWebsite.ViewModels.Views.Inventory;

namespace SolucionesARWebsite.Controllers
{
    public class InventoryController : BaseController
    {
        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members

        private InventoryManagement _inventoryManagement;

        #endregion

        #region Constructors

        public InventoryController()
        {
            _inventoryManagement = new InventoryManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         InventoryList = new InventoryList(),
                                     };
            return View(indexViewModel);
        }

        //
        // GET: /Users/Details/{id}
        public ActionResult Details(int id)
        {
            var detailsViewModel = new DetailsViewModel();
            return View(detailsViewModel);
        }

        //
        // GET: /Users/New/
        public ActionResult New()
        {
            var uploadViewModel = new UploadViewModel
                                    {
                                        Company = new Company { CompanyName = "Coopeservidores" },
                                        CompaniesList =
                                            new List<Company>
                                                {
                                                    new Company {CompanyName = "Coopeservidores"},
                                                    new Company {CompanyName = "Curacao"},
                                                    new Company {CompanyName = "SolucionesAR"},
                                                }
                                    };
            return View(uploadViewModel);
        }

        //
        // POST: /Users/Save/{editeditFormModel}
        [HttpPost]
        public ActionResult Upload(UploadFormModel uploadFormModel)
        {
            var uploadViewModel = ModelViewFromForm(uploadFormModel);
            if (ModelState.IsValid)
            {
                uploadViewModel.Company = new Company {CompanyName = "Coopeservidores"};
            }

            uploadViewModel.CompaniesList =
                new List<Company>
                    {
                        new Company {CompanyName = "Coopeservidores"},
                        new Company {CompanyName = "Curacao"},
                        new Company {CompanyName = "SolucionesAR"},
                    };
            return View("New", uploadViewModel);
        }

        #endregion

        #region Private Members

        private static UploadViewModel ModelViewFromForm(UploadFormModel uploadFormModel)
        {
            return new UploadViewModel
                       {
                           Company = new Company {CompanyId = uploadFormModel.CompanyId},
                       };
        }

        #endregion
    }
}