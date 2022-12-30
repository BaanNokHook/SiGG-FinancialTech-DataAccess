using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.MarketProcess;

namespace GM.DataAccess.Repositories.MarketProcess
{
    public class ExchangeRateRepository : IRepository<ExchangeRateModel>
    {
        private readonly IUnitOfWork _uow;

        public ExchangeRateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ExchangeRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Exchange_Rate_320000_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = model.exchange_type != null ? model.exchange_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "source_type", Value = model.source_type != null ? model.source_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "exch_rate", Value = model.exch_rate });
            parameter.Parameters.Add(new Field { Name = "cur1", Value = model.cur1 != null ? model.cur1.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "cur2", Value = model.cur2 != null ? model.cur2.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "MOS1", Value = model.MOS1 != null ? model.MOS1 : null });
            parameter.Parameters.Add(new Field { Name = "MOS2", Value = model.MOS2 != null ? model.MOS2 : null });
            parameter.Parameters.Add(new Field { Name = "MOS3", Value = model.MOS3 != null ? model.MOS3 : null });
            parameter.Parameters.Add(new Field { Name = "MOS6", Value = model.MOS6 != null ? model.MOS6 : null });
            parameter.Parameters.Add(new Field { Name = "MOS9", Value = model.MOS9 != null ? model.MOS9 : null });
            parameter.Parameters.Add(new Field { Name = "YR1", Value = model.YR1 != null ? model.YR1 : null });
            parameter.Parameters.Add(new Field { Name = "YR2", Value = model.YR2 != null ? model.YR2 : null });
            parameter.Parameters.Add(new Field { Name = "YR3", Value = model.YR3 != null ? model.YR3 : null });
            parameter.Parameters.Add(new Field { Name = "YR4", Value = model.YR4 != null ? model.YR4 : null });
            parameter.Parameters.Add(new Field { Name = "YR5", Value = model.YR5 != null ? model.YR5 : null });
            parameter.Parameters.Add(new Field { Name = "YR6", Value = model.YR6 != null ? model.YR6 : null });
            parameter.Parameters.Add(new Field { Name = "YR7", Value = model.YR7 != null ? model.YR7 : null });
            parameter.Parameters.Add(new Field { Name = "YR8", Value = model.YR8 != null ? model.YR8 : null });
            parameter.Parameters.Add(new Field { Name = "YR9", Value = model.YR9 != null ? model.YR9 : null });
            parameter.Parameters.Add(new Field { Name = "YR10", Value = model.YR10 != null ? model.YR10 : null });
            parameter.Parameters.Add(new Field { Name = "TENOR", Value = model.tenor != null ? model.tenor : null });
            parameter.Parameters.Add(new Field { Name = "BID_VALUE", Value = model.bid_value != null ? model.bid_value : null });
            parameter.Parameters.Add(new Field { Name = "ASK_VALUE", Value = model.ask_value != null ? model.ask_value : null });
            parameter.Parameters.Add(new Field { Name = "RATE_BID", Value = model.rate_bid != null ? model.rate_bid : null });
            parameter.Parameters.Add(new Field { Name = "RATE_OFFER", Value = model.rate_offer != null ? model.rate_offer : null });
            parameter.Parameters.Add(new Field { Name = "RATE_AVG", Value = model.rate_avg != null ? model.rate_avg : null });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("ExchangeRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ExchangeRateModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ExchangeRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Exchange_Rate_320000_List_Proc";
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = model.exchange_type != null ? model.exchange_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "source_type", Value = model.source_type != null ? model.source_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "cur1", Value = model.cur1 });
            parameter.Parameters.Add(new Field { Name = "cur2", Value = model.cur2 });
            parameter.ResultModelNames.Add("ExchangeRateResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(ExchangeRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Exchange_Rate_320000_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "source_type", Value = !string.IsNullOrEmpty(model.source_type) ? model.source_type : null });
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = !string.IsNullOrEmpty(model.exchange_type) ? model.exchange_type : null });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("ExchangeRateResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(ExchangeRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Exchange_Rate_320000_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = model.exchange_type != null ? model.exchange_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "source_type", Value = model.source_type != null ? model.source_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "cur1", Value = model.cur1 });
            parameter.Parameters.Add(new Field { Name = "cur2", Value = model.cur2 });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("ExchangeRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(ExchangeRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Exchange_Rate_320000_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "exchange_type", Value = model.exchange_type != null ? model.exchange_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "source_type", Value = model.source_type != null ? model.source_type.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "exch_rate", Value = model.exch_rate });
            parameter.Parameters.Add(new Field { Name = "cur1", Value = model.cur1 != null ? model.cur1.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "cur2", Value = model.cur2 != null ? model.cur2.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "MOS1", Value = model.MOS1 != null ? model.MOS1 : null });
            parameter.Parameters.Add(new Field { Name = "MOS2", Value = model.MOS2 != null ? model.MOS2 : null });
            parameter.Parameters.Add(new Field { Name = "MOS3", Value = model.MOS3 != null ? model.MOS3 : null });
            parameter.Parameters.Add(new Field { Name = "MOS6", Value = model.MOS6 != null ? model.MOS6 : null });
            parameter.Parameters.Add(new Field { Name = "MOS9", Value = model.MOS9 != null ? model.MOS9 : null });
            parameter.Parameters.Add(new Field { Name = "YR1", Value = model.YR1 != null ? model.YR1 : null });
            parameter.Parameters.Add(new Field { Name = "YR2", Value = model.YR2 != null ? model.YR2 : null });
            parameter.Parameters.Add(new Field { Name = "YR3", Value = model.YR3 != null ? model.YR3 : null });
            parameter.Parameters.Add(new Field { Name = "YR4", Value = model.YR4 != null ? model.YR4 : null });
            parameter.Parameters.Add(new Field { Name = "YR5", Value = model.YR5 != null ? model.YR5 : null });
            parameter.Parameters.Add(new Field { Name = "YR6", Value = model.YR6 != null ? model.YR6 : null });
            parameter.Parameters.Add(new Field { Name = "YR7", Value = model.YR7 != null ? model.YR7 : null });
            parameter.Parameters.Add(new Field { Name = "YR8", Value = model.YR8 != null ? model.YR8 : null });
            parameter.Parameters.Add(new Field { Name = "YR9", Value = model.YR9 != null ? model.YR9 : null });
            parameter.Parameters.Add(new Field { Name = "YR10", Value = model.YR10 != null ? model.YR10 : null });
            parameter.Parameters.Add(new Field { Name = "TENOR", Value = model.tenor != null ? model.tenor : null });
            parameter.Parameters.Add(new Field { Name = "BID_VALUE", Value = model.bid_value != null ? model.bid_value : null });
            parameter.Parameters.Add(new Field { Name = "ASK_VALUE", Value = model.ask_value != null ? model.ask_value : null });
            parameter.Parameters.Add(new Field { Name = "RATE_BID", Value = model.rate_bid != null ? model.rate_bid : null });
            parameter.Parameters.Add(new Field { Name = "RATE_OFFER", Value = model.rate_offer != null ? model.rate_offer : null });
            parameter.Parameters.Add(new Field { Name = "RATE_AVG", Value = model.rate_avg != null ? model.rate_avg : null });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "U" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("ExchangeRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<ExchangeRateModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
