using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Models;

//using SolucionesARWebsite.ModelsWebsite.Forms.Transactions;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Transactions;

namespace SolucionesARWebsite.Controllers
{
    public class TransactionsController : Controller
    {
        private DbModel db = new DbModel();

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

        public TransactionsController()
        {
            _transactionsManagement = new TransactionsManagement();
            _usersManagement = new UsersManagement();
            _storesManagement = new StoresManagement();
        }

        #endregion

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
        // GET: /Transactions/Details/5

        public ActionResult Details(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
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
                                        BillBarCode = "",
                                        Store = new Store(),
                                        ListStores = storsList,
                                        Customer = new User(),
                                        ListCustomers = usersList,
                                        SalesMan = new User(),
                                        ListSalesMan = usersList,
                                    };
            return View("Edit", editViewModel);
        }

        //
        // POST: /Transactions/Create

    /*    [HttpPost]
        public ActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "PhoneNumber1", transaction.StoreId);
            ViewBag.SalesManId = new SelectList(db.Users, "UserId", "FName", transaction.SalesManId);
            ViewBag.CustomerId = new SelectList(db.Users, "UserId", "FName", transaction.CustomerId);
            return View(transaction);
        }
        */
        //
        // GET: /Transactions/Edit/5

        public ActionResult Edit(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "PhoneNumber1", transaction.StoreId);
            ViewBag.SalesManId = new SelectList(db.Users, "UserId", "FName", transaction.SalesManId);
            ViewBag.CustomerId = new SelectList(db.Users, "UserId", "FName", transaction.CustomerId);
            return View(transaction);
        }

        //
        // POST: /Transactions/Edit/5

        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StoreId = new SelectList(db.Stores, "StoreId", "PhoneNumber1", transaction.StoreId);
            ViewBag.SalesManId = new SelectList(db.Users, "UserId", "FName", transaction.SalesManId);
            ViewBag.CustomerId = new SelectList(db.Users, "UserId", "FName", transaction.CustomerId);
            return View(transaction);
        }

        //
        // GET: /Transactions/Delete/5

        public ActionResult Delete(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //
        // POST: /Transactions/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            string path = System.IO.Path.Combine(Server.MapPath("~/Files"), System.IO.Path.GetFileName(file.FileName));
            file.SaveAs(path);
            ViewBag.Message = "File uploaded successfully";
            //guardo lo q traiga el file
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}