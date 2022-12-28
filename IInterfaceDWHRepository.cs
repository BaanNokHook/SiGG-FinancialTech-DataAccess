using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceDWHRepository
    {
        ResultWithModel Add(InterfaceDwhSftpModel model);
        ResultWithModel GetList(InterfaceDwhSftpModel model);
        ResultWithModel GetSftp(InterfaceDwhSftpModel model);

    }
}
