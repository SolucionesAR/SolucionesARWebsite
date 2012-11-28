using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface ICantonsRepository
    {
        void AddCanton(Canton district);

        void EditCanton(Canton district);

        List<Canton> GetAllCantons();

        List<Canton> GetCantons();

        Canton GetCanton(int districtId);
    }
}
