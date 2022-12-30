using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class TestConnectRepository : ITestConnectRepository<TestConnectModel>
    {
        private readonly IUnitOfWork _uow;

        public TestConnectRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel GetExternalService(TestConnectModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_ExternalService_List_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("RpConfigResultModel");
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetTestDatabaseInfo(TestConnectModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RpDbInformation_List_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("TestConnectResultModel");
            return _uow.ExecDataProc(parameter);
        }
    }
}
