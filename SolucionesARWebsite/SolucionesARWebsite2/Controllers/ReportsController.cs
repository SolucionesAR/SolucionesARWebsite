﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OfficeOpenXml;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Utils;
using SolucionesARWebsite2.ViewModels.Reports;
using IndexViewModel = SolucionesARWebsite2.ViewModels.Reports.IndexViewModel;
using Report = SolucionesARWebsite2.ViewModels.Reports.Report;

namespace SolucionesARWebsite2.Controllers
{
    public class ReportsController : BaseController
    {

        #region Constants

        private const string CODIGO_FACTURA = "Codigo Factura";
        private const string MONTO = "Monto";
        private const string PUNTOS = "Puntos";
        private const string NOMBRE_VENDEDOR = "Nombre Vendedor";
        private const string CODIGO_SAR = "Codigo SAR";
        private const string FECHA = "Fecha";
        private const string TIENDA = "Tienda";
        private const string COMPANIA = "Compania";


        #endregion

        #region Private Members

        private readonly CompaniesManagement _companiesManagement;
        private readonly TransactionsManagement _transactionsManagement;

        #endregion

        #region Constructors

        public ReportsController(CompaniesManagement companiesManagement, TransactionsManagement transactionsManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
            _transactionsManagement = transactionsManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            var results = GetReportsList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult SolucionesAr()
        {
            return View(new BaseReportViewModel());
        }

        [HttpPost]
        public ActionResult SolucionesAr(BaseReportViewModel reportViewModel)
        {
            var transactionsList = _transactionsManagement.GetTransactions(reportViewModel.BeginningDate,
                                                                           reportViewModel.EndingDate);
            var tList = ReportInfoFromList(transactionsList);
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Primera Hoja");

                //Here we have to select one of the following options: Manual or Auto writting
                //With the auto option, we should create a new class to avoid the complex objects mapping problems
                //instead of using the simple Transaction Class

                //1. Manual

                worksheet.Cells["A1"].Value = CODIGO_FACTURA;
                worksheet.Cells["B1"].Value = MONTO;
                worksheet.Cells["C1"].Value = PUNTOS;
                worksheet.Cells["D1"].Value = CODIGO_SAR;
                worksheet.Cells["E1"].Value = NOMBRE_VENDEDOR;
                worksheet.Cells["F1"].Value = FECHA;
                //worksheet.Cells["G1"].Value = TIENDA;
                worksheet.Cells["G1"].Value = COMPANIA;
                /*
                int i = 2;
                foreach (var transaction in transactionsList)
                {
                    worksheet.Cells["A" + i].Value = transaction.Amount;
                    worksheet.Cells["B" + i].Value = transaction.Amount;
                    i++;
                }
                 */
                //2. Automatic
                if (tList != null && tList.Count() != 0)
                {
                    worksheet.Cells["A2"].LoadFromCollection(tList);
                }

                return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "a_cool_name.xls");
            }
        }

        public ActionResult Company()
        {
            var companyReportViewModel = new CompanyReportViewModel
            {
                Company = new Company(),
                CompaniesList = _companiesManagement.GetOrderedCompaniesList()
            };
            return View(companyReportViewModel);
        }

        [HttpPost]
        public ActionResult Company(CompanyReportViewModel reportViewModel)
        {
            var transactionsList = _transactionsManagement.GetTransactions(reportViewModel.Company,
                                                                           reportViewModel.BeginningDate,
                                                                           reportViewModel.EndingDate);

            var tList = ReportInfoFromList(transactionsList);

            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Primera Hoja");

                //Here we have to select one of the following options: Manual or Auto writting
                //With the auto option, we should create a new class to avoid the complex objects mapping problems
                //instead of using the simple Transaction Class

                //1. Manual

                worksheet.Cells["A1"].Value = CODIGO_FACTURA;
                worksheet.Cells["B1"].Value = MONTO;
                worksheet.Cells["C1"].Value = PUNTOS;
                worksheet.Cells["D1"].Value = CODIGO_SAR;
                worksheet.Cells["E1"].Value = NOMBRE_VENDEDOR;
                worksheet.Cells["F1"].Value = FECHA;
                //worksheet.Cells["G1"].Value = TIENDA;
                worksheet.Cells["G1"].Value = COMPANIA;
                /*
                int i = 2;
                foreach (var transaction in transactionsList)
                {
                    worksheet.Cells["A" + i].Value = transaction.Amount;
                    worksheet.Cells["B" + i].Value = transaction.Amount;
                    i++;
                }
                 */
                //2. Automatic

                if (tList != null && tList.Count() != 0)
                {
                    worksheet.Cells["A2"].LoadFromCollection(tList);
                }

                return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "a_cool_name.xls");
            }
        }

        public ActionResult Customer()
        {
            var orderedUsers = _usersManagement.GetOrderedUsersList();
            var usersToShow = GenerateUsersToShowList(orderedUsers);
            var customerReportViewModel = new CustomerReportViewModel
            {
                Customer = new User(),
                UsersToShowList = usersToShow,
            };
            return View(customerReportViewModel);
        }

        [HttpPost]
        public ActionResult Customer(CustomerReportViewModel reportViewModel)
        {
            var transactionsList = _transactionsManagement.GetTransactions(reportViewModel.Customer,
                                                                           reportViewModel.BeginningDate,
                                                                           reportViewModel.EndingDate);
            var tList = ReportInfoFromList(transactionsList);
            using (var excelPackage = new ExcelPackage())
            {
                var worksheet = excelPackage.Workbook.Worksheets.Add("Primera Hoja");

                //Here we have to select one of the following options: Manual or Auto writting
                //With the auto option, we should create a new class to avoid the complex objects mapping problems
                //instead of using the simple Transaction Class

                //1. Manual

                worksheet.Cells["A1"].Value = CODIGO_FACTURA;
                worksheet.Cells["B1"].Value = MONTO;
                worksheet.Cells["C1"].Value = PUNTOS;
                worksheet.Cells["D1"].Value = CODIGO_SAR;
                worksheet.Cells["E1"].Value = NOMBRE_VENDEDOR;
                worksheet.Cells["F1"].Value = FECHA;
                //worksheet.Cells["G1"].Value = TIENDA;
                worksheet.Cells["G1"].Value = COMPANIA;
                /*
                int i = 2;
                foreach (var transaction in transactionsList)
                {
                    worksheet.Cells["A" + i].Value = transaction.Amount;
                    worksheet.Cells["B" + i].Value = transaction.Amount;
                    i++;
                }
                 */
                //2. Automatic
                if (tList != null && tList.Count() != 0)
                {
                    worksheet.Cells["A2"].LoadFromCollection(tList);
                }

                return File(excelPackage.GetAsByteArray(), "application/vnd.ms-excel", "a_cool_name.xls");
            }
        }

        public ActionResult Application()
        {
            return View(new BaseReportViewModel());
        }

        [HttpPost]
        public ActionResult Application(BaseReportViewModel reportViewModel)
        {
            return View();
        }

        #endregion

        #region Private Members

        private static IEnumerable<Report> GetReportsList()
        {
            var reportsList = new List<Report>();
            foreach (var report in EnumUtil.GetValues<ApplicationReports>())
            {
                reportsList.Add(new Report
                                    {
                                        Id = (int) report,
                                        Name = report.ToStringValue(),
                                        Action = report.ToString()
                                    });
            }
            return reportsList;
        }

        private IEnumerable<TransactionForFileType> ReportInfoFromList(IEnumerable<Transaction> transactionsList)
        {
            var transactionsList2 =
                    transactionsList
                        .Select(
                            x => new TransactionForFileType
                            {
                                BillBarCode = x.BillBarCode,
                                Amount = x.Amount,
                                Points = x.Points,
                                CustomerCode = x.User.GeneratedCode,
                                CustomerName = x.User.FName + " " + x.User.LName1 + " " + x.User.LName2,
                                CreatetedAt = x.CreatetedAt.ToString("dd/MM/yyyy"),
                                //StoreName = x.Store.StoreName,
                                CompanyName = x.Company.CompanyNickName,

                            }).
                        ToList();

            return transactionsList2;
        }

        #endregion
    }
}