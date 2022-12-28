using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceFxRepository
    {
        ResultWithModel GetTransaction(InterfaceFxReconcileSftpModel model);

        ResultWithModel GetPosition(InterfaceFxReconcileSftpModel model);

        ResultWithModel GetPostingEvent(InterfaceFxReconcileSftpModel model);
    }
}
