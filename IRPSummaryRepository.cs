using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPSummaryRepository
    {
        ResultWithModel Get(RPTransModel model);
        ResultWithModel GetColl(RPTransModel model);
    }
}
