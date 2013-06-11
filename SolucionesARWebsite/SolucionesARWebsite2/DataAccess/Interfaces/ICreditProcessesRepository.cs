using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface ICreditProcessesRepository
    {
        int AddCreditProcess(CreditProcess creditProcess);

        void UpdateCreditProcess(CreditProcess creditProcess);

        List<CreditProcess> GetAllCreditProcesses();

        List<CreditProcess> GetCreditProcesses();

        CreditProcess GetCreditProcess(int CreditProcessId);

        List<CreditProcessXCompany> GetFlowsPerCreditProcess(int creditProcessId);

        void AddCreditProcessFlow(CreditProcessXCompany creditProcessFlow);

        void UpdateCreditProcessFlow(CreditProcessXCompany creditProcessFlow);

        void DeleteCreditProcessFlow(CreditProcessXCompany creditProcessFlow);
    }
}
