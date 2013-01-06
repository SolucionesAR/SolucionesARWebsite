using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface IIdentificationTypesRepository
    {
        void AddIdentificationType(IdentificationType identificationType);

        void EditIdentificationType(IdentificationType identificationType);

        List<IdentificationType> GetAllIdentificationTypes();

        List<IdentificationType> GetIdentificationTypes();

        IdentificationType GetIdentificationType(int identificationTypeId);
    }
}
