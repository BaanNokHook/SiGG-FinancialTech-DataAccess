using GM.DataAccess.Infrastructure;
using GM.DataAccess.Repositories.RPTransaction;
using GM.DataAccess.UnitOfWork;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories
{
    public class RPTransactionRepository { 
    
        public IRPTransRepository RPTrans { get; }
        public IRepository<RPTransCollateralModel> RPTransCollateral { get; }
        public IRPApproveRepository RPApprove { get; }
        public IRPMaturityRepository RPMaturity { get; }
        public IRPSettlementRepository RPSettlement { get; }
        public IRPSummaryRepository RPSummary { get; }
        public IRPVerifyRepository RPVerify { get; }
        public IRPReportTBMARepository RPReportTBMA { get; }
        public IStockReconcileRepository StockReconcile { get; }
        public IRPEarlyTerminationRepository RPEarlyTermination { get; }

        public RPTransactionRepository(IUnitOfWork uow)
        {
            RPTrans = new RPTransRepository(uow);
            RPTransCollateral = new RPTransCollateralRepository(uow);
            RPApprove = new RPApproveRepository(uow);
            RPMaturity = new RPMaturityRepository(uow);
            RPSettlement = new RPSettlementRepository(uow);
            RPSummary = new RPSummaryRepository(uow);
            RPVerify = new RPVerifyRepository(uow);
            RPReportTBMA = new RPReportTBMARepository(uow);
            StockReconcile = new StockReconcileRepository(uow);
            RPEarlyTermination = new RPEarlyTerminationRepository(uow);
        }
    }
}
