using System;
using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.ViewModels.Districts;

namespace SolucionesARWebsite.Business.Management
{
    public class DistrictsManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IDistrictsRepository _districtsRepository;

        #endregion

        #region Constructors

        public DistrictsManagement(IDistrictsRepository districtsRepository)
        {
            _districtsRepository = districtsRepository;
        }

        #endregion

        #region Public Methods

        public District GetDistrict(int districtId)
        {
            return _districtsRepository.GetDistrict(districtId);
        }

        public List<District> GetDistricts()
        {
            return _districtsRepository.GetDistricts();
        }

        public List<District> GetDistricts(SecurityContext securityContext)
        {
            var companiesList = new List<District>();

            switch ((UserRole) securityContext.User.RoleId)
            {
                case UserRole.Customer:
                case UserRole.Manager:
                case UserRole.Salesman:
                    companiesList = new List<District>
                                        {
                                            new District
                                                {
                                                    DistrictId = securityContext.User.CompanyId,
                                                    Name = securityContext.User.CompanyName
                                                }
                                        };
                    break;
                case UserRole.SuperUser:
                case UserRole.Administrator:
                    companiesList = _districtsRepository.GetAllDistricts();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var company = Map(editViewModel);

            if (editViewModel.DistrictId.Equals(0))
            {
                AddCompany(company);
            }
            EditCompany(company);
        }

        #endregion

        #region Private Methods

        private void AddCompany(District district)
        {
            _districtsRepository.AddDistrict(district);
        }

        private void EditCompany(District district)
        {
            _districtsRepository.EditDistrict(district);
        }

        private static District Map(EditViewModel editViewMode)
        {
            return new District
                       {
                           DistrictId = editViewMode.DistrictId,
                           Name = editViewMode.DistrictName,
                           CantonId = editViewMode.CantonId,
                       };
        }

        #endregion
    }
}