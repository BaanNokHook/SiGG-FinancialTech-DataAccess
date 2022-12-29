using System;
using System.Globalization;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceMarketPriceTbmaRepository : IInterfaceMarketPriceTbmaRepository
    {
        private readonly IUnitOfWork _uow;

        public InterfaceMarketPriceTbmaRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceMarketPriceTbmaDetailModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_FITS_MarketPrice_Tbma_Insert_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_no });
            parameter.Parameters.Add(new Field { Name = "source_name", Value = model.source_name });
            parameter.Parameters.Add(new Field { Name = "security_code", Value = model.security_code });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "market_date_t", Value = model.market_date_t });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "avg_bid_yield", Value = model.avg_bid_yield });
            parameter.Parameters.Add(new Field { Name = "ttm", Value = model.ttm });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "ref_yield", Value = model.ref_yield });
            parameter.Parameters.Add(new Field { Name = "ai_price", Value = model.ai_price });
            parameter.Parameters.Add(new Field { Name = "clean_price", Value = model.clean_price });
            parameter.Parameters.Add(new Field { Name = "gross_price", Value = model.gross_price });
            parameter.Parameters.Add(new Field { Name = "modified_duration", Value = model.modified_duration });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "bond_type", Value = model.bond_type });
            parameter.Parameters.Add(new Field { Name = "coupon_type", Value = model.coupon_type });
            parameter.Parameters.Add(new Field { Name = "last_trade_date", Value = model.last_trade_date });
            parameter.Parameters.Add(new Field { Name = "last_exec_Yield", Value = model.last_exec_Yield });
            parameter.Parameters.Add(new Field { Name = "quoted_date", Value = model.quoted_date });
            parameter.Parameters.Add(new Field { Name = "quoted_yield", Value = model.quoted_yield });
            parameter.Parameters.Add(new Field { Name = "model_yield", Value = model.model_yield });
            parameter.Parameters.Add(new Field { Name = "market_yield", Value = model.market_yield });
            parameter.Parameters.Add(new Field { Name = "dm", Value = model.dm });
            parameter.Parameters.Add(new Field { Name = "par", Value = model.par });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("InterfaceMarketPriceTbmaResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Remove(InterfaceMarketPriceTbmaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_FITS_MarketPrice_Tbma_Update_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "market_date_t", Value = model.market_date_t });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("InterfaceMarketPriceTbmaResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Import(InterfaceMarketPriceTbmaModel model)
        {
            //DateTime asofDate = DateTime.ParseExact(model.asof_date, "yyyyMMdd", CultureInfo.InvariantCulture);
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_FITS_MarketPrice_Tbma_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_no });
            parameter.Parameters.Add(new Field { Name = "market_date_t", Value = model.market_date_t });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            parameter.ResultModelNames.Add("InterfaceMarketPriceTbmaResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Check(InterfaceMarketPriceTbmaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_FITS_MarketPrice_Tbma_Check_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "market_date_t", Value = model.market_date_t });
            parameter.ResultModelNames.Add("InterfaceMarketPriceTbmaResultModel");
            return _uow.ExecDataProc(parameter);
        }
    }
}
