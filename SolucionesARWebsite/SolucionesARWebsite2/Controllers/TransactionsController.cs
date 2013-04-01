using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Transactions;

namespace SolucionesARWebsite2.Controllers
{
    public class TransactionsController : BaseController
    {
        #region Private Members

        private readonly TransactionsManagement _transactionsManagement;
        private readonly UsersManagement _usersManagement;
        private readonly StoresManagement _storesManagement;
        private readonly CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public TransactionsController(UsersManagement usersManagement, StoresManagement storesManagement, TransactionsManagement transactionsManagement, CompaniesManagement companiesManagement)
            : base(usersManagement)
        {
            _transactionsManagement = transactionsManagement;
            _usersManagement = usersManagement;
            _storesManagement = storesManagement;
            _companiesManagement = companiesManagement;
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
            var companiesList = _companiesManagement.GetCompaniesList();
            var editViewModel = new EditViewModel
                                    {
                                        TransactionId = 0,
                                        Amount = 0.0,
                                        Points = 50,
                                        BillBarCode = "",
                                        Company = new Company(),
                                        CompaniesList = companiesList,
                                        Customer = new User(),
                                        CustomersList = usersList,
                                        TransactionDate = "01/01/1970",
                                        Comision = 0.0,
                                        //SalesMan = new User(),
                                        //ListSalesMan = usersList,
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult FileUpload()
        {
            var usersList = _usersManagement.GetUsersList();
            var companiesList = _companiesManagement.GetCompaniesList();
            var editViewModel = new EditViewModel
                                    {
                                        TransactionId = 0,
                                        Amount = 50.0,
                                        BillBarCode = "",
                                        Company = new Company(),
                                        CompaniesList = companiesList,
                                        Customer = new User(),
                                        CustomersList = usersList,
                                        TransactionDate = "01/01/1970",
                                        Comision = 0.0,
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
                                        Company = transaction.Company,
                                        CompaniesList = _companiesManagement.GetCompaniesList(),
                                        Customer = transaction.Customer,
                                        CustomersList = _usersManagement.GetUsersList(),
                                        Points = transaction.Points,
                                        TransactionDate = transaction.TransactionDate.ToString("dd/MM/yyyy"),
                                        Comision = transaction.Comision,
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
                    var comision = editFormModel.Comision == 0.0
                                   ? editFormModel.Amount*editFormModel.Company.CashBackPercentaje/100
                                   : editFormModel.Comision;
                    transaction = new Transaction
                                      {
                                          TransactionId = 0,
                                          Amount = editFormModel.Amount,
                                          BillBarCode = editFormModel.BillBarCode,
                                          CreatetedAt = DateTime.UtcNow,
                                          UpdatedAt = DateTime.UtcNow,
                                          TransactionDate = Convert.ToDateTime(editFormModel.TransactionDate),
                                          CustomerId = editFormModel.Customer.UserId,
                                          Points = editFormModel.Points,
                                          CompanyId = editFormModel.Company.CompanyId,
                                          Comision = comision,
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
                    transaction.CompanyId = editFormModel.Company.CompanyId;
                    transaction.TransactionDate = Convert.ToDateTime(editFormModel.TransactionDate);
                    transaction.UpdatedAt = DateTime.UtcNow;
                    transaction.Comision = editFormModel.Comision;
                    _transactionsManagement.UpdateTransaction();
                }
            }
            editFormModel.CustomersList = _usersManagement.GetUsersList();
            editFormModel.CompaniesList = _companiesManagement.GetCompaniesList();
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