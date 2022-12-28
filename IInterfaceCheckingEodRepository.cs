using GM.Model.Common;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceCheckingEodRepository
    {
        ResultWithModel Get();
        ResultWithModel Update(string taskName);
    }
}
