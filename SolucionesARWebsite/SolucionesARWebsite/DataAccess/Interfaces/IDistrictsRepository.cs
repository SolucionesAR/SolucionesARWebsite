using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IDistrictsRepository
    {
        void AddDistrict(District district);

        void EditDistrict(District district);

        List<District> GetAllDistricts();

        List<District> GetDistricts();

        District GetDistrict(int districtId);
    }
}
