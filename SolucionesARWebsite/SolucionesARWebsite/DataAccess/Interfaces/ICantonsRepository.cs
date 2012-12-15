using System.Collections.Generic;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Interfaces
{
    public interface ICantonsRepository
    {
        void AddCanton(Canton canton);

        void EditCanton(Canton canton);

        List<Canton> GetAllCantons();

        List<Canton> GetCantons();

        Canton GetCanton(int cantonId);
    }
}
