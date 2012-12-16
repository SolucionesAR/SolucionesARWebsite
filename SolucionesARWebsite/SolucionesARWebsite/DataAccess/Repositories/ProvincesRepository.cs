using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Repositories
{
    public class ProvincesRepository : IProvincesRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public ProvincesRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        public void AddProvince(Province province)
        {
            _databaseModel.Provinces.Add(province);
            _databaseModel.SaveChanges();
        }

        public void EditProvince(Province province)
        {
            _databaseModel.Entry(province).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<Province> GetAllProvinces()
        {
            var provinces = _databaseModel.Provinces.ToList();
            return provinces;
        }

        public List<Province> GetProvinces()
        {
            var provinces = _databaseModel.Provinces.ToList();
            return provinces;
        }

        public Province GetProvince(int provinceId)
        {
            var provinces = _databaseModel.Provinces.First(d => d.ProvinceId.Equals(provinceId));
            return provinces;
        }

        public Province GetProvinceByCanton(int cantonId)
        {
            var canton = _databaseModel.Cantons.FirstOrDefault(c => c.CantonId.Equals(cantonId));
            if (canton != null)
            {
                var province = canton.Province;
                return province;
            }
            return null;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}