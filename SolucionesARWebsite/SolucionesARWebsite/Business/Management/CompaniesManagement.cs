using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.DataObjects;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.Enumerations;

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

        #endregion

        #region Private Methods

        #endregion
    }
}