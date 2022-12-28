using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPTransCollateralRepository
    {
        ResultWithModel Add(RPTransCollateralModel model);
        ResultWithModel Get(RPTransCollateralModel model);
    }
}
