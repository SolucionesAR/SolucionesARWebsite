using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;
using SolucionesARWebsite.Business.Management;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Users;
using SolucionesARWebsite.ModelsWebsite.Lists;
using SolucionesARWebsite.ModelsWebsite.Views.Users;
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
        private readonly TransactionsManagement _transactionsManagement;
        private readonly UsersManagement _usersManagement;
        private readonly LocationsManagement _locationsManagement;

        //to delete
        private readonly RolesManagement _rolesManagement;

        #endregion

        #region Constructors

        public UsersController()
        {
            _companiesManagement = new CompaniesManagement();
            _transactionsManagement = new TransactionsManagement();
            _usersManagement = new UsersManagement();
            _locationsManagement = new LocationsManagement();

            //to delete
            _rolesManagement = new RolesManagement();
        }

        #endregion

        #region Public Actions

        //
        // GET: /Users/
        public ActionResult Index()
        {
            var indexViewModel = new IndexViewModel
                                     {
                                         UsersList = new UsersList
                                                         {
                                                             Items = _usersManagement.GetUsersList(),
                                                         }
                                     };
            return View(indexViewModel);
        }

        //
        // GET: /Users/Details/{id}
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

        //
        // GET: /Users/Create/
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
                                        //DistrictsList = 
                                    };
            return View("Edit", editViewModel);
        }

        //
        // GET: /Users/Edit/{id}
        public ActionResult Edit(int id)
        {
            var userInformation = _usersManagement.GetUser(id);
            var canton = _locationsManagement.GetCantonByDistrict(userInformation.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            var editViewModel = new EditViewModel
                                    {
                                        UserId = userInformation.UserId,
                                        IdentificationNumber =
                                            userInformation.CedNumber.ToString(CultureInfo.InvariantCulture),
                                        IdentificationType =
                                            new IdentificationType
                                                {
                                                    IdentificationTypeId =
                                                        (int) IdentificationTypes.CedNumber
                                                },
                                        IdentificationTypesList = GetIdentificationTypesList(),
                                        Address1 = userInformation.Address1,
                                        FirstName = userInformation.FName,
                                        LastName1 = userInformation.LName1,
                                        LastName2 = userInformation.LName2,
                                        Nationality = userInformation.Nationality,
                                        //Cashback = "₡5,025.00",
                                        Cashback = userInformation.Cashback.ToString(CultureInfo.InvariantCulture),
                                        Enabled = userInformation.Enabled,
                                        GeneratedCode =
                                            GenerateUserCode(userInformation.LName1, userInformation.LName2,
                                                             userInformation.CedNumber.ToString(
                                                                 CultureInfo.InvariantCulture)),
                                        UserRol = userInformation.UserRol,
                                        RolesList = GetRolesList(SecurityContext),
                                        Company = userInformation.Company,
                                        CompaniesList = _companiesManagement.GetCompanies(SecurityContext),
                                        Province = province,
                                        ProvincesList = _locationsManagement.GetAllProvinces(),
                                        Canton = canton,
                                        CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId),
                                        District = userInformation.District,
                                        DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId),
                                    };
            return View(editViewModel);
        }

        //
        // POST: /Users/Save/{editeditFormModel}
        [HttpPost]
        public ActionResult Save(EditFormModel editFormModel)
        {
            var editViewModel = ModelViewFromForm(editFormModel);
            if (ModelState.IsValid)
            {
                //provisional para salir del paso y no tener que hacer el manejo de roles y id types
                //_rolesManagement.Save(GetRolesList(SecurityContext));
                //_rolesManagement.Save(GetIdentificationTypesList());
                _usersManagement.Save(editFormModel, SecurityContext.User.Id);
            }

            var canton = _locationsManagement.GetCantonByDistrict(editFormModel.District.DistrictId);
            var province = _locationsManagement.GetProvinceByCanton(canton.CantonId);
            editViewModel.ProvincesList = _locationsManagement.GetAllProvinces();
            editViewModel.CantonsList = _locationsManagement.GetCantonsByProvince(province.ProvinceId);
            editViewModel.DistrictsList = _locationsManagement.GetDistrictsByCanton(canton.CantonId);

            editViewModel.RolesList = GetRolesList(SecurityContext);
            editViewModel.CompaniesList = _companiesManagement.GetCompanies(SecurityContext);
            editViewModel.IdentificationTypesList = GetIdentificationTypesList();

            return View("Edit", editViewModel);
        }

        #endregion

        #region Private Members

        private EditViewModel ModelViewFromForm(EditFormModel editFormModel)
        {
            return new EditViewModel
                       {
                           UserId = editFormModel.UserId,
                           IdentificationNumber = editFormModel.IdentificationNumber,
                           IdentificationType = editFormModel.IdentificationType,
                           FirstName = editFormModel.FirstName,
                           LastName1 = editFormModel.LastName1,
                           LastName2 = editFormModel.LastName2,
                           GeneratedCode =
                               GenerateUserCode(editFormModel.LastName1, editFormModel.LastName2,
                                                editFormModel.IdentificationNumber),
                           Dob = editFormModel.Dob,
                           Address1 = editFormModel.Address1,
                           Address2 = editFormModel.Address2,
                           PhoneNumber = editFormModel.PhoneNumber,
                           Cellphone = editFormModel.Cellphone,
                           Email = editFormModel.Email,
                           Enabled = editFormModel.Enabled,
                           UserRol = editFormModel.UserRol,
                           //TODO: hay q hacer la parte de las companies
                           //Company = new Company { CompanyId = editFormModel.CompanyId, UpdatedAt = DateTime.Now, CreatetedAt = DateTime.Now },//_companiesManagement.GetCompany(editFormModel.CompanyId), //
                           Company = editFormModel.Company,
                           Province = editFormModel.Province,
                           Canton = editFormModel.Canton,
                           District = editFormModel.District,
                       };
        }

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