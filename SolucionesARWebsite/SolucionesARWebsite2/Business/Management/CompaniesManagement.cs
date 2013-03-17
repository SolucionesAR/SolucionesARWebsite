using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.DataObjects;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.ViewModels.Companies;

namespace SolucionesARWebsite2.Business.Management
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

        public List<Company> GetOrderedCompaniesList()
        {
            return _companiesRepository.GetOrderedCompaniesList();
        }

        public List<Company> GetCompaniesList()
        {
            return _companiesRepository.GetCompanies();
        }

        public List<Company> GetCompaniesList(SecurityContext securityContext)
        {
            var companiesList = new List<Company>();

            switch ((UserRoles)securityContext.User.RoleId)
            {
                case UserRoles.Customer:
                case UserRoles.Manager:
                case UserRoles.Salesman:
                    companiesList = new List<Company>
                                        {
                                            new Company
                                                {
                                                    CompanyId = securityContext.User.CompanyId,
                                                    CompanyName = securityContext.User.CompanyName
                                                }
                                        };
                    break;
                case UserRoles.SuperUser:
                case UserRoles.Administrator:
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
            else
            {
                EditCompany(company);
            }
        }

        #endregion

        #region Private Methods

        private void AddCompany(Company company)
        {
            company.CreatetedAt = DateTime.UtcNow;
            company.UpdatedAt = DateTime.UtcNow;
            _companiesRepository.AddCompany(company);
        }

        private void EditCompany(Company company)
        {
            //TODO: Check porqué esta dando problemas
            company.CreatetedAt = DateTime.UtcNow;

            company.UpdatedAt = DateTime.UtcNow;
            _companiesRepository.EditCompany(company);
        }

        private static Company Map(EditViewModel editViewMode)
        {
            return new Company
                       {
                           CashBackPercentaje = editViewMode.CashBackPercentaje,
                           CompanyId = editViewMode.CompanyId,
                           CompanyName = editViewMode.CompanyName.ToUpper(),
                           CompanyNickName = editViewMode.CompanyNickname.ToUpper(),
                           CorporateId = editViewMode.CorporateId.ToUpper(),
                           Enabled = editViewMode.Enabled,
                       };
        }

        #endregion
    }
}