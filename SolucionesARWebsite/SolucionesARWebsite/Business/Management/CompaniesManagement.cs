using System;
using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Enumerations;
using SolucionesARWebsite.ModelsWebsite.Forms.Companies;

namespace SolucionesARWebsite.Business.Management
{
    public class CompaniesManagement
    {
        #region Constants

        #endregion

        #region Properties

        #endregion

        #region Private Members

        private readonly CompaniesAccess _companiesAccess;

        #endregion

        #region Constructors

        public CompaniesManagement()
        {
            _companiesAccess = new CompaniesAccess();
        }

        #endregion

        #region Public Methods

        public List<Company> GetCompanies()
        {
            return _companiesAccess.GetCompanies();
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
                    companiesList = _companiesAccess.GetAllCompanies();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditFormModel editFormModel)
        {
            var company = Map(editFormModel);

            if (editFormModel.CompanyId == 0)
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
            _companiesAccess.AddCompany(company);
        }

        private void EditCompany(Company company)
        {
            company.UpdatedAt = DateTime.Now;
            _companiesAccess.EditCompany(company);
        }

        private Company Map(EditFormModel editFormMode)
        {
            return new Company
                       {
                           CashBackPercentaje = editFormMode.CashBackPercentaje,
                           CompanyId = editFormMode.CompanyId,
                           CompanyName = editFormMode.CompanyName,
                           CompanyNickName = editFormMode.CompanyNickname,
                           CorporateId = editFormMode.CorporateId,
                           Enabled = editFormMode.Enabled,
                       };
        }

        #endregion

        public Company GetCompany(int companyId)
        {

            return _companiesAccess.GetCompany(companyId);
        }
    }
}