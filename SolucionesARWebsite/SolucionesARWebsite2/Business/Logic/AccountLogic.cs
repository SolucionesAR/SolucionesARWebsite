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
            int identificationNumber;
            int.TryParse(loginFormModel.Username, out identificationNumber);

            var userInformation = _usersRepository.GetUserByIdentificationNumber(identificationNumber);

            return BCrypt.Net.BCrypt.Verify(loginFormModel.Password, userInformation.Password);
        }


        public bool CreateDefaultConfiguration(LoginViewModel loginFormModel)
        {
            if (loginFormModel.Username.ToLower().Equals(Constants.SolucionesArUserCreator.ToStringValue().ToLower()) &&
                loginFormModel.Password.Equals(Constants.SolucionesArPassword.ToStringValue()))
            {
                _beginningConfig.CreateDefaultConfiguration();
                loginFormModel.Username = "1";
            }

            return IsValidLogin(loginFormModel);
        }
        #endregion

        #region Private Methods

        #endregion
    }
}