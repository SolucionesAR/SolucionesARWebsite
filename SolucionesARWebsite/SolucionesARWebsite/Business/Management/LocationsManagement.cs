using System.Collections.Generic;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Management
{
    public class LocationsManagement
    {
        #region Constants

        #endregion

        #region Properties

        #endregion

        #region Private Members

        private readonly LocationsAccess _locationsAccess;

        #endregion

        #region Constructors

        public LocationsManagement()
        {
            _locationsAccess = new LocationsAccess();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Province> GetAllProvinces()
        {
            var provinces = _locationsAccess.GetAllProvinces();
            return provinces;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Province GetProvince(int provinceId)
        {
            var province = _locationsAccess.GetProvince(provinceId);
            return province;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Province GetProvinceByCanton(int cantonId)
        {
            var province = _locationsAccess.GetProvinceByCanton(cantonId);
            return province;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Canton> GetAllCantons()
        {
            var cantons = _locationsAccess.GetAllCantons();
            return cantons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Canton> GetCantonsByProvince(int provinceId)
        {
            var cantons = _locationsAccess.GetCantonsByProvince(provinceId);
            return cantons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantonId"></param>
        /// <returns></returns>
        public Canton GetCanton(int cantonId)
        {
            var canton = _locationsAccess.GetCanton(cantonId);
            return canton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public Canton GetCantonByDistrict(int districtId)
        {
            var canton = _locationsAccess.GetCantonByDistrict(districtId);
            return canton;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<District> GetAllDistricts()
        {
            var districts = _locationsAccess.GetAllDistricts();
            return districts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<District> GetDistrictsByCanton(int cantonId)
        {
            var districts = _locationsAccess.GetDistrictsByCanton(cantonId);
            return districts;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        public District GetDistrict(int districtId)
        {
            var districts = _locationsAccess.GetDistrict(districtId);
            return districts;
        }
        #endregion

        #region Private Methods

        #endregion

    }
}