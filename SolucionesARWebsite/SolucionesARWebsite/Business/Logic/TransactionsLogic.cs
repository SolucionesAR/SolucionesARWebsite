using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Logic
{
    public class TransactionsLogic
    {
        #region Constants

        public const double SOLUCIONES_AR_PERCENTJE = 0.2;
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
        #endregion
        
        #region Private Methods
        #endregion

        public void DistributeTransactionCashback(Transaction transaction)
        {
            //TODO: en proceso aun...
            var company = _companiesAccess.GetCompany(transaction.Store);

            double cashBackPercentajeAssignable = transaction.Amount*company.CashBackPercentaje/100;
            double solucionesARAmount = cashBackPercentajeAssignable*SOLUCIONES_AR_PERCENTJE;


            RelationshipType relationshipTypeGold = _relationshipTypesAccess.GetRelationShipType(RelationshipTypesAccess.GOLD_RELATION);
            User goldUser = _relationshipsAccess.GetRelatedUser(transaction.Customer, relationshipTypeGold);


            RelationshipType relationshipTypeSilver = _relationshipTypesAccess.GetRelationShipType(RelationshipTypesAccess.SILVER_RELATION);
            User silverUser = _relationshipsAccess.GetRelatedUser(transaction.Customer, relationshipTypeSilver);
        }
    }
}