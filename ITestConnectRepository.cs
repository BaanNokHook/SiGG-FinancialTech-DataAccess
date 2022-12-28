using GM.Model.Common;

namespace GM.DataAccess.Infrastructure
{
    public interface ITestConnectRepository<TestConnectModel>
    {
        ResultWithModel GetTestDatabaseInfo(TestConnectModel model);
        ResultWithModel GetExternalService(TestConnectModel model);
    }
}
