using System;
using System.Collections.Generic;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.DataObjects;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.ViewModels.IdentificationTypes;

namespace SolucionesARWebsite2.Business.Management
{
    public class IdentificationTypesManagement
    {
        #region Constants
        #endregion

        #region Properties
        #endregion

        #region Private Members

        private readonly IIdentificationTypesRepository _identificationTypesRepository;

        #endregion

        #region Constructors

        public IdentificationTypesManagement(IIdentificationTypesRepository identificationTypesRepository)
        {
            _identificationTypesRepository = identificationTypesRepository;
        }

        #endregion

        #region Public Methods

        public IdentificationType GetIdentificationType(int identificationTypeId)
        {
            return _identificationTypesRepository.GetIdentificationType(identificationTypeId);
        }

        public List<IdentificationType> GetIdentificationTypes()
        {
            return _identificationTypesRepository.GetIdentificationTypes();
        }

        public List<IdentificationType> GetIdentificationTypes(SecurityContext securityContext)
        {
            var companiesList = new List<IdentificationType>();

            switch ((UserRoles)securityContext.User.RoleId)
            {
                case UserRoles.Customer:
                case UserRoles.Manager:
                case UserRoles.Salesman:
                    break;
                case UserRoles.SuperUser:
                case UserRoles.Administrator:
                    companiesList = _identificationTypesRepository.GetAllIdentificationTypes();
                    break;
            }

            return companiesList;
        }
        
        public void Save(EditViewModel editViewModel)
        {
            var identificationType = Map(editViewModel);

            if (editViewModel.IdentificationTypeId.Equals(0))
            {
                AddIdentificationType(identificationType);
            }
            else
            {
                EditIdentificationType(identificationType);
            }
        }

        #endregion

        #region Private Methods

        private void AddIdentificationType(IdentificationType identificationType)
        {
            _identificationTypesRepository.AddIdentificationType(identificationType);
        }

        private void EditIdentificationType(IdentificationType identificationType)
        {
            _identificationTypesRepository.EditIdentificationType(identificationType);
        }

        private static IdentificationType Map(EditViewModel editViewMode)
        {
            return new IdentificationType
                       {
                           IdentificationTypeId = editViewMode.IdentificationTypeId,
                           IdentificationDescription = editViewMode.Description,
                       };
        }

        #endregion
    }
}