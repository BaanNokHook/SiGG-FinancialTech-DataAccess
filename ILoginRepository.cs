using GM.Model.Common;

namespace GM.DataAccess.Infrastructure
{
    public interface ILoginRepository<LoginModel>
    {
        ResultWithModel Authenticate(LoginModel model);
        ResultWithModel Online(LoginModel model);
        ResultWithModel Offline(LoginModel model);
        ResultWithModel IsStillOnline(LoginModel model);
    }
}
