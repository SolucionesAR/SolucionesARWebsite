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

        private readonly CompaniesManagement _companiesManagement;
        private readonly LocationsManagement _locationsManagement;
        private readonly RelationshipsManagement _relationshipsManagement;
        private readonly RelationshipTypesManagement _relationshipTypesManagement;
        private readonly RolesManagement _rolesManagement;
        private readonly TransactionsManagement _transactionsManagement;

        #endregion

        #region Constructors

        public UsersController(CompaniesManagement companiesManagement,
            RelationshipsManagement relationshipsManagement, 
            RelationshipTypesManagement relationshipTypesManagement,
            RolesManagement rolesManagement,
            TransactionsManagement transactionsManagement, 
            UsersManagement usersManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
            _relationshipsManagement = relationshipsManagement;
            _relationshipTypesManagement = relationshipTypesManagement;
            _rolesManagement = rolesManagement;
            _transactionsManagement = transactionsManagement;

            _locationsManagement = new LocationsManagement();
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
                                        IdentificationTypesList = GetIdentificationTypesList(),
                                        IdentificationType =
                                            new IdentificationType
                                                {
                                                    IdentificationTypeId =
                                                        (int) IdentificationTypes.CedNumber
                                                },
                                        Company = new Company(),
                                        CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext),
                                        Province = _locationsManagement.GetProvince(1),
                                        ProvincesList = _locationsManagement.GetAllProvinces(),
                                        Canton = new Canton(),
                                        CantonsList = _locationsManagement.GetCantonsByProvince(1),
                                        //CantonsList = 
                                        Dob = DateTime.UtcNow,
                                        District = new District(),
                                        DistrictsList = _locationsManagement.GetDistrictsByCanton(1),
                                        RelationshipType = new RelationshipType(),
                                        RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                                        UserRol = new Rol(),
                                        RolesList = _rolesManagement.GetRoles(SecurityContext),
                                        //DistrictsList = 
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var userInformation = UsersManagement.GetUser(id);
            var canton = _locationsManagement.GetCantonByDistrict(userInformation.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            var relationshipType =
                userInformation.UserReferenceId != null
                    ? _relationshipsManagement.GetRelationshipType(userInformation.UserId,
                                                                   (int) userInformation.UserReferenceId) ??
                      new RelationshipType {RelationshipTypeId = 0}
                    : new RelationshipType {RelationshipTypeId = 0};

            var editViewModel = new EditViewModel
                                    {
                                        Address1 = userInformation.Address1,
                                        Cashback = userInformation.Cashback.ToString(CultureInfo.InvariantCulture),
                                        Cellphone = userInformation.Cellphone,
                                        Dob = userInformation.Dob,
                                        Email = userInformation.Email,
                                        Enabled = userInformation.Enabled,
                                        FirstName = userInformation.FName,
                                        GeneratedCode = userInformation.GeneratedCode,
                                        LastName1 = userInformation.LName1,
                                        LastName2 = userInformation.LName2,
                                        Nationality = userInformation.Nationality,
                                        UserId = userInformation.UserId,

                                        Canton = canton,
                                        CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId),
                                        Company = userInformation.Company,
                                        CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext),
                                        District = userInformation.District,
                                        DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId),
                                        IdentificationNumber =
                                            userInformation.CedNumber.ToString(CultureInfo.InvariantCulture),
                                        IdentificationType =
                                            new IdentificationType
                                                {IdentificationTypeId = (int) IdentificationTypes.CedNumber},
                                        IdentificationTypesList = GetIdentificationTypesList(),
                                        ParentUser =
                                            userInformation.UserReference != null
                                                ? userInformation.UserReference.GeneratedCode
                                                : string.Empty,
                                        PhoneNumber = userInformation.PhoneNumber,
                                        Province = province,
                                        ProvincesList = _locationsManagement.GetAllProvinces(),
                                        RelationshipType = relationshipType,
                                        RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                                        UserRol = userInformation.UserRol,
                                        RolesList = _rolesManagement.GetRoles(SecurityContext),
                                    };
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

            var canton = _locationsManagement.GetCantonByDistrict(editViewModel.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            editViewModel.ProvincesList = _locationsManagement.GetAllProvinces();
            editViewModel.CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId);
            editViewModel.DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId);

            editViewModel.CompaniesList = _companiesManagement.GetCompaniesList(SecurityContext);
            editViewModel.IdentificationTypesList = GetIdentificationTypesList();
            editViewModel.RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList();
            editViewModel.RolesList = _rolesManagement.GetRoles(SecurityContext);

            return View("Edit", editViewModel);
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