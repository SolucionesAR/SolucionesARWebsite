using SolucionesARWebsite2.App_Start;
using SolucionesARWebsite2.DataAccess.Interfaces;
using SolucionesARWebsite2.Enumerations;
using SolucionesARWebsite2.Utils;
using SolucionesARWebsite2.ViewModels.Account;

namespace SolucionesARWebsite2.Business.Logic
{
    public class AccountLogic
    {
        #region Private Members

        private readonly IUsersRepository _usersRepository;
        private readonly BeginningConfig _beginningConfig;

        #endregion

        #region Constructors

        public AccountLogic(IUsersRepository usersRepository, BeginningConfig beginningConfig)
        {
            _usersRepository = usersRepository;
            _beginningConfig = beginningConfig;
        }

        #endregion

        #region Public Methods

        public bool IsValidLogin(LoginViewModel loginFormModel)
        {
            if (loginFormModel.Username.ToLower().Equals(Constants.SolucionesArUserCreator.ToStringValue().ToLower()))
            {
                _beginningConfig.CreateDefaultConfiguration();
            }
            var temp = BCrypt.Net.BCrypt.HashPassword(
                Constants.SolucionesArUser.ToStringValue(),
                BCrypt.Net.BCrypt.GenerateSalt((int) Constants.WorkFactor));
            var userInformation = _usersRepository.GetUserByGeneratedCode(loginFormModel.Username);
            return userInformation != null && BCrypt.Net.BCrypt.Verify(loginFormModel.Password, userInformation.Password);
        }

        #endregion

        #region Private Methods

        #endregion
    }
}