using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceThorIndex;
using GM.Model.ExternalInterface.InterfaceThorRate;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class ThorIndexRepository : IRepository<ThorIndexModel>
    {
        private readonly IUnitOfWork _uow;

        public ThorIndexRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ThorIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Index_FITS_Processing_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "thor_date", Value = model.thor_date });
            parameter.Parameters.Add(new Field { Name = "event_date", Value = model.event_date });
            parameter.Parameters.Add(new Field { Name = "next_business_date", Value = model.next_business_date });
            parameter.Parameters.Add(new Field { Name = "thor_rate", Value = model.thor_rate });
            parameter.Parameters.Add(new Field { Name = "day_count", Value = model.day_count });
            parameter.Parameters.Add(new Field { Name = "accrue_daily_compound", Value = model.accrue_daily_compound });
            parameter.Parameters.Add(new Field { Name = "accrue_daily_compound_accum", Value = model.accrue_daily_compound_accum });
            parameter.Parameters.Add(new Field { Name = "day_count_accum_obs", Value = model.day_count_accum_obs });
            parameter.Parameters.Add(new Field { Name = "thor_index_compound_obs", Value = model.thor_index_compound_obs });
            parameter.Parameters.Add(new Field { Name = "thor_index_spread_compound_obs", Value = model.thor_index_spread_compound_obs });
            parameter.Parameters.Add(new Field { Name = "day_count_accum_period", Value = model.day_count_accum_period });
            parameter.Parameters.Add(new Field { Name = "ai_index_buy_sell", Value = model.ai_index_buy_sell });
            parameter.Parameters.Add(new Field { Name = "ai_index_buy_sell_xi", Value = model.ai_index_buy_sell_xi });
            parameter.Parameters.Add(new Field { Name = "ai_index_eod_accum", Value = model.ai_index_eod_accum });
            parameter.Parameters.Add(new Field { Name = "ai_index_eod_daily", Value = model.ai_index_eod_daily });
            parameter.Parameters.Add(new Field { Name = "compound_type", Value = model.compound_type });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "is_holiday", Value = model.is_holiday });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "C" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ThorIndexModel> models)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Find(ThorIndexModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Get(ThorIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Index_FITS_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date_from", Value = model.asof_date_from });
            parameter.Parameters.Add(new Field { Name = "asof_date_to", Value = model.asof_date_to });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "mode", Value = model.mode });
            parameter.ResultModelNames.Add("ThorIndexResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(ThorIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Index_FITS_Processing_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.next_business_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(ThorIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Index_FITS_Processing_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.next_business_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "I" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<ThorIndexModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
