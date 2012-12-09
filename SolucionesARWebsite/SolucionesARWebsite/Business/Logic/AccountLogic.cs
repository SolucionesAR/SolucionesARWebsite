using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.ViewModels.Account;

namespace SolucionesARWebsite.Business.Logic
{
    public class AccountLogic
    {
        #region Private Members

        private readonly IUsersRepository _usersRepository;

        #endregion

        #region Constructors

        public AccountLogic(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        #endregion

        #region Public Methods

        public bool IsValidLogin(LoginViewModel loginFormModel)
        {
            var userInformation = _usersRepository.GetUserByGeneratedCode(loginFormModel.Username);
            
            //TODO: add logic to verify the crypted password
            //userInformation.Password, userInformation.PasswordKey
            return userInformation != null;
        }

        #endregion

        #region Private Methods

        #endregion
    }
}