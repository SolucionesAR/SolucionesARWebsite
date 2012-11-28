using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface ICompaniesRepository
    {
        void AddCompany(Company company);

        void EditCompany(Company company);

        List<Company> GetAllCompanies();

        List<Company> GetCompanies();

        Company GetCompany(int companyId);

        Company GetCompany(Store store);
    }
}
