using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPCallMarginRepository
    {
        ResultWithModel Get(string callDateFrom, string callDateTo, string ctpyID, string cur);
        ResultWithModel GetDetail(string asOfDate, int ctpyID);
        ResultWithModel GetDetailBRP(string asOfDate, int ctpyID, string cur);
        ResultWithModel GetList(RPCallMarginModel model);
        ResultWithModel Add(string transDate, string cur, decimal? holiday_int_rate);
        ResultWithModel AddAdjustPRP(RPCallMarginPRPModel model);
        ResultWithModel AddAdjustBRP(RPCallMarginBRPModel model);
        ResultWithModel ActionInterestRate(string transDate, string cur, decimal interestRate);
        ResultWithModel CheckMarginIntRate(RPCallMarginModel model);
    }
}
