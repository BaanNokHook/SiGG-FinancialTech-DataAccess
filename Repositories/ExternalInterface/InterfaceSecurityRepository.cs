using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceSecurity;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceSecurityRepository : IRepository<ReqSecurityList>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceSecurityRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqSecurityList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Temp_810001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_code", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "instrument_desc", Value = model.instrument_desc });
            parameter.Parameters.Add(new Field { Name = "ISIN_code", Value = model.ISIN_code });
            parameter.Parameters.Add(new Field { Name = "product_code", Value = model.product_code });
            parameter.Parameters.Add(new Field { Name = "instrumenttype", Value = model.instrumenttype });
            parameter.Parameters.Add(new Field { Name = "sub_product_code", Value = model.sub_product_code });
            parameter.Parameters.Add(new Field { Name = "second_instrumenttype", Value = model.second_instrumenttype });
            parameter.Parameters.Add(new Field { Name = "issue_date", Value = model.issue_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "include_issue_date_flag", Value = model.include_issue_date_flag });
            parameter.Parameters.Add(new Field { Name = "xa_day", Value = model.xa_day });
            parameter.Parameters.Add(new Field { Name = "xi_day", Value = model.xi_day });
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "issuer_code", Value = model.issuer_code });
            parameter.Parameters.Add(new Field { Name = "register_id", Value = model.register_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "begining_par", Value = model.begining_par });
            parameter.Parameters.Add(new Field { Name = "ending_par", Value = model.ending_par });
            parameter.Parameters.Add(new Field { Name = "min_unit", Value = model.min_unit });
            parameter.Parameters.Add(new Field { Name = "max_unit", Value = model.max_unit });
            parameter.Parameters.Add(new Field { Name = "incremental_unit", Value = model.incremental_unit });
            parameter.Parameters.Add(new Field { Name = "secured_bond_flag", Value = model.secured_bond_flag });
            parameter.Parameters.Add(new Field { Name = "holiday_rule_cur", Value = model.holiday_rule_cur });
            parameter.Parameters.Add(new Field { Name = "TBMA_listed_reference", Value = model.TBMA_listed_reference });
            parameter.Parameters.Add(new Field { Name = "redemption_method_id", Value = model.redemption_method_id });
            parameter.Parameters.Add(new Field { Name = "redemption_freq", Value = model.redemption_freq });
            parameter.Parameters.Add(new Field { Name = "redemption_day", Value = model.redemption_day });
            parameter.Parameters.Add(new Field { Name = "redemption_month", Value = model.redemption_month });
            parameter.Parameters.Add(new Field { Name = "redemption_date_rule", Value = model.redemption_date_rule });
            parameter.Parameters.Add(new Field { Name = "redemption_payment_date_rule", Value = model.redemption_payment_date_rule });
            parameter.Parameters.Add(new Field { Name = "redemption_value", Value = model.redemption_value });
            parameter.Parameters.Add(new Field { Name = "redemption_percent", Value = model.redemption_percent });
            parameter.Parameters.Add(new Field { Name = "coupon_type", Value = model.coupon_type });
            parameter.Parameters.Add(new Field { Name = "coupon_freq", Value = model.coupon_freq });
            parameter.Parameters.Add(new Field { Name = "coupon_freq_time", Value = model.coupon_freq_time });
            parameter.Parameters.Add(new Field { Name = "coupon_day", Value = model.coupon_day });
            parameter.Parameters.Add(new Field { Name = "coupon_month", Value = model.coupon_month });
            parameter.Parameters.Add(new Field { Name = "coupon_date_rule", Value = model.coupon_date_rule });
            parameter.Parameters.Add(new Field { Name = "coupon_payment_date_rule", Value = model.coupon_payment_date_rule });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "floating_index_code", Value = model.floating_index_code });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "accrued_calc_rule_id", Value = model.accrued_calc_rule_id });
            parameter.Parameters.Add(new Field { Name = "accrued_basis", Value = model.accrued_basis });
            parameter.Parameters.Add(new Field { Name = "year_basis", Value = model.year_basis });
            parameter.Parameters.Add(new Field { Name = "floating_index_cur", Value = model.floating_index_cur });
            parameter.Parameters.Add(new Field { Name = "option_type", Value = model.option_type });
            parameter.Parameters.Add(new Field { Name = "seniority_type", Value = model.seniority_type });
            parameter.Parameters.Add(new Field { Name = "tax_on_coupon_flag", Value = model.tax_on_coupon_flag });
            parameter.Parameters.Add(new Field { Name = "ex_coupon_flag", Value = model.ex_coupon_flag });
            parameter.Parameters.Add(new Field { Name = "accumulate_interest_flag", Value = model.accumulate_interest_flag });
            parameter.Parameters.Add(new Field { Name = "payment_freq", Value = model.payment_freq });
            parameter.Parameters.Add(new Field { Name = "issue_size", Value = model.issue_size });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "check_mat_coupon_flag", Value = model.check_mat_coupon_flag });
            parameter.Parameters.Add(new Field { Name = "int_cf_flag", Value = model.int_cf_flag });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.Parameters.Add(new Field { Name = "create_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "update_date", Value = model.update_date });
            parameter.Parameters.Add(new Field { Name = "update_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "boomberg_code", Value = model.boomberg_code });
            parameter.Parameters.Add(new Field { Name = "verify_flag", Value = model.verify_flag });
            parameter.Parameters.Add(new Field { Name = "int_cf_manual_flag", Value = model.int_cf_manual_flag });
            parameter.Parameters.Add(new Field { Name = "redemption_type", Value = model.redemption_type });
            parameter.Parameters.Add(new Field { Name = "instrument_owner", Value = model.instrument_owner });
            parameter.Parameters.Add(new Field { Name = "crm_code", Value = model.crm_code });
            parameter.Parameters.Add(new Field { Name = "ISIN_code_Thai", Value = model.ISIN_code_Thai });
            parameter.Parameters.Add(new Field { Name = "verify_flag_bo", Value = model.verify_flag_bo });
            parameter.Parameters.Add(new Field { Name = "check_merge_flag", Value = model.check_merge_flag });
            parameter.Parameters.Add(new Field { Name = "market_code", Value = model.market_code });
            parameter.Parameters.Add(new Field { Name = "default_flag", Value = model.default_flag });
            parameter.Parameters.Add(new Field { Name = "instrument_group", Value = model.instrument_group });
            parameter.Parameters.Add(new Field { Name = "source_system", Value = model.source_system });
            parameter.ResultModelNames.Add("SecurityResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ReqSecurityList> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ReqSecurityList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ReqSecurityList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(ReqSecurityList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ReqSecurityList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<ReqSecurityList> models)
        {
            throw new NotImplementedException();
        }
    }
}
