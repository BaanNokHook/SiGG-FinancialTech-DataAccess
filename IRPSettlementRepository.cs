using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPSettlementRepository
    {
        ResultWithModel Get(RPTransModel model);
        ResultWithModel GetColl(RPTransModel model);
        ResultWithModel Update(RPTransModel model);
    }
}
