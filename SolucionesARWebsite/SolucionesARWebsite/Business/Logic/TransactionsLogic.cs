using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Logic
{
    public class TransactionsLogic
    {
        #region Constants

        public const double SOLUCIONES_AR_PERCENTAJE = 0.2;

        public const double GOLD_USER_PERCENTAJE = 0.1;
        public const double SILVER_USER_PERCENTAJE = 0.3;
        public const double REAL_USER_PERCENTAJE = 0.6;

        #endregion

        #region Properties

        #endregion

        #region Private Members

        private readonly TransactionsAccess _transactionsAccess;
        private readonly CompaniesAccess _companiesAccess;
        private readonly UsersAccess _usersAccess;
        private readonly RelationshipTypesAccess _relationshipTypesAccess;
        private readonly RelationshipsAccess _relationshipsAccess;

        #endregion

        #region Constructors

        public TransactionsLogic()
        {
            _transactionsAccess = new TransactionsAccess();
            _companiesAccess = new CompaniesAccess();
            _usersAccess = new UsersAccess();
            _relationshipTypesAccess = new RelationshipTypesAccess();
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool DistributeTransactionCashback(Transaction transaction)
        {
            //TODO: en proceso aun...
            var company = _companiesAccess.GetCompany(transaction.Store);

            // del 100% esto es la comision total
            var cashBackPercentajeAssignable = transaction.Amount * company.CashBackPercentaje / 100;
            // Este seria el 20% para soluciones AR
            var solucionesArAmount = cashBackPercentajeAssignable * SOLUCIONES_AR_PERCENTAJE;
            //TODO: falta aca darle esta cantidad al usuario solucionesAR
            // Este seria el 80% del que los usuarios van a tomar sus %
            var forUsersAmount = cashBackPercentajeAssignable - solucionesArAmount;

            // Calculo del cashback para el usuario gold.
            var goldUser = AssingMoneyToUser(transaction.Customer, RelationshipTypesAccess.GOLD_RELATION,
                                            forUsersAmount, GOLD_USER_PERCENTAJE);
            _usersAccess.UpdateUser(goldUser);


            // Calculo del cashback para el usuario silver
            var silverUser = AssingMoneyToUser(transaction.Customer, RelationshipTypesAccess.SILVER_RELATION,
                                               forUsersAmount, SILVER_USER_PERCENTAJE);
            _usersAccess.UpdateUser(silverUser);

            // Calculo del cashback para el usuario que hizo la compra
            var transactionUser = transaction.Customer;
            var moneyForRealUser = forUsersAmount * REAL_USER_PERCENTAJE;
            transactionUser.Cashback += moneyForRealUser;
            _usersAccess.UpdateUser(transactionUser);

            return _transactionsAccess.SaveTransaction(transaction);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <param name="relationType"></param>
        /// <param name="forUsersAmount"></param>
        /// <param name="userPecentaje"></param>
        /// <returns></returns>
        private User AssingMoneyToUser(User user, string relationType, double forUsersAmount, double userPecentaje)
        {
            var relationshipType = _relationshipTypesAccess.GetRelationShipType(relationType);
            var updatedUser = _relationshipsAccess.GetRelatedUser(user, relationshipType);
            var moneyForUser = forUsersAmount * userPecentaje;
            updatedUser.Cashback += moneyForUser;
            return updatedUser;
        }
        #endregion
 
    }
}