using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ICreditStatusRepository
    {
        void AddCreditStatus(CreditStatus creditStatus);

        void EditCreditStatus(CreditStatus creditStatus);

        List<CreditStatus> GetAllCreditStatus();

        List<CreditStatus> GetCreditStatus();

        CreditStatus GetCreditStatus(int creditStatusId);
    }
}
