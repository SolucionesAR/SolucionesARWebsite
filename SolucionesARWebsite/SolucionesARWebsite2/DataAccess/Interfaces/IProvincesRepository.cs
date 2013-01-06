using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
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
