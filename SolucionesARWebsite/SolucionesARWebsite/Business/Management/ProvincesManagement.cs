﻿using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.ViewModels.Provinces;

namespace SolucionesARWebsite.Business.Management
{
    public class ProvincesManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IProvincesRepository _provincesRepository;

        #endregion

        #region Constructors

        public ProvincesManagement(IProvincesRepository provincesRepository)
        {
            _provincesRepository = provincesRepository;
        }

        #endregion

        #region Public Methods

        public Province GetProvince(int provinceId)
        {
            return _provincesRepository.GetProvince(provinceId);
        }

        public List<Province> GetProvinces()
        {
            return _provincesRepository.GetProvinces();
        }

        public List<Province> GetProvinces(SecurityContext securityContext)
        {
            var companiesList = new List<Province>();

            switch ((UserRoles)securityContext.User.RoleId)
            {
                case UserRoles.Customer:
                case UserRoles.Manager:
                case UserRoles.Salesman:
                    companiesList = new List<Province>
                                        {
                                            new Province
                                                {
                                                    ProvinceId = securityContext.User.CompanyId,
                                                    Name = securityContext.User.CompanyName
                                                }
                                        };
                    break;
                case UserRoles.SuperUser:
                case UserRoles.Administrator:
                    companiesList = _provincesRepository.GetAllProvinces();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var company = Map(editViewModel);

            if (editViewModel.ProvinceId.Equals(0))
            {
                AddCompany(company);
            }
            else
            {
                EditCompany(company);
            }
        }

        #endregion

        #region Private Methods

        private void AddCompany(Province province)
        {
            _provincesRepository.AddProvince(province);
        }

        private void EditCompany(Province province)
        {
            _provincesRepository.EditProvince(province);
        }

        private static Province Map(EditViewModel editViewMode)
        {
            return new Province
                       {
                           ProvinceId = editViewMode.ProvinceId,
                           Name = editViewMode.ProvinceName,
                       };
        }

        #endregion
    }
}