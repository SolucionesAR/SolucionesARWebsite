﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using SolucionesARWebsite.DataAccess;
using SolucionesARWebsite.DataAccess.Interfaces;
using SolucionesARWebsite.DataAccess.Repositories;
using SolucionesARWebsite.Models;

namespace SolucionesARWebsite.Business.Logic
{
    public class TransactionsLogic
    {
        #region Constants
        public const string MASTER = "Master";
        public const string SENIOR = "Senior";
        private const double SOLUCIONES_AR_PERCENTAJE = 0.3;
        private const double MASTER_USER_PERCENTAJE = 0.1;
        private const double SENIOR_USER_PERCENTAJE = 0.3;
        private const double REAL_USER_PERCENTAJE = 0.6;
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

        private readonly ICompaniesRepository _companiesRepository;
        //private readonly IRelationshipsRepository _relationshipsRepository;
        private readonly IRelationshipTypesRepository _relationshipTypesAccess;
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IUsersRepository _usersRepository;

        private readonly StoresAccess _storesAccess;

        #endregion

        #region Constructors

        public TransactionsLogic(ICompaniesRepository companiesRepository, /*IRelationshipsRepository relationshipsRepository,*/ IRelationshipTypesRepository relationshipTypesRepository, ITransactionsRepository transactionsRepository, IUsersRepository usersRepository)
        {
            _companiesRepository = companiesRepository;
            //_relationshipsRepository = relationshipsRepository;//TODO: quitando relations
            _relationshipTypesAccess = relationshipTypesRepository;
            _transactionsRepository = transactionsRepository;
            _usersRepository = usersRepository;

            _storesAccess = new StoresAccess();
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
            try
            {
                var store = _storesAccess.GetStore(transaction.StoreId);
                var company = _companiesRepository.GetCompany(store);

                // del 100% esto es la comision total
                var cashBackPercentajeAssignable = transaction.Amount*company.CashBackPercentaje/100;
                // Este seria el 30% para soluciones AR
                var solucionesArAmount = cashBackPercentajeAssignable*SOLUCIONES_AR_PERCENTAJE;
                UpdateSolucionesArUser(solucionesArAmount);
                // Este seria el 70% del que los usuarios van a tomar sus %
                var forUsersAmount = cashBackPercentajeAssignable - solucionesArAmount;



                // Los usuarios
                var customer = _usersRepository.GetUserById(transaction.CustomerId);
                var parentUser = customer.UserReference;
                var forSeniorMoney = forUsersAmount*SENIOR_USER_PERCENTAJE;
                if (parentUser != null)
                {
                    if (parentUser.RelationshipType.Description.Equals(MASTER) ||
                        parentUser.RelationshipType.Description.Equals(SENIOR))
                    {
                        parentUser.Cashback += forSeniorMoney;
                        _usersRepository.UpdateUser(parentUser);
                    }
                    var grandParentUser = parentUser.UserReference;
                    var forMasterMoney = forUsersAmount*MASTER_USER_PERCENTAJE;
                    if (grandParentUser != null)
                    {
                        if (grandParentUser.RelationshipType.Description.Equals(MASTER))
                        {
                            grandParentUser.Cashback += forMasterMoney;
                            _usersRepository.UpdateUser(grandParentUser);
                        }
                    }
                    else
                    {
                        _usersRepository.UpdateUser(UpdateSolucionesArUser(forMasterMoney));
                    }
                }
                else
                {
                    _usersRepository.UpdateUser(UpdateSolucionesArUser(forUsersAmount));
                }

                // Calculo del cashback para el usuario que hizo la compra
                var moneyForRealUser = forUsersAmount*REAL_USER_PERCENTAJE;
                customer.Cashback += moneyForRealUser;
                customer.Points += transaction.Points;
                _usersRepository.UpdateUser(customer);
                return true;



                // Calculo del cashback para el usuario master, si no existe se le pasa a soluciones AR.
                /*
                var masterUser = AssingMoneyToUser(customer, RelationshipTypesRepository.MASTER_RELATION,
                                                   forUsersAmount, MASTER_USER_PERCENTAJE);
                _usersRepository.UpdateUser(masterUser);


                // Calculo del cashback para el usuario senior, si no existe se le pasa a soluciones AR.
                var seniorUser = AssingMoneyToUser(customer, RelationshipTypesRepository.SENIOR_RELATION,
                                                   forUsersAmount, SENIOR_USER_PERCENTAJE);
                _usersRepository.UpdateUser(seniorUser);

                */



            }
            catch (Exception)
            {
                return false;
            }

            
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
                var dataSet = new DataSet();

                adapter.Fill(dataSet, DATA_TABLE_NAME);

                var reportData = dataSet.Tables[DATA_TABLE_NAME].AsEnumerable();

                //TODO: agregar la logica con el formato del file correspondiente
                /*var query = data.Where(x => x.Field<double?>(4) != 0.0) //x indice de columna.
                    .Select(x => new{campana = x.Field<string>("Campaña"), factura = x.Field<string>("No. Factura") }).ToList(); //o por nombre de columna.
                */

                var transactionsList =
                    reportData.Where(y => y.Field<string>("Campaña") != null)
                        .Select(
                            x => new
                            {
                                campana = x.Field<string>("Campaña"),
                                factura = x.Field<string>("Factura"),
                                fecha = x.Field<string>("Fecha"),
                                monto = x.Field<double>("Monto"),
                                puntos = x.Field<double>("Puntos"),
                                comision = x.Field<double?>("Comisión"),
                                vendedor = x.Field<string>("Vendedor"),
                                tienda = x.Field<string>("Tienda"),
                            }).
                        ToList(); //o por nombre de columna.
                foreach (var individualTransaction in transactionsList)
                {
                    var customer = _usersRepository.GetUserByGeneratedCode(individualTransaction.vendedor);
                    var store = _storesAccess.GetStore(individualTransaction.tienda);
                    var transaction = new Transaction
                    {
                        Amount = individualTransaction.monto,
                        BillBarCode = individualTransaction.factura,
                        CustomerId = customer.UserId,
                        Points = (int)individualTransaction.puntos,
                        StoreId = store.StoreId,
                        CreatetedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow,
                    };
                    if (_transactionsRepository.SaveTransaction(transaction))
                    {
                        DistributeTransactionCashback(transaction);
                    }
                    else
                    {
                        //send error
                        return false;
                    }

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

        #region Private Methods

        /*/// <summary>
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
            var updatedUser = _relationshipsRepository.GetRelatedUser(user, relationshipType);
            var moneyForUser = forUsersAmount*userPecentaje;
            if (updatedUser != null)
            {
                updatedUser.Cashback += moneyForUser;
                return updatedUser;
            }

            var solucionesArUser = UpdateSolucionesArUser(moneyForUser);
            return solucionesArUser;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        private User UpdateSolucionesArUser(double money)
        {
            var solucionesArUser = _usersRepository.GetSolucionesArUser();//TODO: ver si lo agarramos asi o de la tabla de GlobalParameters?? no la hemos usado en ningun lado
            solucionesArUser.Cashback += money;
            return solucionesArUser;
        }



        #endregion

    }
}