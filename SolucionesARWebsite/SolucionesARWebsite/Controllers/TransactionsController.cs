using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Forms.Transactions;
using SolucionesARWebsite.ViewModels.Lists;
using SolucionesARWebsite.ViewModels.Views.Transactions;

namespace SolucionesARWebsite.Controllers
{
    public class TransactionsController : Controller
    {
        #region Private Members

        private readonly TransactionsManagement _transactionsManagement;
        private readonly UsersManagement _usersManagement;
        private readonly StoresManagement _storesManagement;

        #endregion

        #region Constructors

        public TransactionsController(UsersManagement usersManagement, TransactionsManagement transactionsManagement)
        {
            _transactionsManagement = transactionsManagement;
            _usersManagement = usersManagement;
            _storesManagement = new StoresManagement();
        }

        #endregion

        #region Public Actions

        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         TransactionsList = new TransactionsList
                                                                {
                                                                    Items = _transactionsManagement.GetTransactions(),
                                                                }
                                     };
            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var usersList = _usersManagement.GetUsersList();
            var storsList = _storesManagement.GetStores();
            var editViewModel = new EditViewModel
                                    {
                                        TransactionId = 0,
                                        Amount = 0.0,
                                        Points = 50,
                                        BillBarCode = "",
                                        Store = new Store(),
                                        StoresList = storsList,
                                        Customer = new User(),
                                        CustomersList = usersList,
                                        //SalesMan = new User(),
                                        //ListSalesMan = usersList,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult FileUpload()
        {
            var usersList = _usersManagement.GetUsersList();
            var storsList = _storesManagement.GetStores();
            var editViewModel = new EditViewModel
                                    {
                                        TransactionId = 0,
                                        Amount = 50.0,
                                        BillBarCode = "",
                                        Store = new Store(),
                                        StoresList = storsList,
                                        Customer = new User(),
                                        CustomersList = usersList,
                                        //SalesMan = new User(),
                                        //ListSalesMan = usersList,
                                    };
            return View("FileUpload", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var transaction = _transactionsManagement.GetTransaction(id);
            var editViewModel = new EditViewModel
                                    {
                                        TransactionId = id,
                                        Amount = transaction.Amount,
                                        BillBarCode = transaction.BillBarCode,
                                        Store = transaction.Store,
                                        StoresList = _storesManagement.GetStores(),
                                        Customer = transaction.Customer,
                                        CustomersList = _usersManagement.GetUsersList(),
                                        Points = transaction.Points,
                                    };
            return View("Edit", editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                Transaction transaction;
                if (editFormModel.TransactionId == 0)
                {
                    transaction = new Transaction
                                      {
                                          TransactionId = 0,
                                          Amount = editFormModel.Amount,
                                          BillBarCode = editFormModel.BillBarCode,
                                          CreatetedAt = DateTime.UtcNow,
                                          UpdatedAt = DateTime.UtcNow,
                                          CustomerId = editFormModel.Customer.UserId,
                                          Points = editFormModel.Points,
                                          StoreId = editFormModel.Store.StoreId,
                                      };
                    _transactionsManagement.SaveTransaction(transaction);
                }
                else
                {
                    transaction = _transactionsManagement.GetTransaction(editFormModel.TransactionId);
                    transaction.BillBarCode = editFormModel.BillBarCode;
                    transaction.Amount = editFormModel.Amount;
                    transaction.CustomerId = editFormModel.Customer.UserId;
                    transaction.Points = editFormModel.Points;
                    transaction.StoreId = editFormModel.Store.StoreId;
                    transaction.UpdatedAt = DateTime.UtcNow;
                    _transactionsManagement.UpdateTransaction();
                }
            }
            editViewModel.CustomersList = _usersManagement.GetUsersList();
            editViewModel.StoresList = _storesManagement.GetStores();
            return View("Edit", editViewModel);
        }


        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, string sheetName)
        {
            if (file != null)
            {
                string filename = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));

                if (Directory.Exists(Path.GetDirectoryName(filename)))
                {
                    file.SaveAs(filename);
                }
                else
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                }

                var result = _transactionsManagement.SaveTransactions(filename, sheetName);
                //TODO: aqui necesitamos devolver la misma vista pero con un error si falla...
                return RedirectToAction(result ? "Index" : "FileUpload");
            }
            //TODO: aqui necesitamos devolver la misma vista pero con un error...

            return RedirectToAction("FileUpload");
        }

        #endregion

        #region Private Methods

        private static EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
                       {
                           TransactionId = editFormModel.TransactionId,
                           Amount = editFormModel.Amount,
                           BillBarCode = editFormModel.BillBarCode,
                           Customer = editFormModel.Customer,
                           Points = editFormModel.Points,
                           Store = editFormModel.Store
                       };
        }

        #endregion
    }
}