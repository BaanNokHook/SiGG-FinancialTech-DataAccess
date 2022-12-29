using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.ExchRateSummit;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceResExchRateFXSpotRepository : IRepository<InterfaceResExchRateFXSpotDetailModel>
    {
        private readonly IUnitOfWork _uow;

        public InterfaceResExchRateFXSpotRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(InterfaceResExchRateFXSpotDetailModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Summit_Insert_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "seq", Value = model.seq });
            parameter.Parameters.Add(new Field { Name = "as_of_date", Value = model.as_of_date });
            parameter.Parameters.Add(new Field { Name = "curve_id", Value = model.curve_id });
            parameter.Parameters.Add(new Field { Name = "ccy1", Value = model.ccy1 });
            parameter.Parameters.Add(new Field { Name = "ccy2", Value = model.ccy2 });
            parameter.Parameters.Add(new Field { Name = "date", Value = model.date });
            parameter.Parameters.Add(new Field { Name = "tenor", Value = model.tenor });
            parameter.Parameters.Add(new Field { Name = "bid_value", Value = model.bid_value });
            parameter.Parameters.Add(new Field { Name = "ask_value", Value = model.ask_value });
            parameter.Parameters.Add(new Field { Name = "rate_bid", Value = model.rate_bid });
            parameter.Parameters.Add(new Field { Name = "rate_offer", Value = model.rate_offer });
            parameter.Parameters.Add(new Field { Name = "rate_avg", Value = model.rate_avg });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "Console" });
            parameter.ResultModelNames.Add("InterfaceResHeaderTicketSummit");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<InterfaceResExchRateFXSpotDetailModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceResExchRateFXSpotDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceResExchRateFXSpotDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceResExchRateFXSpotDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceResExchRateFXSpotDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceResExchRateFXSpotDetailModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
