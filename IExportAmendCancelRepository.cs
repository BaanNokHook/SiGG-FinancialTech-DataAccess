using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Infrastructure
{
    public interface IExportAmendCancelRepository
    {
        ResultWithModel GetAmendCancelDaily(ExportAmendCancelDailyMailModel model);

        ResultWithModel GetAmendCancelMonthly(ExportAmendCancelMonthlyMailModel model);
    }
}
