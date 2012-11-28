using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.ViewModels.Cantons;

namespace SolucionesARWebsite.Business.Management
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

        public List<Canton> GetCantons(SecurityContext securityContext)
        {
            var companiesList = new List<Canton>();

            switch ((UserRole) securityContext.User.RoleId)
            {
                case UserRole.Customer:
                case UserRole.Manager:
                case UserRole.Salesman:
                    companiesList = new List<Canton>
                                        {
                                            new Canton
                                                {
                                                    CantonId = securityContext.User.CompanyId,
                                                    Name = securityContext.User.CompanyName
                                                }
                                        };
                    break;
                case UserRole.SuperUser:
                case UserRole.Administrator:
                    companiesList = _cantonsRepository.GetAllCantons();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var company = Map(editViewModel);

            if (editViewModel.CantonId.Equals(0))
            {
                AddCompany(company);
            }
            EditCompany(company);
        }

        #endregion

        #region Private Methods

        private void AddCompany(Canton canton)
        {
            _cantonsRepository.AddCanton(canton);
        }

        private void EditCompany(Canton canton)
        {
            _cantonsRepository.EditCanton(canton);
        }

        private static Canton Map(EditViewModel editViewMode)
        {
            return new Canton
                       {
                           CantonId = editViewMode.CantonId,
                           Name = editViewMode.CantonName,
                           ProvinceId = editViewMode.ProvinceId,
                       };
        }

        #endregion
    }
}