using System.Collections.Generic;
using System.Linq;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess
{
    public class LocationsAccess
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public LocationsAccess()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Province> GetAllProvinces()
        {
            var provinces = _databaseModel.Provinces.ToList();
            return provinces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Province GetProvince(int provinceId)
        {
            var province = _databaseModel.Provinces.FirstOrDefault(p => p.ProvinceId.Equals(provinceId));
            return province;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Province GetProvinceByCanton(int cantonId)
        {
            var province = _databaseModel.Cantons.FirstOrDefault(c => c.CantonId.Equals(cantonId)).Province;
            return province;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Canton> GetAllCantons()
        {
            var cantons = _databaseModel.Cantons.ToList();
            return cantons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Canton> GetCantonsByProvince(int provinceId)
        {
            var cantons = _databaseModel.Cantons.Where(c => c.ProvinceId.Equals(provinceId)).ToList();
            return cantons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantonId"></param>
        /// <returns></returns>
        public Canton GetCanton(int cantonId)
        {
            var canton = _databaseModel.Cantons.FirstOrDefault(c => c.CantonId.Equals(cantonId));
            return canton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public Canton GetCantonByDistrict(int districtId)
        {
            var canton = _databaseModel.Districts.FirstOrDefault(c => c.DistrictId.Equals(districtId)).Canton;
            return canton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<District> GetAllDistricts()
        {
            var districts = _databaseModel.Districts.ToList();
            return districts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<District> GetDistrictsByCanton(int cantonId)
        {
            var districts = _databaseModel.Districts.Where(d => d.CantonId.Equals(cantonId)).ToList();
            return districts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public District GetDistrict(int districtId)
        {
            var districts = _databaseModel.Districts.FirstOrDefault(c => c.DistrictId.Equals(districtId));
            return districts;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}