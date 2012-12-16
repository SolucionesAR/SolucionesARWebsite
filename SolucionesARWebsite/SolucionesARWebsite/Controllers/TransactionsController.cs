using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Transactions;

namespace SolucionesARWebsite.Controllers
{
    public class TransactionsController : BaseController
    {
        #region Private Members

        private readonly TransactionsManagement _transactionsManagement;
        private readonly UsersManagement _usersManagement;
        private readonly StoresManagement _storesManagement;

        #endregion

        #region Constructors

        public TransactionsController(UsersManagement usersManagement, TransactionsManagement transactionsManagement)
            : base(usersManagement)
        {
            _transactionsManagement = transactionsManagement;
            _usersManagement = usersManagement;
            _storesManagement = new StoresManagement();
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _transactionsManagement.GetTransactions();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);
           
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
        public ActionResult Save(EditViewModel editFormModel)
        {
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
            editFormModel.CustomersList = _usersManagement.GetUsersList();
            editFormModel.StoresList = _storesManagement.GetStores();
            return View("Edit", editFormModel);
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
        #endregion
    }
}