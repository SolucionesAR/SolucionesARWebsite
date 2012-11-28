using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Repositories
{
    public class DistrictsRepository : IDistrictsRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public DistrictsRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        public void AddDistrict(District district)
        {
            _databaseModel.Districts.Add(district);
            _databaseModel.SaveChanges();
        }

        public void EditDistrict(District district)
        {
            _databaseModel.Entry(district).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<District> GetAllDistricts()
        {
            var districts = _databaseModel.Districts.ToList();
            return districts;
        }

        public List<District> GetDistricts()
        {
            var districts = _databaseModel.Districts.ToList();
            return districts;
        }

        public District GetDistrict(int districtId)
        {
            var districts = _databaseModel.Districts.First(d => d.DistrictId.Equals(districtId));
            return districts;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}