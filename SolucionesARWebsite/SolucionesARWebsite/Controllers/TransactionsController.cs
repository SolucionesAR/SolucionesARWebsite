using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.IO;
using System.Linq;
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

        #region Constants
        #endregion

        #region Properties

        #endregion

        #region Private Members
        private TransactionsManagement _transactionsManagement;
        private UsersManagement _usersManagement;
        private StoresManagement _storesManagement;

        #endregion

        #region Constructors

        public TransactionsController(UsersManagement usersManagement, TransactionsManagement transactionsManagement)
        {
            _transactionsManagement = transactionsManagement;
            _usersManagement = usersManagement;
            _storesManagement = new StoresManagement();
        }

        #endregion

        #region public methods

        //
        // GET: /Transactions/

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


        //
        // GET: /Transactions/Create

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
                ListStores = storsList,
                Customer = new User(),
                ListCustomers = usersList,
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
                ListStores = storsList,
                Customer = new User(),
                ListCustomers = usersList,
                //SalesMan = new User(),
                //ListSalesMan = usersList,
            };
            return View("FileUpload", editViewModel);
        }


        //
        // GET: /Transactions/Edit/5

        public ActionResult Edit(int id)
        {
            var transaction = _transactionsManagement.GetTransaction(id);
            var usersList = _usersManagement.GetUsersList();
            var storsList = _storesManagement.GetStores();
            var editViewModel = new EditViewModel
            {
                TransactionId = id,
                Amount = transaction.Amount,
                BillBarCode = transaction.BillBarCode,
                Store = transaction.Store,
                ListStores = storsList,
                Customer = transaction.Customer,
                ListCustomers = usersList,
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
            var usersList = _usersManagement.GetUsersList();
            var storsList = _storesManagement.GetStores();
            editFormModel.ListCustomers = usersList;
            editFormModel.ListStores = storsList;
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

                bool result = _transactionsManagement.SaveTransactions(filename, sheetName);
                //TODO: aqui necesitamos devolver la misma vista pero con un error si falla...
                return RedirectToAction(result ? "Index" : "FileUpload");
            }
            //TODO: aqui necesitamos devolver la misma vista pero con un error...

            return RedirectToAction("FileUpload");
        }

        #endregion

        #region Private Methods

        private EditViewModel ModelViewFromForm(EditFormModel editFormModel)
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