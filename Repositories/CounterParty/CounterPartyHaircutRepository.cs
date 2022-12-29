using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterParty
{

    public class CounterPartyHaircutRepository : IRepository<CounterPartyHaircutModel>  
    {
        private readonly IUnitOfWork _uow;   
        public CounterPartyHaircutRepository(IUnitOfWork uow)   
        {
            _uow = uow;   
        }   

        public ResultWithModel Add(CounterPartyHaircutModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Haircut_820001_Insert_Proc";   
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });  
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });   
            parameter.Parameters.Add(new Field { Name = "formula", Value = model.formula });    
            parameter.Parameters.Add(new Field { Name = "calculate_type", Value = model.calculate_type });   
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });   
            return _uow.ExecNonQueryProc(parameter);    
        }   

        public ResultWithModel AddList(List<CounterPartyHaircutModel> models)    
        {
            throw new NotImplementedException();   
        }   

        public ResultWithModel Find(CounterPartyHaircutModel model)   
        {
            throw new NotImplementedException();  
        }   

        public ResultWithModel Get(CounterPartyHaircutModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Haircut_820001_List_Proc";    
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });  
            parameter.ResultModelNames.Add("CounterPartyHaircutResultModel");  
            parameter.Paging.PageNumber = 1;   
            parameter.Paging.RecordPerPage = 100;   
            parameter.Orders = model.ordersby;  
            return _uow.ExecDataProc(parameter);  
        }   

        public ResultWithModel Remove(CounterPartyHaircutModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();   
            parameter.ProcedureName = "GM_Counter_Party_Haircut_820001_Update_Proc";     
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });     
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });  
            parameter.Parameters.Add(new Field { Name = "formula", Value = "D" });   
            parameter.Parameters.Add(new Field { Name = "calculate_type", Value = model.calculate_type });    
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });     
            return _uow.ExecNonQueryProc(parameter);   
        
        }   

        public ResultWithModel UpdateList(List<CounterPartyHaircutModel> models)    
        {
            throw new NotImplementedException();   
        }   
    }
}