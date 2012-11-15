﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
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
        private const string EXCEL_2007_EXTENSION = ".xlsx";
        private const string SELECT_ALL_QUERY = "SELECT * FROM [{0}$]";
        private const string DATA_TABLE_NAME = "datatable";

        private const string EXCEL_2007_CONNECTION_STRING =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=0\"";

        private const string EXCEL_2005_CONNECTION_STRING =
            "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=0\"";



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
            var cashBackPercentajeAssignable = transaction.Amount*company.CashBackPercentaje/100;
            // Este seria el 20% para soluciones AR
            var solucionesArAmount = cashBackPercentajeAssignable*SOLUCIONES_AR_PERCENTAJE;
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
            var moneyForRealUser = forUsersAmount*REAL_USER_PERCENTAJE;
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
            var moneyForUser = forUsersAmount*userPecentaje;
            updatedUser.Cashback += moneyForUser;
            return updatedUser;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public bool SaveTransactionsFromFile(string filename, string sheetName)
        {
            try
            {
                string connectionString =
                    string.Format(
                        filename.Substring(filename.LastIndexOf('.')).ToLower() == EXCEL_2007_EXTENSION
                            ? EXCEL_2007_CONNECTION_STRING
                            : EXCEL_2005_CONNECTION_STRING, filename);


                var adapter = new OleDbDataAdapter(string.Format(SELECT_ALL_QUERY, sheetName), connectionString);
                var ds = new DataSet();

                adapter.Fill(ds, DATA_TABLE_NAME);

                var data = ds.Tables[DATA_TABLE_NAME].AsEnumerable();

                //TODO: agregar la logica con el formato del file correspondiente
                var query = data.Where(x => x.Field<double?>(4) != 0.0) //x indice de columna.
                    .Select(x => x.Field<string>("Vendedor")).ToList(); //o por nombre de columna.

                foreach (var que in query)
                {
                    Console.WriteLine(que);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion

       
    }
}