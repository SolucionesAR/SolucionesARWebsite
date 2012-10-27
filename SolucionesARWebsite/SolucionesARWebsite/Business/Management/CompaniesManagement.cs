using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Enumerations;

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

        public List<Company> GetCompanies(int userId, int roleId)
        {
            var companiesList = new List<Company>();

            switch ((UserRole)roleId)
            {
                case UserRole.Customer:
                    companiesList = new List<Company>();
                    break;
                case UserRole.Manager:
                case UserRole.Salesman:
                    companiesList = new List<Company>();
                    break;
                case UserRole.SuperUser:
                case UserRole.Administrator:
                    companiesList = new List<Company>();
                    break;
            }

            return companiesList;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}