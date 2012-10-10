using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Users;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Users;

namespace SolucionesARWebsite.Controllers
{
    public class UsersController : BaseController
    {
        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members
        
        private UsersManagement _usersManagement;

        #endregion

        #region Constructors

        public UsersController()
        {
            _usersManagement = new UsersManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         UsersList =
                                             new UsersList
                                                 {
                                                     Items = new List<User>
                                                                 {
                                                                     new User
                                                                         {
                                                                             GeneratedCode = "BarbozaCesar452",
                                                                             CedNumber = 206620452,
                                                                             FName = "César",
                                                                             LName1 = "Barboza",
                                                                             LName2 = "González",
                                                                             UserRol = new Rol {Name = "Administrador"}
                                                                         },
                                                                     new User
                                                                         {
                                                                             GeneratedCode = "BarbozaCesar452",
                                                                             CedNumber = 606620452,
                                                                             FName = "Ricardo",
                                                                             LName1 = "Quesada",
                                                                             LName2 = "Hidalgo",
                                                                             UserRol = new Rol {Name = "Administrador"}
                                                                         }
                                                                 }
                                                 }
                                     };
            return View(indexViewModel);
        }

        //
        // GET: /Users/Details/{id}
        public ActionResult Details(int id = 0)
        {
            var detailsViewModel = new DetailsViewModel
                                       {
                                           UserId = 1,
                                           CedNumber = 206620452,
                                           FName = "César",
                                           LName1 = "Barboza",
                                           LName2 = "González",
                                           Cashback = "5,2005.00 colones",
                                           Enabled = true,
                                           GeneratedCode = "BarbozaCesar452",
                                           LastTransactions =
                                               new List<string>
                                                   {"new transaction", "current transaction", "old transaction"}

                                       };
            return View(detailsViewModel);
        }

        //
        // GET: /Users/Create/
        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        UserId = 0,
                                        Rol = new Rol(),
                                        RolesList =
                                            new List<Rol>
                                                {
                                                    new Rol {Name = "Vendedor"},
                                                    new Rol {Name = "Dependiente"},
                                                    new Rol {Name = "Gerente"},
                                                    new Rol {Name = "Administrador"},
                                                },
                                        Company = new Company(),
                                        CompaniesList =
                                            new List<Company>
                                                {
                                                    new Company {CompanyName = "Coopeservidores"},
                                                    new Company {CompanyName = "Curacao"},
                                                    new Company {CompanyName = "SolucionesAR"},
                                                }
                                    };

            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id = 0)
        {
            var editViewModel = new EditViewModel
                                    {
                                        UserId = 504,
                                        CedNumber = "206620452",
                                        FirstName = "César",
                                        LastName1 = "Barboza",
                                        LastName2 = "González",
                                        Cashback = "₡5,025.00",
                                        Enabled = true,
                                        GeneratedCode = "BarbozaCesar452",
                                        Rol = new Rol(),
                                        RolesList =
                                            new List<Rol>
                                                {
                                                    new Rol {Name = "Vendedor"},
                                                    new Rol {Name = "Dependiente"},
                                                    new Rol {Name = "Gerente"},
                                                    new Rol {Name = "Administrador"},
                                                },
                                        Company = new Company(),
                                        CompaniesList =
                                            new List<Company>
                                                {
                                                    new Company {CompanyName = "Coopeservidores"},
                                                    new Company {CompanyName = "Curacao"},
                                                    new Company {CompanyName = "SolucionesAR"},
                                                }
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
                editViewModel.UserId = 504;
            }

            editViewModel.RolesList =
                new List<Rol>
                    {
                        new Rol {Name = "Vendedor"},
                        new Rol {Name = "Dependiente"},
                        new Rol {Name = "Gerente"},
                        new Rol {Name = "Administrador"},
                    };
            editViewModel.CompaniesList =
                new List<Company>
                    {
                        new Company {CompanyName = "Coopeservidores"},
                        new Company {CompanyName = "Curacao"},
                        new Company {CompanyName = "SolucionesAR"},
                    };
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            var lastName1Encoded = editFormModel.LastName1.Length >= 4
                                       ? editFormModel.LastName1.Substring(0, 4)
                                       : editFormModel.LastName1;
            var lastName2Encoded = editFormModel.LastName2.Length >= 4
                                       ? editFormModel.LastName2.Substring(0, 4)
                                       : editFormModel.LastName2;
            return new EditViewModel
                       {
                           UserId = editFormModel.UserId,
                           CedNumber = editFormModel.CedNumber,
                           FirstName = editFormModel.FirstName,
                           LastName1 = editFormModel.LastName1,
                           LastName2 = editFormModel.LastName2,
                           GeneratedCode =
                               string.Format("{0}{1}{2}", lastName1Encoded, lastName2Encoded,
                                             editFormModel.CedNumber
                                                 .ToString(CultureInfo.InvariantCulture).Substring(0, 4)),
                           Dob = editFormModel.Dob,
                           Address1 = editFormModel.Address1,
                           Address2 = editFormModel.Address2,
                           PhoneNumber = editFormModel.PhoneNumber,
                           Cellphone = editFormModel.Cellphone,
                           Email = editFormModel.Email,
                           Enabled = editFormModel.Enabled,
                           Rol = new Rol {RolId = editFormModel.RolId},
                           Company = new Company {CompanyId = editFormModel.CompanyId},
                       };
        }

        #endregion
    }
}