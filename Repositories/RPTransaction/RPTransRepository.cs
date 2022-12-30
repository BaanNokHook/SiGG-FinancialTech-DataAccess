using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.RPTransaction
{
    public class RPTransRepository : IRPTransRepository
    {
        private readonly IUnitOfWork _uow;

        public RPTransRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Create_Proc";
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = model.trans_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_id", Value = model.counter_party_fund_id });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "basis_code", Value = model.basis_code });
            parameter.Parameters.Add(new Field { Name = "deal_period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "purchase_price", Value = model.purchase_price });
            parameter.Parameters.Add(new Field { Name = "repurchase_price", Value = model.repurchase_price });
            parameter.Parameters.Add(new Field { Name = "interest_type", Value = model.interest_type });
            parameter.Parameters.Add(new Field { Name = "interest_rate", Value = model.interest_rate });
            parameter.Parameters.Add(new Field { Name = "interest_floating_index_code", Value = model.interest_floating_index_code });
            parameter.Parameters.Add(new Field { Name = "interest_spread", Value = model.interest_spread });
            parameter.Parameters.Add(new Field { Name = "interest_amount", Value = model.interest_amount });
            parameter.Parameters.Add(new Field { Name = "withholding_amount", Value = model.withholding_amount });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund", Value = model.cost_of_fund });
            parameter.Parameters.Add(new Field { Name = "cost_floating_index_code", Value = model.cost_floating_index_code });
            parameter.Parameters.Add(new Field { Name = "cost_type", Value = model.cost_type });
            parameter.Parameters.Add(new Field { Name = "cost_spread", Value = model.cost_spread });
            parameter.Parameters.Add(new Field { Name = "cost_total", Value = model.cost_total });
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = model.trans_status });
            parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "margins_payment_method", Value = model.margins_payment_method });
            parameter.Parameters.Add(new Field { Name = "margins_mt_code", Value = model.margins_mt_code });
            parameter.Parameters.Add(new Field { Name = "threshold", Value = model.threshold });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cur_pair1", Value = model.cur_pair1 });
            parameter.Parameters.Add(new Field { Name = "cur_pair2", Value = model.cur_pair2 });
            parameter.Parameters.Add(new Field { Name = "exch_rate", Value = model.exch_rate });
            parameter.Parameters.Add(new Field { Name = "market_date", Value = model.market_date });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = model.marketdate_t });
            parameter.Parameters.Add(new Field { Name = "market_price", Value = model.market_price });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "desk_book_id", Value = model.desk_book_id });
            parameter.Parameters.Add(new Field { Name = "trans_in_term_id", Value = model.trans_in_term_id });
            parameter.Parameters.Add(new Field { Name = "bilateral_contract_no", Value = model.bilateral_contract_no });
            parameter.Parameters.Add(new Field { Name = "remark_id", Value = model.remark_id });
            parameter.Parameters.Add(new Field { Name = "deal_remark", Value = model.deal_remark });
            parameter.Parameters.Add(new Field { Name = "commentaries", Value = model.commentaries });
            parameter.Parameters.Add(new Field { Name = "correct_remark", Value = model.correct_remark });
            parameter.Parameters.Add(new Field { Name = "cancel_remark", Value = model.cancel_remark });
            parameter.Parameters.Add(new Field { Name = "fo_reject_remark", Value = model.fo_reject_remark });
            parameter.Parameters.Add(new Field { Name = "bo_reject_remark", Value = model.bo_reject_remark });
            parameter.Parameters.Add(new Field { Name = "haircut_formula", Value = model.formula });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "extend", Value = model.extend });
            parameter.Parameters.Add(new Field { Name = "rp_source_value", Value = model.rp_source_value });
            parameter.Parameters.Add(new Field { Name = "isover_limit", Value = model.isover_limit });
            parameter.Parameters.Add(new Field { Name = "ismanual_cal", Value = model.ismanual_cal });
            parameter.Parameters.Add(new Field { Name = "nosto_vosto_code", Value = model.nosto_vosto_code });

            parameter.Parameters.Add(new Field { Name = "net_settement_flag", Value = model.net_settement_flag });
            parameter.Parameters.Add(new Field { Name = "ref_trans_no", Value = model.ref_trans_no });

            parameter.Parameters.Add(new Field { Name = "special_case_id", Value = model.special_case_id });

            ResultWithModel rwm = _uow.ExecNonQueryProc(parameter, "TransNo", out string id);
            if (rwm.Success)
            {
                model.trans_no = id;
                rwm.Data = model;
            }
            return rwm;
        }

        public ResultWithModel Update(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = model.trans_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_id", Value = model.counter_party_fund_id });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "basis_code", Value = model.basis_code });
            parameter.Parameters.Add(new Field { Name = "deal_period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "purchase_price", Value = model.purchase_price });
            parameter.Parameters.Add(new Field { Name = "repurchase_price", Value = model.repurchase_price });
            parameter.Parameters.Add(new Field { Name = "interest_type", Value = model.interest_type });
            parameter.Parameters.Add(new Field { Name = "interest_rate", Value = model.interest_rate });
            parameter.Parameters.Add(new Field { Name = "interest_floating_index_code", Value = model.interest_floating_index_code });
            parameter.Parameters.Add(new Field { Name = "interest_spread", Value = model.interest_spread });
            parameter.Parameters.Add(new Field { Name = "interest_amount", Value = model.interest_amount });
            parameter.Parameters.Add(new Field { Name = "withholding_amount", Value = model.withholding_amount });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund", Value = model.cost_of_fund });
            parameter.Parameters.Add(new Field { Name = "cost_floating_index_code", Value = model.cost_floating_index_code });
            parameter.Parameters.Add(new Field { Name = "cost_type", Value = model.cost_type });
            parameter.Parameters.Add(new Field { Name = "cost_spread", Value = model.cost_spread });
            parameter.Parameters.Add(new Field { Name = "cost_total", Value = model.cost_total });
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = model.trans_status });
            parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "margins_payment_method", Value = model.margins_payment_method });
            parameter.Parameters.Add(new Field { Name = "margins_mt_code", Value = model.margins_mt_code });
            parameter.Parameters.Add(new Field { Name = "threshold", Value = model.threshold });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cur_pair1", Value = model.cur_pair1 });
            parameter.Parameters.Add(new Field { Name = "cur_pair2", Value = model.cur_pair2 });
            parameter.Parameters.Add(new Field { Name = "exch_rate", Value = model.exch_rate });
            parameter.Parameters.Add(new Field { Name = "market_date", Value = model.market_date });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = model.marketdate_t });
            parameter.Parameters.Add(new Field { Name = "market_price", Value = model.market_price });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "desk_book_id", Value = model.desk_book_id });
            parameter.Parameters.Add(new Field { Name = "trans_in_term_id", Value = model.trans_in_term_id });
            parameter.Parameters.Add(new Field { Name = "bilateral_contract_no", Value = model.bilateral_contract_no });
            parameter.Parameters.Add(new Field { Name = "remark_id", Value = model.remark_id });
            parameter.Parameters.Add(new Field { Name = "deal_remark", Value = model.deal_remark });
            parameter.Parameters.Add(new Field { Name = "commentaries", Value = model.commentaries });
            parameter.Parameters.Add(new Field { Name = "correct_remark", Value = model.correct_remark });
            parameter.Parameters.Add(new Field { Name = "cancel_remark", Value = model.cancel_remark });
            parameter.Parameters.Add(new Field { Name = "fo_reject_remark", Value = model.fo_reject_remark });
            parameter.Parameters.Add(new Field { Name = "bo_reject_remark", Value = model.bo_reject_remark });
            parameter.Parameters.Add(new Field { Name = "haircut_formula", Value = model.formula });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "extend", Value = model.extend });
            parameter.Parameters.Add(new Field { Name = "rp_source_value", Value = model.rp_source_value });
            parameter.Parameters.Add(new Field { Name = "isover_limit", Value = model.isover_limit });
            parameter.Parameters.Add(new Field { Name = "ismanual_cal", Value = model.ismanual_cal });
            parameter.Parameters.Add(new Field { Name = "nosto_vosto_code", Value = model.nosto_vosto_code });

            parameter.Parameters.Add(new Field { Name = "net_settement_flag", Value = model.net_settement_flag });
            parameter.Parameters.Add(new Field { Name = "ref_trans_no", Value = model.ref_trans_no });

            parameter.Parameters.Add(new Field { Name = "special_case_id", Value = model.special_case_id });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Remove(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel GetList(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = model.trans_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });
            parameter.Parameters.Add(new Field { Name = "deal_period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = model.trans_status });
            parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "transno", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetDetail(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Detail_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetAddColl(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_AddColl_Proc";
            parameter.Parameters.Add(new Field { Name = "rpPriceSource", Value = model.rp_source_value });
            parameter.Parameters.Add(new Field { Name = "rpPriceDateUI", Value = model.rp_price_date_value });
            parameter.Parameters.Add(new Field { Name = "purchasePrice", Value = model.purchase_price });
            parameter.Parameters.Add(new Field { Name = "instrumentID", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "counterPartyID", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "settleDate", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "matDate", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "formula", Value = model.formula });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });

            parameter.Parameters.Add(new Field { Name = "special_case_id", Value = model.special_case_id });
            parameter.Parameters.Add(new Field { Name = "yearBasis", Value = model.basis_code });
            parameter.Parameters.Add(new Field { Name = "period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "intRate", Value = model.interest_total });
            
            //TODO change ResultModelNames 'RPTransColateralResultModel' to 'RPTransCollateralResultModel'
            parameter.ResultModelNames.Add("RPTransColateralResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CallPrice(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CallPrice_Proc";
            parameter.Parameters.Add(new Field { Name = "purchase_price", Value = model.purchase_price });
            parameter.Parameters.Add(new Field { Name = "period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "wht", Value = model.wht_tax });
            parameter.Parameters.Add(new Field { Name = "yearBasis", Value = model.basis_code });
            parameter.Parameters.Add(new Field { Name = "totalInt", Value = model.interest_total });
            parameter.Parameters.Add(new Field { Name = "counterPartyID", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "instType", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "transType", Value = model.trans_deal_type });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckDate(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CheckDate_Proc";
            parameter.Parameters.Add(new Field { Name = "tradeDate", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlementDate", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "MaturityDate", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "curr", Value = model.cur });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckPeriod(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CheckPeriod_Proc";
            parameter.Parameters.Add(new Field { Name = "tenor", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "tenor_type", Value = model.tenor_type });
            parameter.Parameters.Add(new Field { Name = "settledate", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "transType", Value = model.trans_type });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel BilateralNoGen(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_BilateralNO_Gen_Proc";
            parameter.Parameters.Add(new Field { Name = "instType", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "repoIntType", Value = model.interest_type });
            parameter.Parameters.Add(new Field { Name = "transType", Value = model.trans_type });
            parameter.Parameters.Add(new Field { Name = "period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "tradeDate", Value = model.trade_date });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckCollateral(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CheckCollateral_Proc";
            parameter.Parameters.Add(new Field { Name = "intRate", Value = model.interest_total });
            parameter.Parameters.Add(new Field { Name = "period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "yearBasis", Value = model.basis_code });
            parameter.Parameters.Add(new Field { Name = "wht", Value = model.wht_tax });
            parameter.Parameters.Add(new Field { Name = "settleDate", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "instrumentID", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "rpPriceSource", Value = model.rp_source_value });
            parameter.Parameters.Add(new Field { Name = "rpPriceDateUI", Value = model.rp_price_date_value });
            parameter.Parameters.Add(new Field { Name = "counterPartyID", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "parUnitCol", Value = model.RPTransColateralModel.par_unit });
            parameter.Parameters.Add(new Field { Name = "ytmCol", Value = model.RPTransColateralModel.ytm });
            parameter.Parameters.Add(new Field { Name = "dmCol", Value = model.RPTransColateralModel.dm });
            parameter.Parameters.Add(new Field { Name = "cleanPriceCol", Value = model.RPTransColateralModel.clean_price });
            parameter.Parameters.Add(new Field { Name = "dirtyPriceCol", Value = model.RPTransColateralModel.dirty_price });
            parameter.Parameters.Add(new Field { Name = "hcCol", Value = model.RPTransColateralModel.haircut });
            parameter.Parameters.Add(new Field { Name = "vmCol", Value = model.RPTransColateralModel.variation });
            parameter.Parameters.Add(new Field { Name = "unitCol", Value = model.RPTransColateralModel.unit });
            parameter.Parameters.Add(new Field { Name = "parValCol", Value = model.RPTransColateralModel.par });
            parameter.Parameters.Add(new Field { Name = "secMartketValCol", Value = model.RPTransColateralModel.market_value });
            parameter.Parameters.Add(new Field { Name = "cashAmtCol", Value = model.RPTransColateralModel.cash_amount });
            parameter.Parameters.Add(new Field { Name = "trigger", Value = model.trigger });
            parameter.Parameters.Add(new Field { Name = "formula", Value = model.formula });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "isLastRecord", Value = model.RPTransColateralModel.isLastRecord });
            parameter.Parameters.Add(new Field { Name = "difIntAmt", Value = model.RPTransColateralModel.interest_amount });
            parameter.Parameters.Add(new Field { Name = "diffWhtAmt", Value = model.RPTransColateralModel.wht_amount });
            parameter.Parameters.Add(new Field { Name = "special_case_id", Value = model.RPTransColateralModel.special_case_id });
            //TODO change ResultModelNames 'RPTransColateralResultModel' to 'RPTransCollateralResultModel'
            parameter.ResultModelNames.Add("RPTransColateralResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckLimit(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CheckLimit_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "purchasePrice", Value = model.purchase_price });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.RPTransColateralModel.instrument_id });
            parameter.Parameters.Add(new Field { Name = "cash_amount", Value = model.RPTransColateralModel.cash_amount });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckInterest(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CheckInterest_List_Proc";
            parameter.Parameters.Add(new Field { Name = "transno", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPTransCheckInterestResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckCostOfFund(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CheckCostOfFund_List_Proc";
            parameter.Parameters.Add(new Field { Name = "transno", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPTransCheckCostOfFundResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel PolicyCostOfFund(string cur)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_policy_cost_of_fund_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = cur });
            parameter.ResultModelNames.Add("RPTransCheckCostOfFundResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetInfo(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Info_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetCopyDeal(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_CopyDeal_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetPopupRefno(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Popup_RefNo_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "cur_pair1", Value = model.cur_pair1 });
            parameter.Parameters.Add(new Field { Name = "cur_pair2", Value = model.cur_pair2 });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.counter_party_fund_id });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }
    }
}
