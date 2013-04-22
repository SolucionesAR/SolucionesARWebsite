using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Users;

namespace SolucionesARWebsite2.Controllers
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

        public ActionResult Pay(int id)
        {
            var userInformation = UsersManagement.GetUser(id);
            var detailsViewModel = new PayViewModel
                                       {
                                           UserId = id,
                                           IdentificationNumber = userInformation.CedNumber,
                                           FName = userInformation.FName,
                                           LName1 = userInformation.LName1,
                                           LName2 = userInformation.LName2,
                                           LastCashback = userInformation.Cashback,
                                           Cashback = 0,
                                       };

            return View(detailsViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = GenerateBasicEditViewModel();
            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons((int) Constants.DefaultProvince);
            ViewBag.DistrictsList = _districtsManagement.GetDistricts((int) Constants.DefaultCanton);

            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var user = UsersManagement.GetUser(id);
            var canton = _cantonsManagement.GetCantonByDistrict(user.District.DistrictId);
            var province = _provincesManagement.GetProvinceByCanton(canton.CantonId);

            var editViewModel = Map(user);
            editViewModel.CantonId = canton.CantonId;
            editViewModel.ProvinceId = province.ProvinceId;

            ViewBag.ProvincesList = _provincesManagement.GetProvinces();
            ViewBag.CantonsList = _cantonsManagement.GetCantons(province.ProvinceId);
            ViewBag.DistrictsList = _districtsManagement.GetDistricts(canton.CantonId);

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            if (ModelState.IsValid && IsValidUser(editViewModel))
            {
                UsersManagement.Save(Map(editViewModel), SecurityContext.User.Id);
                return RedirectToAction("Index");
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

        [HttpPost]
        public ActionResult SavePayment(PayViewModel payViewModel)
        {
            if (ModelState.IsValid && IsValidPayment(payViewModel))
            {
                var newCashback = payViewModel.LastCashback - payViewModel.Cashback;
                UsersManagement.SavePayment(payViewModel.UserId, newCashback, SecurityContext.User.Id);
                return RedirectToAction("Index");
            }

            return View("Pay", payViewModel);
        }

        public JsonResult IsValidParentUser(string identificationNumber)
        {
            var user =
                UsersManagement.GetUserByIdentificationNumber(
                    Convert.ToInt32(identificationNumber.Replace("-", string.Empty)));
            //TODO: missing users table modification
            //check if the user...
            //1. exists
            if (user != null)
            {
                //2. is senior or master
                if (user.RelationshipType.RelationshipTypeId.Equals((int) RelationshipTypes.Senior) ||
                    user.RelationshipType.RelationshipTypeId.Equals((int) RelationshipTypes.Master))
                {
                    //3. has enoght space to add a new children
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Private Members

        private bool IsValidUser(EditViewModel editViewModel)
        {
            //if it's a new user doesn't required the identification number validation
            if (editViewModel.UserId != 0 &&
                !UsersManagement.HasValidIdentificationNumber(editViewModel.UserId, editViewModel.IdentificationNumber))
            {
                ModelState.AddModelError("IdentificationNumber",
                                         "El número de idetificación ya está registrado en el sistema.");
                return false;
            }
            return true;
        }

        private bool IsValidPayment(PayViewModel payViewModel)
        {
            return (payViewModel.Cashback >= 0) && (payViewModel.Cashback <= payViewModel.LastCashback);
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

        private static string GenerateUserCode(string lastName1, string lastName2, string identificationNumber)
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
            var cedNumberEncoded = identificationNumber != null
                                       ? identificationNumber.Replace("-", string.Empty)
                                             .ToString(CultureInfo.InvariantCulture).Substring(0, 4)
                                       : string.Empty;

            return string.Format("{0}{1}{2}", lastName1Encoded, lastName2Encoded, cedNumberEncoded);
        }

        private EditViewModel GenerateBasicEditViewModel()
        {
            var editViewModel = new EditViewModel
            {
                UserId = 0,
                CantonId = (int)Constants.DefaultCanton,
                Company = new Company(),
                CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext),
                Dob = DateTime.UtcNow,
                DistrictId = (int)Constants.DefaultDistrict,
                Enabled = true,
                IdentificationType =
                    new IdentificationType
                    {
                        IdentificationTypeId =
                            (int)IdentificationTypes.CedNumber
                    },
                IdentificationTypesList = GetIdentificationTypesList(),
                ProvinceId = (int)Constants.DefaultProvince,
                RelationshipType = new RelationshipType(),
                RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                RolesList = _rolesManagement.GetRoles(SecurityContext),
                UserRol = new Rol(),
                ParentIdentificationNumber = Constants.SolucionesArUser.ToString(),
            };
            return editViewModel;
        }

        private User Map(EditViewModel editViewModel)
        {
            var user = new User
                           {
                               Address1 =
                                   editViewModel.Address1 != null ? editViewModel.Address1.ToUpper() : string.Empty,
                               Cashback = editViewModel.Cashback != null ? Convert.ToDouble(editViewModel.Cashback) : 0,
                               CedNumber =
                                   Convert.ToInt32(editViewModel.IdentificationNumber.Replace("-", string.Empty)),
                               Cellphone = editViewModel.Cellphone,
                               CompanyId = editViewModel.Company.CompanyId,
                               DistrictId = editViewModel.DistrictId,
                               Dob = Convert.ToDateTime(editViewModel.Dob),
                               Email = editViewModel.Email != null ? editViewModel.Email.ToUpper() : string.Empty,
                               Enabled = editViewModel.Enabled,
                               FName = editViewModel.FirstName.ToUpper(),
                               GeneratedCode =
                                   GenerateUserCode(editViewModel.LastName1, editViewModel.LastName2,
                                                    editViewModel.IdentificationNumber
                                                        .ToString(CultureInfo.InvariantCulture)).ToUpper(),
                               LName1 = editViewModel.LastName1.ToUpper(),
                               LName2 = editViewModel.LastName2.ToUpper(),
                               Nationality = editViewModel.Nationality.ToUpper(),
                               IdentificationTypeId = editViewModel.IdentificationType.IdentificationTypeId,
                               RolId = editViewModel.UserRol.RolId,
                               PhoneNumber = editViewModel.PhoneNumber,
                               RelationshipTypeId = editViewModel.RelationshipType.RelationshipTypeId,
                               UserId = editViewModel.UserId,
                               UserReferenceId = !string.IsNullOrEmpty(editViewModel.ParentIdentificationNumber)
                                                     ? UsersManagement.GetUserByIdentificationNumber(
                                                         Convert.ToInt32(
                                                             editViewModel.ParentIdentificationNumber.Replace("-", string.Empty)))
                                                           .UserId
                                                     : (int) Constants.SolucionesArUser,
                           };

            //update the user password with the SAR generated code
            user.Password = BCrypt.Net.BCrypt.HashPassword(
                user.GeneratedCode,
                BCrypt.Net.BCrypt.GenerateSalt((int) Constants.WorkFactor));
            return user;
        }

        private EditViewModel Map(User user)
        {
            var editViewModel = new EditViewModel
                                    {
                                        Address1 = user.Address1,
                                        Cashback = user.Cashback.ToString(CultureInfo.InvariantCulture),
                                        Cellphone = user.Cellphone,
                                        CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext),
                                        Company = user.Company,
                                        DistrictId = user.District.DistrictId,
                                        Dob = user.Dob != null ? (DateTime) user.Dob : DateTime.UtcNow,
                                        Email = user.Email,
                                        Enabled = user.Enabled,
                                        FirstName = user.FName,
                                        GeneratedCode = user.GeneratedCode,
                                        IdentificationNumber =
                                            user.CedNumber.ToString(CultureInfo.InvariantCulture),
                                        IdentificationType =
                                            new IdentificationType
                                                {IdentificationTypeId = (int) IdentificationTypes.CedNumber},
                                        IdentificationTypesList = GetIdentificationTypesList(),
                                        LastName1 = user.LName1,
                                        LastName2 = user.LName2,
                                        Nationality = user.Nationality,
                                        PhoneNumber = user.PhoneNumber,
                                        RelationshipType = user.RelationshipType,
                                        RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                                        RolesList = _rolesManagement.GetRoles(SecurityContext),
                                        UserId = user.UserId,
                                        UserRol = user.UserRol,
                                        ParentIdentificationNumber =
                                            user.UserReference != null
                                                ? user.UserReference.CedNumber.ToString(CultureInfo.InvariantCulture)
                                                : Constants.SolucionesArUser.ToString(),
                                    };
            return editViewModel;
        }

        #endregion
    }
}