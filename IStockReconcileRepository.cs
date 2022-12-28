using System;
using GM.Model.Common;
using GM.Model.StockReconcile;

namespace GM.DataAccess.Infrastructure
{
    public interface IStockReconcileRepository
    {
        ResultWithModel AddTsd(StockReconcileImportModel model);
        ResultWithModel Import(DateTime asofDate, string import_id);
        ResultWithModel CheckRemark(DateTime asofDate);
        ResultWithModel Get(StockReconcileModel model);
        ResultWithModel Save(StockReconcileModel model);
    }
}
