using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterParty
{

    public class CounterPartyMarginRepository : IRepository<CounterPartyMarginModel>   
    {
        private readonly IUnitOfWork _uow;   
        public CounterPartyMarginRepository(IUnitOfWork uow)    
        {
            _uow = uow;      
        }   

        public ResultWithModel Add(CounterPartyMarginModel model)    
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Margin_820001_Insert_Proc";  
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });   
            parameter.Parameters.Add(new Field { Name = "margin_type_id", Value = model.margin_type_id });   
            parameter.Parameters.Add(new Field { Name = "margin_in_type_id", Value = model.margin_in_type_id });
            parameter.Parameters.Add(new Field { Name = "margin_in_term_id", Value = model.margin_in_term_id });     
            parameter.Parameters.Add(new Field { Name = "threshold", Value = model.threshold });    
            parameter.Parameters.Add(new Field { Name = "borrow_only_flag", Value = model.borrow_only_flag });     
            parameter.Parameters.Add(new Field { Name = "except_margin_flag", Value = model.except_margin_flag });   
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });     
            parameter.Parameters.Add(new Field { Name = "minimum_transfer", Value = model.minimum_transfer });   
            return _uow.ExecNonQueryProc(parameter);   
        }  

        public ResultWithModel AddList(List<CounterPartyMarginModel> models)    
        {
            throw new NotImplementedException();   
        }  

        public ResultWithModel Find(CounterPartyMarginModel model)    
        {
            throw new NotImplementedException();  
        }

        public ResultWithModel Get(CounterPartyMarginModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();  
            parameter.ProcedureName = "GM_Counter_Party_Margin_82001_List_Proc";   
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });     
            parameter.ResultModelNames.Add("CounterPartyMarginResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Margin_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Margin_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "margin_type_id", Value = model.margin_type_id });
            parameter.Parameters.Add(new Field { Name = "margin_in_type_id", Value = model.margin_in_type_id });
            parameter.Parameters.Add(new Field { Name = "margin_in_term_id", Value = model.margin_in_term_id });
            parameter.Parameters.Add(new Field { Name = "threshold", Value = model.threshold });
            parameter.Parameters.Add(new Field { Name = "borrow_only_flag", Value = model.borrow_only_flag });
            parameter.Parameters.Add(new Field { Name = "except_margin_flag", Value = model.except_margin_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "minimum_transfer", Value = model.minimum_transfer });
            parameter.Parameters.Add(new Field { Name = "margin_method", Value = model.margin_method });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyMarginModel> models)
        {
            throw new NotImplementedException();
        }
    }
}