using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterParty
{
    public class CounterPartyIdentifyRepository : IRepository<CounterPartyIdentifyModel>
    {
        private readonly IUnitOfWork _uow;
        public CounterPartyIdentifyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(CounterPartyIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Identify_820001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "unique_id", Value = model.unique_id });
            parameter.Parameters.Add(new Field { Name = "identify_no", Value = model.identify_no });
            parameter.Parameters.Add(new Field { Name = "juris_reg_date", Value = model.juris_reg_date });
            parameter.Parameters.Add(new Field { Name = "reg_bus_ename", Value = model.reg_bus_ename });
            parameter.Parameters.Add(new Field { Name = "reg_bus_tname", Value = model.reg_bus_tname });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<CounterPartyIdentifyModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CounterPartyIdentifyModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(CounterPartyIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Identify_820001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.ResultModelNames.Add("CounterPartyIdentifyResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Identify_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "unique_id", Value = model.unique_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Identify_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "unique_id", Value = model.unique_id });
            parameter.Parameters.Add(new Field { Name = "identify_no", Value = model.identify_no });
            parameter.Parameters.Add(new Field { Name = "juris_reg_date", Value = model.juris_reg_date });
            parameter.Parameters.Add(new Field { Name = "reg_bus_ename", Value = model.reg_bus_ename });
            parameter.Parameters.Add(new Field { Name = "reg_bus_tname", Value = model.reg_bus_tname });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyIdentifyModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
