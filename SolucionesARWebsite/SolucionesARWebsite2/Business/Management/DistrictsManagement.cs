using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Districts;

namespace SolucionesARWebsite2.Business.Management
{
    public class DistrictsManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IDistrictsRepository _districtsRepository;

        #endregion

        #region Constructors

        public DistrictsManagement(IDistrictsRepository districtsRepository)
        {
            _districtsRepository = districtsRepository;
        }

        #endregion

        #region Public Methods

        public District GetDistrict(int districtId)
        {
            return _districtsRepository.GetDistrict(districtId);
        }

        public List<District> GetDistricts()
        {
            return _districtsRepository.GetDistricts();
        }

        public List<District> GetDistricts(int cantonId)
        {
            return _districtsRepository.GetDistricts(cantonId);
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var company = Map(editViewModel);

            if (editViewModel.DistrictId.Equals(0))
            {
                AddDistrict(company);
            }
            else
            {
                EditDistrict(company);
            }
        }

        #endregion

        #region Private Methods

        private void AddDistrict(District district)
        {
            _districtsRepository.AddDistrict(district);
        }

        private void EditDistrict(District district)
        {
            _districtsRepository.EditDistrict(district);
        }

        private static District Map(EditViewModel editViewMode)
        {
            return new District
                       {
                           DistrictId = editViewMode.DistrictId,
                           Name = editViewMode.DistrictName.ToUpper(),
                           CantonId = editViewMode.CantonId,
                       };
        }

        #endregion
    }
}