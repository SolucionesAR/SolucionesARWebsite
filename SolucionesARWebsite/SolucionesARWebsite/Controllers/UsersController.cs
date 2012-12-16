using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Users;

namespace SolucionesARWebsite.Controllers
{
    public class UsersController : BaseController
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly CantonsManagement _cantonsManagement;
        private readonly CompaniesManagement _companiesManagement;
        private readonly DistrictsManagement _districtsManagement;
        private readonly ProvincesManagement _provincesManagement;
        private readonly RelationshipTypesManagement _relationshipTypesManagement;
        private readonly RolesManagement _rolesManagement;
        private readonly TransactionsManagement _transactionsManagement;

        #endregion

        #region Constructors

        public UsersController(CantonsManagement cantonsManagement, CompaniesManagement companiesManagement,
            DistrictsManagement districtsManagement, ProvincesManagement provincesManagement,
            RelationshipTypesManagement relationshipTypesManagement, RolesManagement rolesManagement,
            TransactionsManagement transactionsManagement, 
            UsersManagement usersManagement)
            : base(usersManagement)
        {
            _cantonsManagement = cantonsManagement;
            _companiesManagement = companiesManagement;
            _districtsManagement = districtsManagement;
            _provincesManagement = provincesManagement;
            _relationshipTypesManagement = relationshipTypesManagement;
            _rolesManagement = rolesManagement;
            _transactionsManagement = transactionsManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = UsersManagement.GetUsersList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Details(int id)
        {
            var userInformation = UsersManagement.GetUser(id);
            var detailsViewModel = new DetailsViewModel
                                       {
                                           UserId = id,
                                           IdentificationNumber = userInformation.CedNumber,
                                           FName = userInformation.FName,
                                           LName1 = userInformation.LName1,
                                           LName2 = userInformation.LName2,
                                           Cashback = string.Format("{0} colones", userInformation.Cashback),
                                           Enabled = userInformation.Enabled,
                                           GeneratedCode =
                                               GenerateUserCode(userInformation.LName1, userInformation.LName2,
                                                                userInformation.CedNumber
                                                                    .ToString(CultureInfo.InvariantCulture)),
                                           LastTransactions = _transactionsManagement.GetLastTransactions(id),
                                       };

            return View(detailsViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        UserId = 0,
                                        CantonId = (int) Constants.DefaultCanton,
                                        Company = new Company(),
                                        CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext),
                                        Dob = DateTime.UtcNow,
                                        DistrictId = (int) Constants.DefaultDistrict,
                                        IdentificationType =
                                            new IdentificationType
                                                {
                                                    IdentificationTypeId =
                                                        (int) IdentificationTypes.CedNumber
                                                },
                                        IdentificationTypesList = GetIdentificationTypesList(),
                                        ProvinceId = (int) Constants.DefaultProvince,
                                        RelationshipType = new RelationshipType(),
                                        RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                                        RolesList = _rolesManagement.GetRoles(SecurityContext),
                                        UserRol = new Rol(),
                                        UserReference = string.Empty,
                                    };

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons((int) Constants.DefaultProvince);
            ViewBag.DistrictsList = _districtsManagement.GetDistricts((int) Constants.DefaultCanton);

            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var userInformation = UsersManagement.GetUser(id);
            var canton = _cantonsManagement.GetCantonByDistrict(userInformation.District.DistrictId);
            var province = _provincesManagement.GetProvinceByCanton(canton.CantonId);

            var editViewModel = new EditViewModel
                                    {
                                        Address1 = userInformation.Address1,
                                        Cashback = userInformation.Cashback.ToString(CultureInfo.InvariantCulture),
                                        CantonId = canton.CantonId,
                                        Cellphone = userInformation.Cellphone,
                                        CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext),
                                        Company = userInformation.Company,
                                        DistrictId = userInformation.District.DistrictId,
                                        Dob = userInformation.Dob,
                                        Email = userInformation.Email,
                                        Enabled = userInformation.Enabled,
                                        FirstName = userInformation.FName,
                                        GeneratedCode = userInformation.GeneratedCode,
                                        IdentificationNumber =
                                            userInformation.CedNumber.ToString(CultureInfo.InvariantCulture),
                                        IdentificationType =
                                            new IdentificationType
                                                {IdentificationTypeId = (int) IdentificationTypes.CedNumber},
                                        IdentificationTypesList = GetIdentificationTypesList(),
                                        LastName1 = userInformation.LName1,
                                        LastName2 = userInformation.LName2,
                                        Nationality = userInformation.Nationality,
                                        PhoneNumber = userInformation.PhoneNumber,
                                        ProvinceId = province.ProvinceId,
                                        RelationshipType = userInformation.RelationshipType,
                                        RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                                        RolesList = _rolesManagement.GetRoles(SecurityContext),
                                        UserId = userInformation.UserId,
                                        UserRol = userInformation.UserRol,
                                        UserReference =
                                            userInformation.UserReference != null
                                                ? userInformation.UserReference.GeneratedCode
                                                : string.Empty,
                                    };

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons(province.ProvinceId);
            ViewBag.DistrictsList = _districtsManagement.GetDistricts(canton.CantonId);

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid)
            {
                editViewModel.GeneratedCode =
                    GenerateUserCode(editViewModel.LastName1, editViewModel.LastName2,
                                     editViewModel.IdentificationNumber.ToString(
                                         CultureInfo.InvariantCulture));
                UsersManagement.Save(editViewModel, SecurityContext.User.Id);
            }
            
            editViewModel.CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext);
            editViewModel.IdentificationTypesList = GetIdentificationTypesList();
            editViewModel.RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList();
            editViewModel.RolesList = _rolesManagement.GetRoles(SecurityContext);

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons(editViewModel.ProvinceId);
            ViewBag.DistrictsList = _districtsManagement.GetDistricts(editViewModel.CantonId);

            return View("Edit", editViewModel);
        }

        public JsonResult IsValidParentUser(string parentUser)
        {
            var user = UsersManagement.GetUser(parentUser);
            //TODO: missing users table modification
            //check if the user...
            //1. exists
            //2. is senior or master
            //3. has enoght space to add a new children
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Private Members
        
        private static string GenerateUserCode(string lastName1, string lastName2, string cedNumber)
        {
            var lastName1Encoded = lastName1 != null
                                       ? lastName1.Length >= 4
                                             ? lastName1.Substring(0, 4)
                                             : lastName1
                                       : string.Empty;
            var lastName2Encoded = lastName2 != null
                                       ? lastName2.Length >= 4
                                             ? lastName2.Substring(0, 4)
                                             : lastName2
                                       : string.Empty;
            var cedNumberEncoded = cedNumber != null
                                       ? cedNumber
                                             .ToString(CultureInfo.InvariantCulture).Substring(0, 4)
                                       : string.Empty;

            return string.Format("{0}{1}{2}", lastName1Encoded, lastName2Encoded, cedNumberEncoded);
        }

        private static List<IdentificationType> GetIdentificationTypesList()
        {
            var identificationsList = new List<IdentificationType>();
            foreach (var idType in EnumUtil.GetValues<IdentificationTypes>())
            {
                identificationsList.Add(new IdentificationType { IdentificationTypeId = (int)idType, IdentificationDescription = Enumerations.Enumerations.GetDescription(idType) });
            }
            return identificationsList;
        }

        #endregion
    }
}