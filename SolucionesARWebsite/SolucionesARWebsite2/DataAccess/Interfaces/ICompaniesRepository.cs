using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ICompaniesRepository
    {
        void AddCompany(Company company);

        void EditCompany(Company company);

        List<Company> GetAllCompanies();

        List<Company> GetCompanies();

        List<Company> GetOrderedCompaniesList();

        Company GetCompany(int companyId);

        Company GetCompany(Store store);
    }
}
