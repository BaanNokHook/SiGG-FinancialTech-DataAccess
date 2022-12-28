using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Infrastructure
{
    public interface IRPReportTBMARepository
    {
        ResultWithModel GetList(RPTransModel model);
        ResultWithModel GetDetail(RPTransModel model, string exportType);
    }
}
