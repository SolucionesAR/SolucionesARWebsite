using System.Collections.Generic;
using System.Data;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Company> GetAllCompanies()
        {
            var companies = _databaseModel.Companies.ToList();
            return companies;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public Company GetCompany(Store store)
        {
            var companies = _databaseModel.Companies.
                Where(c => c.CompanyId == store.CompanyId);
            return companies.First();
        }

        public Company GetCompany(int companyId)
        {
            return _databaseModel.Companies.First(c => c.CompanyId == companyId);

        }

        public void EditCompany(Company company)
        {
            _databaseModel.Entry(company).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public void AddCompany(Company company)
        {
            _databaseModel.Companies.Add(company);
            _databaseModel.SaveChanges();
        }

        #endregion

        #region Private Methods
        #endregion

        
    }
}