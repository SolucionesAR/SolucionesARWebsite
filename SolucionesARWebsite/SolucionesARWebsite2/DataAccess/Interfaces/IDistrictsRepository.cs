using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface IDistrictsRepository
    {
        void AddDistrict(District district);

        void EditDistrict(District district);

        List<District> GetAllDistricts();

        List<District> GetDistricts();

        List<District> GetDistricts(int cantonId);

        District GetDistrict(int districtId);
    }
}
