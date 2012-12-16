using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface IProvincesRepository
    {
        void AddProvince(Province province);

        void EditProvince(Province province);

        List<Province> GetAllProvinces();

        List<Province> GetProvinces();

        Province GetProvince(int provinceId);

        Province GetProvinceByCanton(int cantonId);
    }
}
