using System;
using SolucionesARWebsite.Models;
using SolucionesARWebsite.ModelsWebsite.Forms.Users;

namespace SolucionesARWebsite.Business.Logic
{
    public class FormMapper
    {
        #region Constants
        #endregion

        #region Properties
        #endregion


        #region Public Methods

        public User Map(EditFormModel editFormMode)
        {
            return new User
                       {
                           Address1 = editFormMode.Address1,
                           Address2 = editFormMode.Address2,
                           //tenemos que eliminar los guiones
                           CedNumber = Convert.ToInt32(editFormMode.CedNumber),
                           //tenemos que eliminar los guiones
                           Cellphone = editFormMode.CedNumber,
                           Company = new Company {CompanyId = editFormMode.CompanyId},
                           Dob = editFormMode.Dob,
                           Email = editFormMode.Email,
                           Enabled = editFormMode.Enabled,
                           FName = editFormMode.FirstName,
                           LName1 = editFormMode.LastName1,
                           LName2 = editFormMode.LastName2,
                           UserReferenceId = editFormMode.ParentUser,
                           RolId = editFormMode.RolId,
                           //tenemos que eliminar los guiones
                           PhoneNumber = editFormMode.PhoneNumber,
                       };
        }

        #endregion

        #region Private Methods

        #endregion
    }
}