using System.Collections.Generic;
using System.Data;
using System.Linq;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.DataAccess.Repositories
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

        public Canton GetCanton(int cantonId)
        {
            var cantons = _databaseModel.Cantons.First(d => d.CantonId.Equals(cantonId));
            return cantons;
        }

        #endregion

        #region Private Methods
        #endregion
    }
}