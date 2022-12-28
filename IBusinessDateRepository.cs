using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Infrastructure
{
    public interface IBusinessDateRepository
    {
        ResultWithModel GetBusinessDate(BusinessDateModel model);
        ResultWithModel GetBusinessDateOrSystemDate(BusinessDateModel model);
    }
}
