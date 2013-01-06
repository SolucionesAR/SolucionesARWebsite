using System.Collections.Generic;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Interfaces
{
    public interface IStoresRepository
    {
        void AddStore(Store store);

        void EditStore(Store store);

        List<Store> GetStores();

        Store GetStore(string storeName);

        Store GetStore(int storeId);

        void SaveStore(Store store);
    }
}