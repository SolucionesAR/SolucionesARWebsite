
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Customers;

namespace SolucionesARWebsite2.Controllers
{
    public class CustomersController  : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CustomersManagement _customersManagement;

        #endregion

        #region Constructors

        public CustomersController(CustomersManagement customersManagement, 
            UsersManagement usersManagement)
            : base(usersManagement)
        {
            _customersManagement = customersManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _customersManagement.GetCustomers();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {

            var editViewModel = new EditViewModel
                {
                    CustomerId = 0,
                    Boss = string.Empty,
                    CedNumber = string.Empty,
                    FName = string.Empty,
                    LName = string.Empty,
                    PhoneNumber = string.Empty,
                    Possition = string.Empty,
                    Salary = string.Empty

                };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _customersManagement.GetCustomer(id);

            var editViewModel = Map(customer);

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                _customersManagement.Save(editViewModel);
                return RedirectToAction("Index");
            }
            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private EditViewModel Map(Customer customer)
        {
            var editViewModel = new EditViewModel
                                    {
                                        CustomerId = customer.CustomerId,
                                        FName = customer.FName,
                                        LName = customer.LName,
                                        Boss = customer.Boss,
                                        CedNumber = customer.CedNumber,
                                        PhoneNumber = customer.PhoneNumber,
                                        Possition = customer.Possition,
                                        Salary = customer.Salary,
                                        CreatedAt = customer.CreatedAt
                                    };
            return editViewModel;
        }

        #endregion
    }
}
