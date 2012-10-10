using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class CompaniesAccess
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CompaniesAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Company> GetCompanies()
        {
            var companies = _databaseModel.Companies.ToList();
            return companies;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}