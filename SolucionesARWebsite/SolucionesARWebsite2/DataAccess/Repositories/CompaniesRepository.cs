using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class CompaniesRepository : ICompaniesRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CompaniesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        public void AddCompany(Company company)
        {
            _databaseModel.Companies.Add(company);
            _databaseModel.SaveChanges();
        }

        public void EditCompany(Company company)
        {
            _databaseModel.Entry(company).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }

        public List<Company> GetAllCompanies()
        {
            var companies = _databaseModel.Companies.ToList();
            return companies;
        }

        public List<Company> GetOrderedCompaniesList()
        {
            var companies = _databaseModel.Companies.OrderBy(c => c.CompanyName).ToList();
            return companies;
        }

        public List<Company> GetCompanies()
        {
            var companies = _databaseModel.Companies.ToList();
            return companies;
        }

        public Company GetCompany(int companyId)
        {
            var companies = _databaseModel.Companies.First(c => c.CompanyId.Equals(companyId));
            return companies;
        }

        public Company GetCompany(Store store)
        {
            var companies = _databaseModel.Companies.
                Where(c => c.CompanyId == store.CompanyId);
            return companies.First();
        }

        #endregion

        #region Private Methods
        #endregion
    }
}