using GM.CommonLibs.Common;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories;
using GM.Model.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace GM.DataAccess.UnitOfWork
{
    public class AdoUnitOfWork : IUnitOfWork
    {
        private SqlConnection _connection;
        private SqlTransaction _trans = null;
        private bool _disposed = false;
        private string _connectionString;
        private string _defaultDateFormat;
        private string _defaultDateTimeFormat;
        private IConfiguration _configuration;

        public AdoUnitOfWork(IConfiguration configuration)
        {
            Generator generator = new Generator();
            _configuration = configuration;
            _connectionString = generator.Decrypt(_configuration.GetConnectionString("DefaultConnection"));
            _defaultDateFormat = _configuration.GetSection("DefaultDateFormat").Value;
            _defaultDateTimeFormat = _configuration.GetSection("DefaultDateTimeFormat").Value;

            _connection = new SqlConnection(_connectionString);

            Tests = new TestRepository(this);
            Dropdown = new DropdownRepository(this);
            RPTransaction = new RPTransactionRepository(this);
            PaymentProcess = new PaymentProcessRepository(this);
            Static = new StaticRepository(this);
            UserAndScreen = new UserAndScreenRepository(this);
            CounterPartyGroup = new CounterPartyGroupRepository(this);
            MarketProcess = new MarketProcessRepository(this);
            Report = new ReportRepository(this);
            External = new ExternalRepository(this);
            GLProcess = new GLProcessRepository(this);
        }

        #region Repository
        public RPTransactionRepository RPTransaction { get; private set; }
        public PaymentProcessRepository PaymentProcess { get; private set; }
        public StaticRepository Static { get; private set; }
        public UserAndScreenRepository UserAndScreen { get; private set; }
        public CounterPartyGroupRepository CounterPartyGroup { get; private set; }
        public MarketProcessRepository MarketProcess { get; private set; }
        public ReportRepository Report { get; private set; }
        public ExternalRepository External { get; private set; }
        public GLProcessRepository GLProcess { get; private set; }
        public ITestRepository Tests { get; private set; }
        public IDropdownRepository<DropdownModel> Dropdown { get; private set; }
        #endregion
        public IConfiguration GetConfiguration => _configuration;

        public SqlCommand CreateCommand(string qry, CommandType type, BaseParameterModel model)
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();

            SqlCommand cmd = _connection.CreateCommand();

            if (_trans != null)
                cmd.Transaction = _trans;

            cmd.Connection = _connection;
            cmd.CommandType = type;
            cmd.CommandText = qry;
            ParameterBinding(cmd, model.Parameters);

            return cmd;
        }

        #region Set Parameter
        private void ParameterBinding(IDbCommand command, List<Field> fields)
        {
            fields.ForEach(key =>
            {
                if (key.DataType != null)
                {
                    if (key.DataType == DbType.DateTime)
                    {
                        IDataParameter param = command.CreateParameter();
                        param.ParameterName = key.Name;
                        param.DbType = key.DataType.Value;

                        _defaultDateTimeFormat = _defaultDateTimeFormat.Replace("{0:", string.Empty).Replace("}", string.Empty);

                        // use the format specified in the DisplayFormat attribute to parse the date
                        if (DateTime.TryParseExact((string)key.Value, _defaultDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                        {
                            param.Value = date;
                        }
                        else
                        {
                            _defaultDateFormat = _defaultDateFormat.Replace("{0:", string.Empty).Replace("}", string.Empty);

                            if (DateTime.TryParseExact((string)key.Value, _defaultDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                            {
                                param.Value = date;
                            }

                            else
                            {
                                param.Value = key.Value;
                            }
                        }

                        command.Parameters.Add(param);
                    }
                    else
                    {
                        IDataParameter param = command.CreateParameter();
                        param.ParameterName = key.Name;
                        param.Value = key.Value;
                        param.DbType = key.DataType.Value;
                        command.Parameters.Add(param);
                    }
                }
                else
                {
                    IDataParameter param = command.CreateParameter();
                    param.ParameterName = key.Name;
                    param.Value = key.Value;
                    command.Parameters.Add(param);
                }

            });
        }

        private void ParameterPaging(IDbCommand command, PagingModel model)
        {
            IDataParameter param = command.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = model.PageNumber;
            command.Parameters.Add(param);

            param = command.CreateParameter();
            param.ParameterName = "@RecordPerPage";
            param.Value = model.RecordPerPage;
            command.Parameters.Add(param);
        }

        private void ParameterOrders(IDbCommand command, List<OrderByModel> orderModel)
        {
            foreach (var model in orderModel)
            {
                var ordersby = model.Name + " " + (model.SortDirection == SortDirection.Descending ? "DESC" : "ASC");
                IDataParameter param = command.CreateParameter();
                param.ParameterName = "@Orderby";
                param.Value = ordersby;
                command.Parameters.Add(param);
            }
        }

        #endregion

        #region Exec Members

        public ResultWithModel ExecNonQuery(string qry, BaseParameterModel model)
        {
            ResultWithModel rwm = new ResultWithModel();
            try
            {
                using (IDbCommand cmd = CreateCommand(qry, CommandType.Text, model))
                {
                    SqlParameter outRefCode = new SqlParameter("@ReturnCode", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outMessage = new SqlParameter("@Msg", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                    SqlParameter outServerity = new SqlParameter("@Serverity", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
                    //SqlParameter outHowManyRecord = new SqlParameter("@HowManyRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(outRefCode);
                    cmd.Parameters.Add(outMessage);
                    cmd.Parameters.Add(outServerity);
                    //cmd.Parameters.Add(outHowManyRecord);
                    cmd.CommandTimeout = _connection.ConnectionTimeout;

                    rwm.Data = cmd.ExecuteNonQuery();

                    //retrieve out parameter
                    rwm.RefCode = (outRefCode.Value == DBNull.Value || outRefCode.Value == null) ? 0 : (int)outRefCode.Value;
                    rwm.Message = (outMessage.Value == DBNull.Value || outMessage.Value == null) ? string.Empty : outMessage.Value.ToString();
                    rwm.Serverity = (outServerity.Value == DBNull.Value || outServerity.Value == null) ? string.Empty : outServerity.Value.ToString();
                    if (rwm.RefCode.Equals(0))
                    {
                        rwm.Success = true;
                        if (string.IsNullOrEmpty(rwm.Message))
                        {
                            rwm.Message = "Successfully";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rwm.RefCode = 500;
                rwm.Message = ex.Message;

                if (ex.InnerException != null)
                {
                    rwm.Message += " ,InnerException:" + ex.InnerException.Message;
                }
            }
            return rwm;
        }

        public ResultWithModel ExecNonQueryProc(BaseParameterModel model)
        {
            return ExecNonQueryProc(model, string.Empty, out string outId);
        }

        public ResultWithModel ExecNonQueryProc(BaseParameterModel model, string outParamName, out string outId)
        {
            ResultWithModel rwm = new ResultWithModel();
            outId = string.Empty;
            try
            {
                using (IDbCommand cmd = CreateCommand(model.ProcedureName, CommandType.StoredProcedure, model))
                {
                    SqlParameter outRefCode = new SqlParameter("@ReturnCode", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outMessage = new SqlParameter("@Msg", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                    SqlParameter outServerity = new SqlParameter("@Serverity", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(outRefCode);
                    cmd.Parameters.Add(outMessage);
                    cmd.Parameters.Add(outServerity);
                    cmd.CommandTimeout = _connection.ConnectionTimeout;

                    SqlParameter oParam = new SqlParameter();

                    if (!string.IsNullOrEmpty(outParamName))
                    {
                        oParam = new SqlParameter("@" + outParamName, SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(oParam);
                    }

                    cmd.ExecuteNonQuery();

                    //retrieve out parameter
                    rwm.RefCode = (outRefCode.Value == DBNull.Value || outRefCode.Value == null) ? 0 : (int)outRefCode.Value;
                    rwm.Message = (outMessage.Value == DBNull.Value || outMessage.Value == null) ? string.Empty : outMessage.Value.ToString();
                    rwm.Serverity = (outServerity.Value == DBNull.Value || outServerity.Value == null) ? string.Empty : outServerity.Value.ToString();

                    outId = (oParam.Value == DBNull.Value || oParam.Value == null) ? string.Empty : oParam.Value.ToString();

                    if (rwm.RefCode.Equals(0))
                    {
                        rwm.Success = true;
                        if (string.IsNullOrEmpty(rwm.Message))
                        {
                            rwm.Message = "Successfully";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rwm.RefCode = 500;
                rwm.Message = ex.Message;

                if (ex.InnerException != null)
                {
                    rwm.Message += " ,InnerException:" + ex.InnerException.Message;
                }
            }

            return rwm;
        }

        public object ExecScalar(string qry, BaseParameterModel model)
        {
            using (IDbCommand cmd = CreateCommand(qry, CommandType.Text, model))
            {
                return cmd.ExecuteScalar();
            }
        }

        public object ExecScalarProc(BaseParameterModel model)
        {
            using (IDbCommand cmd = CreateCommand(model.ProcedureName, CommandType.StoredProcedure, model))
            {
                return cmd.ExecuteScalar();
            }
        }

        public ResultWithModel ExecData(string qry, BaseParameterModel model)
        {
            ResultWithModel rwm = new ResultWithModel();
            try
            {
                using (IDbCommand cmd = CreateCommand(qry, CommandType.Text, model))
                {

                    SqlParameter outRefCode = new SqlParameter("@ReturnCode", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outMessage = new SqlParameter("@Msg", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                    SqlParameter outServerity = new SqlParameter("@Serverity", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
                    SqlParameter outHowManyRecord = new SqlParameter("@HowManyRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(outRefCode);
                    cmd.Parameters.Add(outMessage);
                    cmd.Parameters.Add(outServerity);
                    cmd.Parameters.Add(outHowManyRecord);
                    cmd.CommandTimeout = _connection.ConnectionTimeout;

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());

                    rwm.RefCode = (outRefCode.Value == DBNull.Value || outRefCode.Value == null) ? 0 : (int)outRefCode.Value;
                    rwm.HowManyRecord = (outHowManyRecord.Value == DBNull.Value || outHowManyRecord.Value == null) ? 0 : (int)outHowManyRecord.Value;
                    rwm.Message = (outMessage.Value == DBNull.Value || outMessage.Value == null) ? string.Empty : outMessage.Value.ToString();
                    rwm.Serverity = (outServerity.Value == DBNull.Value || outServerity.Value == null) ? string.Empty : outServerity.Value.ToString();

                    if (rwm.RefCode.Equals(0))
                    {
                        rwm.Success = true;
                        rwm.Data = dt;

                        if (string.IsNullOrEmpty(rwm.Message))
                        {
                            rwm.Message = "Successfully";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                rwm.RefCode = 500;
                rwm.Message = ex.Message;

                if (ex.InnerException != null)
                {
                    rwm.Message += " ,InnerException:" + ex.InnerException.Message;
                }
            }

            return rwm;
        }

        public ResultWithModel ExecDataProc(BaseParameterModel model)
        {
            ResultWithModel rwm = new ResultWithModel();
            try
            {
                using (SqlCommand cmd = CreateCommand(model.ProcedureName, CommandType.StoredProcedure, model))
                {
                    SqlParameter outRefCode = new SqlParameter("@ReturnCode", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    SqlParameter outMessage = new SqlParameter("@Msg", SqlDbType.VarChar, 255) { Direction = ParameterDirection.Output };
                    SqlParameter outServerity = new SqlParameter("@Serverity", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output };
                    SqlParameter outHowManyRecord = new SqlParameter("@HowManyRecord", SqlDbType.Int) { Direction = ParameterDirection.Output };

                    cmd.Parameters.Add(outRefCode);
                    cmd.Parameters.Add(outMessage);
                    cmd.Parameters.Add(outServerity);
                    cmd.Parameters.Add(outHowManyRecord);
                    cmd.CommandTimeout = _connection.ConnectionTimeout;

                    if (model.Paging != null)
                    {
                        ParameterPaging(cmd, model.Paging);
                    }

                    if (model.Orders != null)
                    {
                        ParameterOrders(cmd, model.Orders);
                    }

                    DataSet dataSet = new DataSet();
                    (new SqlDataAdapter(cmd)).Fill(dataSet);
                    //DataTable dt = new DataTable();
                    //dt.Load(cmd.ExecuteReader());
                    //dataSet.Tables.Add(dt);

                    if (model.ResultModelNames.Count > 0)
                    {
                        foreach (DataTable t in dataSet.Tables)
                        {
                            try
                            {
                                var tableindex = dataSet.Tables.IndexOf(t);
                                if (!string.IsNullOrEmpty(model.ResultModelNames[tableindex]))
                                {
                                    t.TableName = model.ResultModelNames[tableindex];
                                }
                            }
                            catch { }
                        }
                    }

                    rwm.RefCode = (outRefCode.Value == DBNull.Value || outRefCode.Value == null) ? 0 : (int)outRefCode.Value;
                    rwm.HowManyRecord = (outHowManyRecord.Value == DBNull.Value || outHowManyRecord.Value == null) ? 0 : (int)outHowManyRecord.Value;
                    rwm.Message = (outMessage.Value == DBNull.Value || outMessage.Value == null) ? string.Empty : outMessage.Value.ToString();
                    rwm.Serverity = (outServerity.Value == DBNull.Value || outServerity.Value == null) ? string.Empty : outServerity.Value.ToString();

                    if (rwm.RefCode.Equals(0))
                    {
                        rwm.Success = true;
                        rwm.Data = dataSet;

                        if (string.IsNullOrEmpty(rwm.Message))
                        {
                            rwm.Message = "Successfully";
                        }
                    }

                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
                rwm.RefCode = 500;
                rwm.Message = ex.Message;

                if (ex.InnerException != null)
                {
                    rwm.Message += " ,InnerException:" + ex.InnerException.Message;
                }
            }

            return rwm;
        }

        #endregion

        #region Transaction Members
        public SqlTransaction Transaction { get { return _trans; } }
        /// <summary>
        /// Begins a transaction
        /// </summary>
        /// <returns>The new SqlTransaction object</returns>
        public SqlTransaction BeginTransaction()
        {
            Rollback();

            if (_connection.State != ConnectionState.Open) _connection.Open();

            _trans = _connection.BeginTransaction();

            return Transaction;
        }

        /// <summary>
        /// Commits any transaction in effect.
        /// </summary>
        public void Commit()
        {
            if (_trans != null)
            {
                _trans.Commit();
                _trans = null;
            }
        }

        /// <summary>
        /// Rolls back any transaction in effect.
        /// </summary>
        public void Rollback()
        {
            if (_trans != null)
            {
                _trans.Rollback();
                _trans = null;
            }
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                // Need to dispose managed resources if being called manually
                if (disposing)
                {
                    if (_connection != null)
                    {
                        Rollback();
                        _connection.Dispose();
                    }
                }
                _disposed = true;
            }
        }

        #endregion
    }
}
