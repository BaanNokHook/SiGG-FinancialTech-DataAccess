using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceEquitySymbol;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceEquitySymbolRepository : IInterfaceEquitySymbolRepository
    {
        private readonly IUnitOfWork _uow;
        public InterfaceEquitySymbolRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqEquitySymbolList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Equity_Symbol_Insert_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_no });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "instrument_desc", Value = model.instrument_desc });
            parameter.Parameters.Add(new Field { Name = "market_id", Value = model.market_id });
            parameter.Parameters.Add(new Field { Name = "product_code", Value = model.product_code });
            parameter.Parameters.Add(new Field { Name = "instrumenttype", Value = model.instrumenttype });
            parameter.Parameters.Add(new Field { Name = "sub_product_code", Value = model.sub_product_code });
            parameter.Parameters.Add(new Field { Name = "second_instrumenttype", Value = model.second_instrumenttype });
            parameter.Parameters.Add(new Field { Name = "issue_date", Value = model.issue_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "register_id", Value = model.register_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "begining_par", Value = model.begining_par });
            parameter.Parameters.Add(new Field { Name = "ending_par", Value = model.ending_par });
            parameter.Parameters.Add(new Field { Name = "min_unit", Value = model.min_unit });
            parameter.Parameters.Add(new Field { Name = "max_unit", Value = model.max_unit });
            parameter.Parameters.Add(new Field { Name = "incremental_unit", Value = model.incremental_unit });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "ISIN_code_TH", Value = model.ISIN_code_TH });
            parameter.Parameters.Add(new Field { Name = "ISIN_CODE_FR", Value = model.ISIN_CODE_FR });
            parameter.Parameters.Add(new Field { Name = "ISIN_CODE_NVDR", Value = model.ISIN_CODE_NVDR });
            parameter.Parameters.Add(new Field { Name = "listed_flag", Value = model.listed_flag });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.Parameters.Add(new Field { Name = "create_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "update_date", Value = model.update_date });
            parameter.Parameters.Add(new Field { Name = "update_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "address", Value = model.address });
            parameter.Parameters.Add(new Field { Name = "tel_no", Value = model.tel_no });
            parameter.Parameters.Add(new Field { Name = "fax_no", Value = model.fax_no });
            parameter.Parameters.Add(new Field { Name = "web_site", Value = model.web_site });
            parameter.Parameters.Add(new Field { Name = "authorized_share_capital", Value = model.authorized_share_capital });
            parameter.Parameters.Add(new Field { Name = "paid_up_capital", Value = model.paid_up_capital });
            parameter.Parameters.Add(new Field { Name = "authorized_share", Value = model.authorized_share });
            parameter.Parameters.Add(new Field { Name = "paid_up_share", Value = model.paid_up_share });
            parameter.Parameters.Add(new Field { Name = "remark", Value = model.remark });
            parameter.Parameters.Add(new Field { Name = "industry_group_id", Value = model.industry_group_id });
            parameter.Parameters.Add(new Field { Name = "industry_sector_id", Value = model.industry_sector_id });
            parameter.Parameters.Add(new Field { Name = "ktb_flag", Value = model.ktb_flag });
            parameter.Parameters.Add(new Field { Name = "ktb_holding_unit", Value = model.ktb_holding_unit });
            parameter.Parameters.Add(new Field { Name = "ktb_holding_percent", Value = model.ktb_holding_percent });
            parameter.Parameters.Add(new Field { Name = "ktb_holding_amount", Value = model.ktb_holding_amount });
            parameter.Parameters.Add(new Field { Name = "domestic_flag", Value = model.domestic_flag });
            parameter.Parameters.Add(new Field { Name = "p_e", Value = model.p_e });
            parameter.Parameters.Add(new Field { Name = "p_pv", Value = model.p_pv });
            parameter.Parameters.Add(new Field { Name = "market_cap", Value = model.market_cap });
            parameter.Parameters.Add(new Field { Name = "dividen_policy", Value = model.dividen_policy });
            parameter.Parameters.Add(new Field { Name = "listed_share", Value = model.listed_share });
            parameter.Parameters.Add(new Field { Name = "dividend_yeild", Value = model.dividend_yeild });
            parameter.Parameters.Add(new Field { Name = "p_nav", Value = model.p_nav });
            parameter.Parameters.Add(new Field { Name = "redemption_method_id", Value = model.redemption_method_id });
            parameter.Parameters.Add(new Field { Name = "redemption_value", Value = model.redemption_value });
            parameter.Parameters.Add(new Field { Name = "redemption_percent", Value = model.redemption_percent });
            parameter.Parameters.Add(new Field { Name = "InvestmentGroup", Value = model.InvestmentGroup });
            parameter.Parameters.Add(new Field { Name = "cfo_garantee_flag", Value = model.cfo_garantee_flag });
            parameter.Parameters.Add(new Field { Name = "set50_flag", Value = model.set50_flag });
            parameter.Parameters.Add(new Field { Name = "set100_flag", Value = model.set100_flag });
            parameter.Parameters.Add(new Field { Name = "devalue", Value = model.devalue });
            parameter.Parameters.Add(new Field { Name = "bloomberg_code", Value = model.bloomberg_code });
            parameter.Parameters.Add(new Field { Name = "risk_weight", Value = model.risk_weight });
            parameter.Parameters.Add(new Field { Name = "rwa_code", Value = model.rwa_code });
            parameter.Parameters.Add(new Field { Name = "new_instrument_code", Value = model.new_instrument_code });
            parameter.Parameters.Add(new Field { Name = "parent_id", Value = model.parent_id });
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "regista_id", Value = model.regista_id });
            parameter.Parameters.Add(new Field { Name = "underlying", Value = model.underlying });
            parameter.Parameters.Add(new Field { Name = "exercise_price", Value = model.exercise_price });
            parameter.Parameters.Add(new Field { Name = "Company_Investment_Type_Code", Value = model.Company_Investment_Type_Code });
            parameter.Parameters.Add(new Field { Name = "trade_dt", Value = model.trade_dt });
            parameter.Parameters.Add(new Field { Name = "settlement_dt", Value = model.settlement_dt });
            parameter.Parameters.Add(new Field { Name = "fo_verify_flag", Value = model.fo_verify_flag });
            parameter.Parameters.Add(new Field { Name = "bo_verify_flag", Value = model.bo_verify_flag });
            parameter.Parameters.Add(new Field { Name = "trader_costcenter", Value = model.trader_costcenter });
            parameter.Parameters.Add(new Field { Name = "ifrs_instrument_type", Value = model.ifrs_instrument_type });
            parameter.Parameters.Add(new Field { Name = "ifrs_measurement_type", Value = model.ifrs_measurement_type });
            parameter.Parameters.Add(new Field { Name = "ifrs_readonly_flag", Value = model.ifrs_readonly_flag });
            parameter.Parameters.Add(new Field { Name = "xe_old_share", Value = model.xe_old_share });
            parameter.Parameters.Add(new Field { Name = "xe_new_share", Value = model.xe_new_share });
            parameter.Parameters.Add(new Field { Name = "tax_type_id", Value = model.tax_type_id });
            parameter.Parameters.Add(new Field { Name = "Market_Price_Multiplier", Value = model.Market_Price_Multiplier });
            parameter.Parameters.Add(new Field { Name = "GL_Backdate_Flag", Value = model.GL_Backdate_Flag });
            parameter.Parameters.Add(new Field { Name = "SP_Flag", Value = model.SP_Flag });
            parameter.Parameters.Add(new Field { Name = "limit_percent", Value = model.limit_percent });
            parameter.Parameters.Add(new Field { Name = "import_by", Value = model.import_by });
 
            parameter.ResultModelNames.Add("EquitySymbolResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Import(ReqEquitySymbol model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Equity_Symbol_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.datas.ref_no });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.datas.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.datas.create_by });

            parameter.ResultModelNames.Add("EquitySymbolResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Remove(ReqEquitySymbol model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Equity_Symbol_Update_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.datas.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.datas.create_by });

            parameter.ResultModelNames.Add("EquitySymbolResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
