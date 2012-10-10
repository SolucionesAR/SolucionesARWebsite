using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

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

        #endregion

        #region Private Methods
        #endregion
    }
}