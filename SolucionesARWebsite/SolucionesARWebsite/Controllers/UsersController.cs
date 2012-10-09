using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Users;
using SolucionesARWebsite.ModelsWebsite.Views.Users;

namespace SolucionesARWebsite.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController()
        {
            _usersManagement = new UsersManagement();
        }
        #region Constants
        #endregion

        #region Properties

        private UsersManagement _usersManagement;
        #endregion

        #region Private Members
        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            
            var indexViewModel = new IndexViewModel
                                     {
                                         //UsersList = db.Users.Include(u => u.UserRol) 
                                         UsersList =
                                             new UsersList
                                                 {
                                                     Items = new List<User>
                                                                 {
                                                                     new User
                                                                         {
                                                                             CedNumber = 206620452,
                                                                             FName = "César",
                                                                             LName1 = "Barboza",
                                                                             LName2 = "González",
                                                                             UserRol = new Rol {Name = "Administrador"}
                                                                         },
                                                                     new User
                                                                         {
                                                                             CedNumber = 606620452,
                                                                             FName = "Ricardo",
                                                                             LName1 = "Quesada",
                                                                             LName2 = "Hidalgo",
                                                                             UserRol = new Rol {Name = "Administrador"}
                                                                         }
                                                                 }
                                                 }
                                     };

            //var usersList = _usersManagement.GetUsers();
            //indexViewModel.UsersList.Items = usersList;
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
                Cashback = 100,
                Enabled = true,
                GeneratedCode = "GeneratedCode",
                LastTransactions =
                    new List<string> { "new transaction", "current transaction", "old transaction" }

            };
            /*
            //Get information (personal information, cashback, last transactions....)
            User user = _entityModel.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
             */
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
            //ViewBag.RolId = new SelectList(db.Rols, "RolId", "Name");

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
                GeneratedCode = "BarboGonza0452",
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
            /*
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "Name", user.RolId);
            */
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
                //Save changes in the data base with the editViewModel information
                /*
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                
                */
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

            /*
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "Name", user.RolId);
            */
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