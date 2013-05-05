﻿using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.DataObjects;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.ViewModels.Cantons;

namespace SolucionesARWebsite2.Business.Management
{
    public class CantonsManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICantonsRepository _cantonsRepository;

        #endregion

        #region Constructors

        public CantonsManagement(ICantonsRepository cantonsRepository)
        {
            _cantonsRepository = cantonsRepository;
        }

        #endregion

        #region Public Methods

        public Canton GetCanton(int cantonId)
        {
            return _cantonsRepository.GetCanton(cantonId);
        }

        public List<Canton> GetCantons()
        {
            return _cantonsRepository.GetCantons();
        }

        public List<Canton> GetCantons(int provinceId)
        {
            return _cantonsRepository.GetCantons(provinceId);
        }

        public List<Canton> GetCantons(SecurityContext securityContext)
        {
            var companiesList = new List<Canton>();

            switch ((UserRoles)securityContext.User.RoleId)
            {
                case UserRoles.Customer:
                case UserRoles.Manager:
                case UserRoles.Salesman:
                    companiesList = new List<Canton>
                                        {
                                            new Canton
                                                {
                                                    CantonId = securityContext.User.CompanyId,
                                                    Name = securityContext.User.CompanyName
                                                }
                                        };
                    break;
                case UserRoles.SuperUser:
                case UserRoles.Administrator:
                    companiesList = _cantonsRepository.GetAllCantons();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var canton = Map(editViewModel);

            if (editViewModel.CantonId.Equals(0))
            {
                AddCanton(canton);
            }
            else
            {
                EditCanton(canton);
            }
        }

        public Canton GetCantonByDistrict(int districtId)
        {
            var canton = _cantonsRepository.GetCantonByDistrict(districtId);
            return canton;
        }
        #endregion

        #region Private Methods

        private void AddCanton(Canton canton)
        {
            _cantonsRepository.AddCanton(canton);
        }

        private void EditCanton(Canton canton)
        {
            _cantonsRepository.EditCanton(canton);
        }

        private static Canton Map(EditViewModel editViewMode)
        {
            return new Canton
                       {
                           CantonId = editViewMode.CantonId,
                           Name = editViewMode.CantonName.ToUpper(),
                           ProvinceId = editViewMode.ProvinceId,
                       };
        }

        #endregion
    }
}