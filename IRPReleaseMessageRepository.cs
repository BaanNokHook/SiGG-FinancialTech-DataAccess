using GM.Model.Common;
using GM.Model.PaymentProcess;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPReleaseMessageRepository
    {
        ResultWithModel Get(RPTransModel model);
        ResultWithModel GetNetSettle(RPTransModel model);
        ResultWithModel GetList(RPTransModel model);
        ResultWithModel GetListPTI(RPTransModel model);
        ResultWithModel GetListNetSettle(RPTransModel model);
        ResultWithModel GetConfirm(RPTransModel model);
        ResultWithModel GetAmendConfirm(RPTransModel model);
        ResultWithModel GetConfirmPRP(RPTransModel model);
        ResultWithModel Add(RPReleaseMessageModel model);
        ResultWithModel MtList(RPTransModel model);
        ResultWithModel RPCouponList(RPCouponModel model);
        ResultWithModel CallMarginList(RPCallMarginModel model);
        ResultWithModel CallMarginGet(RPCallMarginModel model);
        ResultWithModel CallMargin(RPCallMarginModel model);
        ResultWithModel CheckPayment(RPReleaseMsgCheckPaymentModel model);
        ResultWithModel DetailCoupon(RPCouponModel model);
        ResultWithModel InterestMarginList(RPCallMarginModel model);
        ResultWithModel InterestMargin(RPCallMarginModel model);
    }
}
