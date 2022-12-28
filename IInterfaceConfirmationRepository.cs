using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Infrastructure
{
    public interface IInterfaceConfirmationRepository
    {
        ResultWithModel GetList(InterfaceCCMSearch model);

        ResultWithModel AddLog(string ref_id, string trans_no, string trans_type_code, string create_by);

        ResultWithModel GetSignName(string trans_no, string create_by);

    }
}
