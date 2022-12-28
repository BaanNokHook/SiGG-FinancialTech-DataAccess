using GM.Model;
using GM.Model.Common;

namespace GM.DataAccess.Infrastructure
{
    public interface ITestRepository : IRepository<Test>
    {
        ResultWithModel TestCreate();
    }
}
