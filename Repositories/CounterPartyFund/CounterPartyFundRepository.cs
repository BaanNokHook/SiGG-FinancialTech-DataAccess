using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterPartyFund
{
    public class CounterPartyFundRepository : IRepository<CounterPartyFundModel>
    {
        private readonly IUnitOfWork _uow;
        public CounterPartyFundRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(CounterPartyFundModel model)  
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Fund_82003_Insert_Proc";   

            #region Parameter  
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });   
            parameter.Parameters.Add(new Field { Name = "fund_code", Value = model.fund_code });  
            parameter.Parameters.Add(new Field { Name = "fund_thainame", Vaule = model.fund_thainame });  
            parameter.Parameters.Add(new Field { Name = "fund_engname", Value = model.fund_engname });
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "swift_code", Value = model.swift_code });
            parameter.Parameters.Add(new Field { Name = "bb_firm_acc", Value = model.bb_firm_acc });
            parameter.Parameters.Add(new Field { Name = "bic_code_fund", Value = model.bic_code_fund });
            parameter.Parameters.Add(new Field { Name = "sa_account_no", Value = model.sa_account_no });
            parameter.Parameters.Add(new Field { Name = "ca_account_no", Value = model.ca_account_no });
            parameter.Parameters.Add(new Field { Name = "group_tax_code", Value = model.group_tax_code });
            parameter.Parameters.Add(new Field { Name = "wth_tax_percent", Value = model.wth_tax_percent });
            parameter.Parameters.Add(new Field { Name = "tax_id", Value = model.tax_id });
            parameter.Parameters.Add(new Field { Name = "title", Value = model.title });
            parameter.Parameters.Add(new Field { Name = "first_name", Value = model.first_name });
            parameter.Parameters.Add(new Field { Name = "middle_name", Value = model.middle_name });
            parameter.Parameters.Add(new Field { Name = "last_name", Value = model.last_name });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "cif_no", Value = model.cif_no });
            #endregion

            ResultWithModel rwm = _uow.ExecNonQueryProc(parameter, "FundID", out var id);
            if (rwm.Success)
            {
                model.fund_id = Convert.ToInt32(id);
                rwm.Data = model;
            }

            return rwm;
        }

        public ResultWithModel AddList(List<CounterPartyFundModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CounterPartyFundModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Insument_Name_820003_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.ResultModelNames.Add("CounterPartyFundResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 1;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(CounterPartyFundModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_820003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "fund_code", Value = model.fund_code });
            parameter.ResultModelNames.Add("CounterPartyFundResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyFundModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.Parameters.Clear();
            parameter.ProcedureName = "GM_Counter_Party_Fund_820003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyFundModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_820003_Update_Proc";

            #region Parameter
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "fund_code", Value = model.fund_code });
            parameter.Parameters.Add(new Field { Name = "fund_thainame", Value = model.fund_thainame });
            parameter.Parameters.Add(new Field { Name = "fund_engname", Value = model.fund_engname });
            parameter.Parameters.Add(new Field { Name = "custodian_id", Value = model.custodian_id });
            parameter.Parameters.Add(new Field { Name = "swift_code", Value = model.swift_code });
            parameter.Parameters.Add(new Field { Name = "bb_firm_acc", Value = model.bb_firm_acc });
            parameter.Parameters.Add(new Field { Name = "bic_code_fund", Value = model.bic_code_fund });
            parameter.Parameters.Add(new Field { Name = "sa_account_no", Value = model.sa_account_no });
            parameter.Parameters.Add(new Field { Name = "ca_account_no", Value = model.ca_account_no });
            parameter.Parameters.Add(new Field { Name = "group_tax_code", Value = model.group_tax_code });
            parameter.Parameters.Add(new Field { Name = "wth_tax_percent", Value = model.wth_tax_percent });
            parameter.Parameters.Add(new Field { Name = "tax_id", Value = model.tax_id });
            parameter.Parameters.Add(new Field { Name = "title", Value = model.title });
            parameter.Parameters.Add(new Field { Name = "first_name", Value = model.first_name });
            parameter.Parameters.Add(new Field { Name = "middle_name", Value = model.middle_name });
            parameter.Parameters.Add(new Field { Name = "last_name", Value = model.last_name });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "cif_no", Value = model.cif_no });
            #endregion
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyFundModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
