using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterPartyFund
{
   
    public class CounterPartyFundMarginRepository : IRepository<CounterPartyFundMarginModel>   
    {
        private readonly IUnitOfWork -uow;   
        public CounterPartyFundMargingRepository(IUnitOfWork uow)   
        {
            _uow = uow;   
        }   

        public ResultWithModel Add(CounterPartyFundMarginModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();    
            parameter.ProcedureName = "GM_Counter_Party_Fund_Margin_82003_Insert_Proc";  
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });    
            parameter.Parameters.Add(new Field { Name = "margin_type_id", Value = model.counter_party_id });     
            parameter.Parameters.Add(new Field { Name = "margin_type_id", Value = model.margin_type_id });  
            parameter.Parameters.Add(new Field { Name = "margin_in_term_id", Value = model.margin_in_term_id });   
            parameter.Parameters.Add(new Field { Name = "threshold", Value = model.threshold });    
            parameter.Parameters.Add(new Field { Name = "borrow_only_flag", Value = model.borrow_only_flag });    
            parameter.Parameters.Add(new Field { Name = "except_margin_flag". Value = model.except_margin_flag });   
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });   
            return _uow.ExecNonQueryProc(parameter);               
        }

        public ResultWithModel AddList(List<CounterPartyFundMArginModel> models)    
        {
            throw new NotImplementedException();   
        }   

        public ResultWithModel Find(CounterPartyFundMarginModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(CounterPartyFundMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Margin_820003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.ResultModelNames.Add("CounterPartyFundMarginResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyFundMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Margin_820003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyFundMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Margin_820003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "margin_type_id", Value = model.margin_type_id });
            parameter.Parameters.Add(new Field { Name = "margin_in_type_id", Value = model.margin_in_type_id });
            parameter.Parameters.Add(new Field { Name = "margin_in_term_id", Value = model.margin_in_term_id });
            parameter.Parameters.Add(new Field { Name = "threshold", Value = model.threshold });
            parameter.Parameters.Add(new Field { Name = "borrow_only_flag", Value = model.borrow_only_flag });
            parameter.Parameters.Add(new Field { Name = "except_margin_flag", Value = model.except_margin_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyFundMarginModel> models)
        {
            throw new NotImplementedException();
        }
    }
}