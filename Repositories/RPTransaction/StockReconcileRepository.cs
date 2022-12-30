using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.StockReconcile;
using System;

namespace GM.DataAccess.Repositories.RPTransaction
{
    public class StockReconcileRepository : IStockReconcileRepository
    {
        private readonly IUnitOfWork _uow;

        public StockReconcileRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel AddTsd(StockReconcileImportModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Tsd_Trans_Insert_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "import_id", Value = model.import_id });
            parameter.Parameters.Add(new Field { Name = "filename", Value = model.filename });
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = model.asOfDate });
            parameter.Parameters.Add(new Field { Name = "participant", Value = model.participant });
            parameter.Parameters.Add(new Field { Name = "accno", Value = model.accno });
            parameter.Parameters.Add(new Field { Name = "instrumentCode", Value = model.instrumentCode });
            parameter.Parameters.Add(new Field { Name = "isincode", Value = model.isincode });
            parameter.Parameters.Add(new Field { Name = "unit", Value = model.unit });
            parameter.Parameters.Add(new Field { Name = "pending_withdrawal", Value = model.pending_withdrawal });
            parameter.Parameters.Add(new Field { Name = "pending_deposit", Value = model.pending_deposit });
            parameter.Parameters.Add(new Field { Name = "pending_sec", Value = model.pending_sec });
            parameter.Parameters.Add(new Field { Name = "broker", Value = model.broker });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Import(DateTime asofDate, string import_id)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Stock_Reconcile_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = asofDate });
            parameter.Parameters.Add(new Field { Name = "import_id", Value = import_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel CheckRemark(DateTime asofDate)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Stock_Reconcile_Check_Remark_Proc";
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = asofDate });
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999999;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(StockReconcileModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Stock_Reconcile_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "ASOF_DATE", Value = model.as_of_date });
            parameter.Parameters.Add(new Field { Name = "INSTRUMENT_ID", Value = model.instrument_id });
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999999;
            parameter.Orders = model.OrdersBy;
            parameter.ResultModelNames.Add("StockReconcileListResultModel");
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Save(StockReconcileModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Stock_Reconcile_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "ASOF_DATE", Value = model.as_of_date });
            parameter.Parameters.Add(new Field { Name = "INSTRUMENT_CODE", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "AFS_UNIT", Value = model.afs_unit });
            parameter.Parameters.Add(new Field { Name = "HTM_UNIT", Value = model.htm_unit });
            parameter.Parameters.Add(new Field { Name = "MEMO_BNK_UNIT", Value = model.memo_bnk_unit });
            parameter.Parameters.Add(new Field { Name = "MEMO_TRD_UNIT", Value = model.memo_trd_unit });
            parameter.Parameters.Add(new Field { Name = "TOTAL_UNIT", Value = model.total_unit });
            parameter.Parameters.Add(new Field { Name = "OUTSTANDING_UNIT", Value = model.outstanding_unit });
            parameter.Parameters.Add(new Field { Name = "OBLIGATE_UNIT", Value = model.obligate_unit });
            parameter.Parameters.Add(new Field { Name = "DIFF_UNIT", Value = model.diff_unit });
            parameter.Parameters.Add(new Field { Name = "REMARK", Value = model.remark });
            parameter.Parameters.Add(new Field { Name = "IMPORT_ID", Value = model.import_id });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.recorded_by });
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
