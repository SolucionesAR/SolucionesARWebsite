using System;
using System.Collections.Generic;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.ViewModels.Companies;

namespace SolucionesARWebsite.Business.Management
{
    public class CompaniesManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly ICompaniesRepository _companiesRepository;

        #endregion

        #region Constructors

        public CompaniesManagement(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        #endregion

        #region Public Methods

        public Company GetCompany(int companyId)
        {
            return _companiesRepository.GetCompany(companyId);
        }

        public List<Company> GetCompanies()
        {
            return _companiesRepository.GetCompanies();
        }

        public List<Company> GetCompanies(SecurityContext securityContext)
        {
            var companiesList = new List<Company>();

            switch ((UserRole) securityContext.User.RoleId)
            {
                case UserRole.Customer:
                case UserRole.Manager:
                case UserRole.Salesman:
                    companiesList = new List<Company>
                                        {
                                            new Company
                                                {
                                                    CompanyId = securityContext.User.CompanyId,
                                                    CompanyName = securityContext.User.CompanyName
                                                }
                                        };
                    break;
                case UserRole.SuperUser:
                case UserRole.Administrator:
                    companiesList = _companiesRepository.GetAllCompanies();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var company = Map(editViewModel);

            if (editViewModel.CompanyId == 0)
            {
                AddCompany(company);
            }
            EditCompany(company);
        }

        #endregion

        #region Private Methods

        private void AddCompany(Company company)
        {
            company.CreatetedAt = DateTime.Now;
            company.UpdatedAt = DateTime.Now;
            _companiesRepository.AddCompany(company);
        }

        private void EditCompany(Company company)
        {
            company.UpdatedAt = DateTime.Now;
            _companiesRepository.EditCompany(company);
        }

        private Company Map(EditViewModel editViewMode)
        {
            return new Company
                       {
                           CashBackPercentaje = editViewMode.CashBackPercentaje,
                           CompanyId = editViewMode.CompanyId,
                           CompanyName = editViewMode.CompanyName,
                           CompanyNickName = editViewMode.CompanyNickname,
                           CorporateId = editViewMode.CorporateId,
                           Enabled = editViewMode.Enabled,
                       };
        }

        #endregion
    }
}