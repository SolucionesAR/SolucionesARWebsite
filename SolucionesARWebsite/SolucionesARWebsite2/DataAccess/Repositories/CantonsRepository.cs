﻿using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Models;

namespace SolucionesARWebsite2.DataAccess.Repositories
{
    public class CantonsRepository : ICantonsRepository
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly DbModel _databaseModel;

        #endregion

        #region Contructors

        public CantonsRepository()
        {
            _databaseModel = new DbModel();
        }

        #endregion

        #region Public Methods
        
        public void AddCanton(Canton canton)
        {
            _databaseModel.Cantons.Add(canton);
            _databaseModel.SaveChanges();
        }

        public void EditCanton(Canton canton)
        {
            _databaseModel.Entry(canton).State = EntityState.Modified;
            _databaseModel.SaveChanges();
        }
        
        public List<Canton> GetAllCantons()
        {
            var cantons = _databaseModel.Cantons.ToList();
            return cantons;
        }

        public List<Canton> GetCantons()
        {
            var cantons = _databaseModel.Cantons.ToList();
            return cantons;
        }

        public List<Canton> GetCantons(int provinceId)
        {
            var cantons = _databaseModel.Cantons.Where(c => c.ProvinceId.Equals(provinceId)).ToList();
            return cantons;
        }

        public Canton GetCanton(int cantonId)
        {
            var cantons = _databaseModel.Cantons.First(d => d.CantonId.Equals(cantonId));
            return cantons;
        }

        public Canton GetCantonByDistrict(int districtId)
        {
            var district = _databaseModel.Districts.FirstOrDefault(c => c.DistrictId.Equals(districtId));
            if (district != null)
            {
                var canton = district.Canton;
                return canton;
            }
            return null;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}