using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using PagedList;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ViewModels.Users;
using UserRole = SolucionesARWebsite.Enumerations.UserRole;

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
        private readonly UsersManagement _usersManagement;
        private readonly TransactionsManagement _transactionsManagement;
        private readonly LocationsManagement _locationsManagement;
        private readonly RelationshipsManagement _relationshipsManagement;
        private readonly RelationshipTypesManagement _relationshipTypesManagement;

        //to delete
        private readonly RolesManagement _rolesManagement;

        #endregion

        #region Constructors

        public UsersController(CompaniesManagement companiesManagement,
            RelationshipsManagement relationshipsManagement, 
            RelationshipTypesManagement relationshipTypesManagement, 
            TransactionsManagement transactionsManagement, 
            UsersManagement usersManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
            _relationshipsManagement = relationshipsManagement;
            _relationshipTypesManagement = relationshipTypesManagement;
            _transactionsManagement = transactionsManagement;
            _usersManagement = usersManagement;

            _locationsManagement = new LocationsManagement();
            _rolesManagement = new RolesManagement();
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _usersManagement.GetUsersList();
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Details(int id)
        {
            var userInformation = _usersManagement.GetUser(id);
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
                                        UserRol = new Rol(),
                                        RolesList = GetRolesList(SecurityContext),
                                        Company = new Company(),
                                        CompaniesList = _companiesManagement.GetCompanies(SecurityContext),
                                        Province = _locationsManagement.GetProvince(1),
                                        ProvincesList = _locationsManagement.GetAllProvinces(),
                                        Canton = new Canton(),
                                        CantonsList = _locationsManagement.GetCantonsByProvince(1),
                                        //CantonsList = 
                                        District = new District(),
                                        DistrictsList = _locationsManagement.GetDistrictsByCanton(1),
                                        RelationshipType = new RelationshipType(),
                                        RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList(),
                                        //DistrictsList = 
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var userInformation = _usersManagement.GetUser(id);
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
                                        CompaniesList = _companiesManagement.GetCompanies(SecurityContext),
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
                                        RolesList = GetRolesList(SecurityContext),
                                    };
            return View(editViewModel);
        }


        [HttpPost]
        public ActionResult Save(EditViewModel editViewModel)
        {
            //var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                //provisional para salir del paso y no tener que hacer el manejo de roles y id types
                //_rolesManagement.Save(GetRolesList(SecurityContext));
                //_rolesManagement.Save(GetIdentificationTypesList());
                editViewModel.GeneratedCode =
                    GenerateUserCode(editViewModel.LastName1, editViewModel.LastName2,
                                     editViewModel.IdentificationNumber.ToString(
                                         CultureInfo.InvariantCulture));
                _usersManagement.Save(editViewModel, SecurityContext.User.Id);
            }

            var canton = _locationsManagement.GetCantonByDistrict(editViewModel.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            editViewModel.ProvincesList = _locationsManagement.GetAllProvinces();
            editViewModel.CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId);
            editViewModel.DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId);

            editViewModel.RolesList = GetRolesList(SecurityContext);
            editViewModel.CompaniesList = _companiesManagement.GetCompanies(SecurityContext);
            editViewModel.IdentificationTypesList = GetIdentificationTypesList();
            editViewModel.RelationshipTypeList = _relationshipTypesManagement.GetRelationshipTypesList();

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

        private static List<Rol> GetRolesList(SecurityContext securityContext)
        {
            var rolesList = new List<Rol>();
            foreach (var rol in EnumUtil.GetValues<UserRole>())
            {
                if (rol.GetHashCode() < securityContext.User.RoleId)
                {
                    rolesList.Add(new Rol {Name = Roles.GetRoleDescription(rol), RolId = (int) rol,});
                }
            }
            return rolesList;
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