using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPCouponRepository
    {
        ResultWithModel Get(RPCouponModel model);
        ResultWithModel GetList(RPCouponModel model);
        ResultWithModel GetDetail(RPCouponModel model);
    }
}
