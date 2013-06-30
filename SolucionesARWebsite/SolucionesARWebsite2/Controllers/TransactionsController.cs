using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public TransactionsController(UsersManagement usersManagement, TransactionsManagement transactionsManagement, CompaniesManagement companiesManagement)
            : base(usersManagement)
        {
            _transactionsManagement = transactionsManagement;
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
            var usersList = GetAvailableUsersList();
            var usersToShow = GenerateUsersToShow(usersList);
            var companiesList = _companiesManagement.GetCompaniesList();
            var now = DateTime.Now;
            var editViewModel = new EditViewModel
                {
                    TransactionId = 0,
                    Amount = 0.0,
                    Points = 50,
                    BillBarCode = "",
                    Company = new Company(),
                    CompaniesList = companiesList,
                    Customer = new User(),
                    //CustomersList = usersList,
                    TransactionDate = now.Day + "/" + now.Month + "/" + now.Year,
                    Comision = 0.0,
                    UsersToShowList = usersToShow
                    //SalesMan = new User(),
                    //ListSalesMan = usersList,
                };

            return View("Edit", editViewModel);
        }

        public ActionResult FileUpload()
        {
            var usersList = GetAvailableUsersList();
            var usersToShow = GenerateUsersToShow(usersList);
            var companiesList = _companiesManagement.GetCompaniesList();
            var now = DateTime.Now;
            var editViewModel = new EditViewModel
                {
                    TransactionId = 0,
                    Amount = 50.0,
                    BillBarCode = "",
                    Company = new Company(),
                    CompaniesList = companiesList,
                    Customer = new User(),
                    //CustomersList = usersList,
                    TransactionDate = now.Day + "/" + now.Month + "/" + now.Year,
                    Comision = 0.0,
                    UsersToShowList = usersToShow
                    //SalesMan = new User(),
                    //ListSalesMan = usersList,
                };

            return View("FileUpload", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var transaction = _transactionsManagement.GetTransaction(id);
            var usersList = GetAvailableUsersList();
            var usersToShow = GenerateUsersToShow(usersList);
            var editViewModel = new EditViewModel
                {
                    TransactionId = id,
                    Amount = transaction.Amount,
                    BillBarCode = transaction.BillBarCode,
                    Company = transaction.Company,
                    CompaniesList = _companiesManagement.GetCompaniesList(),
                    Customer = transaction.User,
                    //CustomersList = GetAvailableUsersList(),
                    Points = transaction.Points,
                    TransactionDate = transaction.TransactionDate.ToString("dd/MM/yyyy"),
                    Comision = transaction.Comision,
                    UsersToShowList = usersToShow
                };

            return View("Edit", editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                Transaction transaction;
                var company = _companiesManagement.GetCompany(editFormModel.Company.CompanyId);
                var comision = editFormModel.Comision < 0.0000001
                                   ? editFormModel.Amount*company.CashBackPercentaje/100
                                   : editFormModel.Comision;
                if (editFormModel.TransactionId == 0)
                {

                    transaction = new Transaction
                        {
                            TransactionId = 0,
                            Amount = editFormModel.Amount,
                            BillBarCode = editFormModel.BillBarCode,
                            CreatetedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            TransactionDate = Convert.ToDateTime(editFormModel.TransactionDate),
                            UserId = editFormModel.Customer.UserId,
                            Points = editFormModel.Points,
                            CompanyId = editFormModel.Company.CompanyId,
                            Comision = comision,
                        };
                    _transactionsManagement.SaveTransaction(transaction);
                    return RedirectToAction("Index");
                }

                transaction = _transactionsManagement.GetTransaction(editFormModel.TransactionId);
                transaction.BillBarCode = editFormModel.BillBarCode;
                transaction.Amount = editFormModel.Amount;
                transaction.UserId = editFormModel.Customer.UserId;
                transaction.Points = editFormModel.Points;
                transaction.CompanyId = editFormModel.Company.CompanyId;
                transaction.TransactionDate = Convert.ToDateTime(editFormModel.TransactionDate);
                transaction.UpdatedAt = DateTime.Now;
                transaction.Comision = comision;
                _transactionsManagement.UpdateTransaction();
                return RedirectToAction("Index");
            }

            //editFormModel.CustomersList = GetAvailableUsersList();
            var usersList = GetAvailableUsersList();
            var usersToShow = GenerateUsersToShow(usersList);
            editFormModel.CompaniesList = _companiesManagement.GetCompaniesList();
            editFormModel.UsersToShowList = usersToShow;
            return View("Edit", editFormModel);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, string sheetName)
        {
            if (file != null)
            {
                var filename = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));

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

        private static List<UserToShow> GenerateUsersToShow(IEnumerable<User> usersList)
        {
            return usersList.Select(user => new UserToShow
            {
                UserToShowId = user.UserId,
                CustomerName = user.FName + " " + user.LName1 + " " + user.LName2 + " - " + user.CedNumber
            }).ToList();
        }

        #endregion
    }
}