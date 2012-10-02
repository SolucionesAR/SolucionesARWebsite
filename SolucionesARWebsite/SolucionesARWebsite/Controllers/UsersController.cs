using System.Collections.Generic;
using System.Web.Mvc;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Users;
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
        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         //Users = db.Users.Include(u => u.UserRol) 
                                         Users =
                                             new List<User>
                                                 {
                                                     new User
                                                         {
                                                             CedNumber = 206620452,
                                                             FName = "César",
                                                             LName1 = "Barboza",
                                                             LName2 = "González",
                                                         },
                                                     new User
                                                         {
                                                             CedNumber = 606620452,
                                                             FName = "Ricardo",
                                                             LName1 = "Quesada",
                                                             LName2 = "Hidalgo",
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
                RolList =
                    new List<Rol>
                                                {
                                                    new Rol {Name = "Vendedor"},
                                                    new Rol {Name = "Dependiente"},
                                                    new Rol {Name = "Gerente"},
                                                    new Rol {Name = "Administrador"},
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
                CedNumber = 206620452,
                FName = "César",
                LName1 = "Barboza",
                LName2 = "González",
                Cashback = 100,
                Enabled = true,
                GeneratedCode = "GeneratedCode",
                RolList =
                    new List<Rol>
                                                {
                                                    new Rol {Name = "Vendedor"},
                                                    new Rol {Name = "Dependiente"},
                                                    new Rol {Name = "Gerente"},
                                                    new Rol {Name = "Administrador"},
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
            }

            /*
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolId = new SelectList(db.Rols, "RolId", "Name", user.RolId);
            */
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
            {
                UserId = editFormModel.UserId,
                CedNumber = editFormModel.CedNumber,
                FName = editFormModel.FName,
                LName1 = editFormModel.LName1,
                LName2 = editFormModel.LName2,
                GeneratedCode = editFormModel.GeneratedCode,
                Dob = editFormModel.Dob,
                Address1 = editFormModel.Address1,
                Address2 = editFormModel.Address2,
                PhoneNumber = editFormModel.PhoneNumber,
                Cellphone = editFormModel.Cellphone,
                Email = editFormModel.Email,
                Cashback = editFormModel.Cashback,
                Enabled = editFormModel.Enabled,
                RolList =
                                 new List<Rol>
                                                {
                                                    new Rol {Name = "Vendedor"},
                                                    new Rol {Name = "Dependiente"},
                                                    new Rol {Name = "Gerente"},
                                                    new Rol {Name = "Administrador"},
                                                },
                Rol = new Rol { RolId = editFormModel.RolId, Name = "Administrador" },
            };
        }

        #endregion
    }
}