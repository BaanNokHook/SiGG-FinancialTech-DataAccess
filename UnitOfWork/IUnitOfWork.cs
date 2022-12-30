using GM.DataAccess.Infrastructure;
using GM.Model.Common;
using System;
using System.Data;
using System.Data.SqlClient;
using GM.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;

namespace GM.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IConfiguration GetConfiguration { get; }
        #region Repository
        RPTransactionRepository RPTransaction { get; }
        PaymentProcessRepository PaymentProcess { get; }
        StaticRepository Static { get; }
        UserAndScreenRepository UserAndScreen { get; }
        CounterPartyGroupRepository CounterPartyGroup { get; }
        MarketProcessRepository MarketProcess { get; }
        ReportRepository Report { get; }
        ExternalRepository External { get; }
        GLProcessRepository GLProcess { get; }
        ITestRepository Tests { get; }
        IDropdownRepository<DropdownModel> Dropdown { get; }
        #endregion

        #region Database

        SqlCommand CreateCommand(string qry, CommandType type, BaseParameterModel model);
        ResultWithModel ExecNonQuery(string qry, BaseParameterModel model);
        ResultWithModel ExecNonQueryProc(BaseParameterModel model);
        ResultWithModel ExecNonQueryProc(BaseParameterModel model, string outParamName, out string outId);
        object ExecScalar(string qry, BaseParameterModel model);
        object ExecScalarProc(BaseParameterModel model);
        ResultWithModel ExecData(string qry, BaseParameterModel model);
        ResultWithModel ExecDataProc(BaseParameterModel model);
        SqlTransaction BeginTransaction();
        void Commit();
        void Rollback();

        #endregion
    }
}
