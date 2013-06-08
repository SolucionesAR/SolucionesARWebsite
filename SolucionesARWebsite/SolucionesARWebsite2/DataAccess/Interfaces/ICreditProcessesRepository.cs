using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ICreditProcessesRepository
    {
        void AddCreditProcess(CreditProcess CreditProcess);

        void EditCreditProcess(CreditProcess CreditProcess);

        List<CreditProcess> GetAllCreditProcesses();

        List<CreditProcess> GetCreditProcesses();

        CreditProcess GetCreditProcess(int CreditProcessId);

        List<CreditProcessXCompany> GetFlowsPerCreditProcess(int creditProcessId);
    }
}
