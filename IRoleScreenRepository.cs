using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Infrastructure
{
    public interface IRoleScreenRepository : IRepository<RoleAndScreenModel>
    {
        ResultWithModel ScreenMenu(string username);
    }
}
