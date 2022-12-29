using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterParty
{
    public class CounterPartyRatingRepository : IRepository<CounterPartyRatingModel>
    {
        private readonly IUnitOfWork _uow;
        public CounterPartyRatingRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(CounterPartyRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Rating_820001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<CounterPartyRatingModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CounterPartyRatingModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(CounterPartyRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Rating_820001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.ResultModelNames.Add("CounterPartyRatingResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Rating_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyRatingModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Rating_820001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "agency_code", Value = model.agency_code });
            parameter.Parameters.Add(new Field { Name = "short_long_term", Value = model.short_long_term });
            parameter.Parameters.Add(new Field { Name = "local_rating", Value = model.local_rating });
            parameter.Parameters.Add(new Field { Name = "foreign_rating", Value = model.foreign_rating });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyRatingModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
