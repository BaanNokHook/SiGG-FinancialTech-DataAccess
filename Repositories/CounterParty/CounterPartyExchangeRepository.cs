using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterParty
{

    public class CounterPartyExchangeRepository : IRepository<CounterPartyExchangeRateModel>  
    {
        private readonly IUnitOfWork _uow;  
        public CounterPartyExchangeRepository(IUnitOfWork uow)  
        {
            _uow = uow;  
        }

        public ResultWithModel Add(CounterPartyExchangeRateModel model)  
        {
            BaseParameterModel parameter = new BaseParameterModel();  
            parameter.ProcedureName = "GM_Counter_Party_Exchange_820001_Insert_Proc";   
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });    
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });  
            parameter.Parameters.Add(new Field { Name = "source_type", Value = model.source_type });  
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = model.exchange_type });  
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });   
            return _uow.ExecNonQueryProc(parameter);  
        }

        public ResultWithModel AddList(List<CounterPartyExchangeRateModel> models)   
        {
            throw new NotImplementedException();   
        }  

        public ResultWithModel Find(CounterPartyExchangeRateModel model)  
        {
            throw new NotImplementedException();   
        }  

        public ResultWithModel Get(CounterPartyExchangeRateModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Exchange_8200001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });   
            parameter.ResultModelNames.Add("CounterPartyExchangeResultModel");  
            parameter.Paging.PageNumber = 1;   
            parameter.Paging.RecordPerPage = 100;  
            parameter.Orders = model.ordersby;  
            return _uow.ExecDataProc(parameter);   
        }  

        public ResultWithModel Remove(CounterPartyExchangeRateModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Exchange_820001_Update_Proc"; 
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyExchRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Exchange_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "source_type", Value = model.source_type });
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = model.exchange_type });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyExchRateModel> models)
        {
            throw new NotImplementedException();
        }
    }
}