using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPTransRepository
    {
        ResultWithModel Add(RPTransModel model);
        ResultWithModel Update(RPTransModel model);
        ResultWithModel Remove(RPTransModel model);
        ResultWithModel BilateralNoGen(RPTransModel model);
        ResultWithModel GetList(RPTransModel model);
        ResultWithModel GetDetail(RPTransModel model);
        ResultWithModel GetAddColl(RPTransModel model);
        ResultWithModel GetInfo(RPTransModel model);
        ResultWithModel GetCopyDeal(RPTransModel model);
        ResultWithModel CallPrice(RPTransModel model);
        ResultWithModel CheckDate(RPTransModel model);
        ResultWithModel CheckPeriod(RPTransModel model);
        ResultWithModel CheckCollateral(RPTransModel model);
        ResultWithModel CheckLimit(RPTransModel model);
        ResultWithModel CheckInterest(RPTransModel model);
        ResultWithModel CheckCostOfFund(RPTransModel model);
        ResultWithModel PolicyCostOfFund(string cur);
        ResultWithModel GetPopupRefno(RPTransModel model);
    }
}
