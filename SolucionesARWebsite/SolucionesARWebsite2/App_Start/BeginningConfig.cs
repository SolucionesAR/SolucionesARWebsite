using System;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Utils;

namespace SolucionesARWebsite2.App_Start
{
    public class BeginningConfig
    {
        private readonly IProvincesRepository _provincesRepository;
        private readonly ICantonsRepository _cantonsRepository;
        private readonly IDistrictsRepository _districtsRepository;
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IStoresRepository _storesRepository;
        private readonly IRelationshipTypesRepository _relationshipTypesRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IIdentificationTypesRepository _identificationTypesRepository;
        private readonly IUsersRepository _usersRepository;

        public BeginningConfig(IProvincesRepository provincesRepository, ICantonsRepository cantonsRepository, IDistrictsRepository districtsRepository, 
            ICompaniesRepository companiesRepository, IStoresRepository storesRepository, IRelationshipTypesRepository relationshipTypesRepository, 
            IRolesRepository rolesRepository, IIdentificationTypesRepository identificationTypesRepository, IUsersRepository usersRepository)
        {
            _provincesRepository = provincesRepository;
            _cantonsRepository = cantonsRepository;
            _districtsRepository = districtsRepository;
            _companiesRepository = companiesRepository;
            _storesRepository = storesRepository;
            _relationshipTypesRepository = relationshipTypesRepository;
            _rolesRepository = rolesRepository;
            _identificationTypesRepository = identificationTypesRepository;
            _usersRepository = usersRepository;
        }

        public void CreateDefaultLocation()
        {
            _provincesRepository.AddProvince(new Province
                                                 {
                                                     Name = "San José",
                                                 });

            _cantonsRepository.AddCanton(new Canton
                                             {
                                                 Name = "San José",
                                                 ProvinceId = 1,
                                             });

            _districtsRepository.AddDistrict(new District
                                                 {
                                                     CantonId = 1,
                                                     Name = "Carmen",
                                                 });
        }

        public void CreateDefaultCompany()
        {
            _companiesRepository.AddCompany(new Company
                                                {
                                                    CashBackPercentaje = 0,
                                                    CompanyName = "SolucionesAR",
                                                    CompanyNickName = "sar",
                                                    CorporateId = string.Empty,
                                                    CreatetedAt = DateTime.UtcNow,
                                                    Enabled = true,
                                                    UpdatedAt = DateTime.UtcNow,
                                                });

            _storesRepository.AddStore(new Store
                                           {
                                               CompanyId = 1,
                                               CreatetedAt = DateTime.UtcNow,
                                               DistrictId = 1,
                                               FaxNumber = string.Empty,
                                               PhoneNumber1 = string.Empty,
                                               PhoneNumber2 = string.Empty,
                                               StoreName = "SolucionesAR Central",
                                               UpdatedAt = DateTime.UtcNow,
                                           });
        }

        public void CreateDefaultIdentificationTypes()
        {
            _identificationTypesRepository.AddIdentificationType(new IdentificationType
                                                                     {
                                                                         IdentificationDescription =
                                                                             IdentificationTypes.CedNumber.ToStringValue
                                                                             ()
                                                                     });

            _identificationTypesRepository.AddIdentificationType(new IdentificationType
                                                                     {
                                                                         IdentificationDescription =
                                                                             IdentificationTypes.ResidenceCedNumber.
                                                                             ToStringValue()
                                                                     });

            _identificationTypesRepository.AddIdentificationType(new IdentificationType
                                                                     {
                                                                         IdentificationDescription =
                                                                             IdentificationTypes.Passport.ToStringValue()
                                                                     });

            _identificationTypesRepository.AddIdentificationType(new IdentificationType
                                                                     {
                                                                         IdentificationDescription =
                                                                             IdentificationTypes.Other.ToStringValue()
                                                                     });
        }
        
        private void CreateDefaultRelationshipTypes()
        {
            _relationshipTypesRepository.AddRelationshipType(new RelationshipType
                                                                 {
                                                                     CreatetedAt = DateTime.UtcNow,
                                                                     Description =
                                                                         RelationshipTypes.Amateur.ToStringValue(),
                                                                     UpdatedAt = DateTime.UtcNow
                                                                 });

            _relationshipTypesRepository.AddRelationshipType(new RelationshipType
                                                                 {
                                                                     CreatetedAt = DateTime.UtcNow,
                                                                     Description =
                                                                         RelationshipTypes.Junior.ToStringValue(),
                                                                     UpdatedAt = DateTime.UtcNow
                                                                 });

            _relationshipTypesRepository.AddRelationshipType(new RelationshipType
                                                                 {
                                                                     CreatetedAt = DateTime.UtcNow,
                                                                     Description =
                                                                         RelationshipTypes.Senior.ToStringValue(),
                                                                     UpdatedAt = DateTime.UtcNow
                                                                 });

            _relationshipTypesRepository.AddRelationshipType(new RelationshipType
                                                                 {
                                                                     CreatetedAt = DateTime.UtcNow,
                                                                     Description =
                                                                         RelationshipTypes.Master.ToStringValue(),
                                                                     UpdatedAt = DateTime.UtcNow
                                                                 });
        }
        
        public void CreateDefaultRoles()
        {
            _rolesRepository.AddRol(new Rol
                                        {
                                            CreatedAt = DateTime.UtcNow,
                                            Name = UserRoles.Customer.ToStringValue(),
                                            UpdatedAt = DateTime.UtcNow,
                                        });

            _rolesRepository.AddRol(new Rol
                                        {
                                            CreatedAt = DateTime.UtcNow,
                                            Name = UserRoles.Salesman.ToStringValue(),
                                            UpdatedAt = DateTime.UtcNow,
                                        });

            _rolesRepository.AddRol(new Rol
                                        {
                                            CreatedAt = DateTime.UtcNow,
                                            Name = UserRoles.Manager.ToStringValue(),
                                            UpdatedAt = DateTime.UtcNow,
                                        });

            _rolesRepository.AddRol(new Rol
                                        {
                                            CreatedAt = DateTime.UtcNow,
                                            Name = UserRoles.Administrator.ToStringValue(),
                                            UpdatedAt = DateTime.UtcNow,
                                        });

            _rolesRepository.AddRol(new Rol
                                        {
                                            CreatedAt = DateTime.UtcNow,
                                            Name = UserRoles.SuperUser.ToStringValue(),
                                            UpdatedAt = DateTime.UtcNow,
                                        });
        }

        public void CreateDefaultUser()
        {
            _usersRepository.AddUser(new User
                                         {
                                             Address1 = string.Empty,
                                             Address2 = string.Empty,
                                             Cashback = 0,
                                             CedNumber = 0,
                                             Cellphone = string.Empty,
                                             CompanyId = 1,
                                             CreatetedAt = DateTime.UtcNow,
                                             DistrictId = 1,
                                             Dob = DateTime.UtcNow,
                                             Email = string.Empty,
                                             Enabled = true,
                                             FName = "Soluciones",
                                             GeneratedCode = Constants.SolucionesArUser.ToStringValue(),
                                             IdentificationTypeId = 1,
                                             LName1 = "AR",
                                             LName2 = string.Empty,
                                             Nationality = "costarricense",
                                             OtherPhones = string.Empty,
                                             OtherProducts = null,
                                             Password =
                                                 BCrypt.Net.BCrypt.HashPassword(
                                                     Constants.SolucionesArUser.ToStringValue(),
                                                     BCrypt.Net.BCrypt.GenerateSalt((int) Constants.WorkFactor)),
                                             PasswordKey = string.Empty,
                                             PhoneNumber = string.Empty,
                                             Points = 0,
                                             Profision = "Administrador de la Aplicación",
                                             RelationshipTypeId = 1,
                                             RolId = 5,
                                             UpdatedAt = DateTime.UtcNow,
                                             UserId = 0,
                                         });
        }

        public void CreateDefaultConfiguration()
        {
            CreateDefaultLocation();
            CreateDefaultCompany();
            CreateDefaultIdentificationTypes();
            CreateDefaultRelationshipTypes();
            CreateDefaultRoles();
            CreateDefaultUser();
        }
    }
}