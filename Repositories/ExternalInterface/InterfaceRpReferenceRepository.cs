using System;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceRpReference;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceRpReferenceRepository : IInterfaceRpReferenceRepository
    {
        private readonly IUnitOfWork _uow;

        public InterfaceRpReferenceRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqRpReferenceList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Market_Price_Tbma_310001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "asof", Value = model.asof });
            parameter.Parameters.Add(new Field { Name = "settlement_day", Value = model.settlement_day });
            parameter.Parameters.Add(new Field { Name = "bond_type", Value = model.bond_type });
            parameter.Parameters.Add(new Field { Name = "symbol", Value = model.symbol });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "avg_bidding", Value = model.avg_bidding });
            parameter.Parameters.Add(new Field { Name = "govt_interpolated_yield", Value = model.govt_interpolated_yield });
            parameter.Parameters.Add(new Field { Name = "ttm", Value = model.ttm });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "reference_yield", Value = model.reference_yield });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "ai", Value = model.ai });
            parameter.Parameters.Add(new Field { Name = "gross_price_percent", Value = model.gross_price_percent });
            parameter.Parameters.Add(new Field { Name = "clean_price_percent", Value = model.clean_price_percent });
            parameter.Parameters.Add(new Field { Name = "modified_duration", Value = model.modified_duration });
            parameter.Parameters.Add(new Field { Name = "convexity", Value = model.convexity });
            parameter.Parameters.Add(new Field { Name = "index_ratio", Value = model.index_ratio });
            parameter.Parameters.Add(new Field { Name = "row_number", Value = model.row_number });
            parameter.Parameters.Add(new Field { Name = "data_Id", Value = model.data_Id });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });

            parameter.ResultModelNames.Add("RPRefereceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Import(DateTime asofDate, string settlementDay)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Market_Price_310001_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = asofDate });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = settlementDay });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });

            parameter.ResultModelNames.Add("PaymentMethodResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Remove(DateTime asofDate, string settlementDay)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Market_Price_Tbma_310001_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "asof", Value = asofDate.ToString("dd/MM/yyyy") });
            parameter.Parameters.Add(new Field { Name = "settlement_day", Value = settlementDay });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });

            parameter.ResultModelNames.Add("RPRefereceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
