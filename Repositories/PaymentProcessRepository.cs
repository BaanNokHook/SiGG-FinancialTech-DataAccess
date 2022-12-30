using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.PaymentProcess;
using GM.DataAccess.UnitOfWork;
using GM.Model.PaymentProcess;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories
{
    public class PaymentProcessRepository
    {
        public IRPConfirmationRepositrory RPConfirmation { get; }
        public IRepository<RPCouponModel> RPTransCoupon { get; }
        public IRepository<RPTransModel> ConfirmBilateral { get; }
        public IRepository<RPTransModel> ConfirmBilateralEarlyTerminate { get; }
        public IRepository<RPTransModel> ConfirmAmendDeal { get; }
        public IRepository<RPCouponDetailModel> RPTransCouponDetail { get; }
        public IRPCouponRepository RPCoupon { get; }
        public IRepository<RPMarginInterestModel> RPMarginInterest { get; }
        public IRPReleaseMessageRepository RPReleaseMessage { get; }
        public IRPCallMarginRepository RPCallMargin { get; }
        public IRepository<RPMarginInterestFCYModel> RPMarginInterestFCY { get; }
        public IRepository<RPReleaseCyberPayModel> RPReleaseCyberPay { get; }


        public PaymentProcessRepository(IUnitOfWork uow)
        {
            RPConfirmation = new RPConfirmationRepositrory(uow);
            RPTransCoupon = new RPTransCouponRepository(uow);
            RPTransCouponDetail = new RPTransCouponDetailRepository(uow);
            RPCoupon = new RPCouponRepository(uow);
            RPMarginInterest = new RPMarginInterestRepository(uow);
            RPMarginInterestFCY = new RPMarginInterestFCYRepository(uow);
            RPReleaseMessage = new RPReleaseMessageRepository(uow);
            RPCallMargin = new RPCallMarginRepository(uow);
            ConfirmBilateral = new RPConfirmationBilateralRepositrory(uow);
            ConfirmBilateralEarlyTerminate = new RPConfirmationEarlyRepositrory(uow);
            ConfirmAmendDeal = new RPConfirmationAmendDealRepositrory(uow);
            RPReleaseCyberPay = new RPReleaseCyberPayRepositrory(uow);
        }
    }
}
