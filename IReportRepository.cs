using System;
using GM.Model.Common;
using GM.Model.Report;

namespace GM.DataAccess.Infrastructure
{
    public interface IReportRepository
    {
        ResultWithModel GlSummary(ReportCriteriaModel model);
        ResultWithModel GlTransaction(ReportCriteriaModel model);
        ResultWithModel Maturity(ReportCriteriaModel model);
        ResultWithModel AverageYTM(ReportCriteriaModel model);
        ResultWithModel CallMargin(ReportCriteriaModel model);
        ResultWithModel MarginByCounterparty(ReportCriteriaModel model);
        ResultWithModel Payment(ReportCriteriaModel model);
        ResultWithModel MarginCalResultDetail(ReportCriteriaModel model);
        ResultWithModel MarginCalResultSummary(ReportCriteriaModel model);
        ResultWithModel Outstanding(ReportCriteriaModel model);
        ResultWithModel OutstandingCashMargin(ReportCriteriaModel model);
        ResultWithModel OutstandingBilateralPrivate(ReportCriteriaModel model);
        ResultWithModel OutstandingLoansLending(ReportCriteriaModel model);
        ResultWithModel OutstandingBorrow(ReportCriteriaModel model);
        ResultWithModel OutstandingObligatePledge(ReportCriteriaModel model);
        ResultWithModel RPConfirmation(ReportCriteriaModel model);
        ResultWithModel ProfitAndLoss(ReportCriteriaModel model);
        ResultWithModel DailyTransaction(ReportCriteriaModel model);
        ResultWithModel AmendCancel(ReportCriteriaModel model);
        ResultWithModel CashFlow(ReportCriteriaModel model);
        ResultWithModel BISREVREPO(ReportCriteriaModel model);
        ResultWithModel BISINVPLDG(ReportCriteriaModel model);
        ResultWithModel DailyRepoOutstanding(ReportCriteriaModel model);
        ResultWithModel OutstandingBorrowBondForPledge(ReportCriteriaModel model);
        ResultWithModel EodReconcile(DateTime asofdate, bool isBilateralTrade, bool isBilateralSattlementDVP, bool isBilateralSattlementRVP,
            bool isBilateralSattlementMT202, bool isPrivateTrade, bool isPrivateSattlementDVP, bool isPrivateSattlementRVP, bool isPrivateSattlementDF,
            bool isPrivateSattlementRF, bool isPrivateSattlementMT103);
        ResultWithModel EodReconcileCallMargin(DateTime asofdate, bool isBilateralMarginPay, bool isPrivateMarginPay);
        ResultWithModel StockReconcile(ReportCriteriaModel model);
    }
}
