using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.RPTransaction
{
    public class RPTransCollateralRepository : IRepository<RPTransCollateralModel>
    {
        private readonly IUnitOfWork _uow;

        public RPTransCollateralRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPTransCollateralModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Coll_Create_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "par", Value = model.par });
            parameter.Parameters.Add(new Field { Name = "unit", Value = model.unit });
            parameter.Parameters.Add(new Field { Name = "ytm", Value = model.ytm });
            parameter.Parameters.Add(new Field { Name = "cash_amount", Value = model.cash_amount });
            parameter.Parameters.Add(new Field { Name = "market_value", Value = model.market_value });
            parameter.Parameters.Add(new Field { Name = "clean_price", Value = model.clean_price });
            parameter.Parameters.Add(new Field { Name = "dirty_price", Value = model.dirty_price });
            parameter.Parameters.Add(new Field { Name = "interest_amount", Value = model.interest_amount });
            parameter.Parameters.Add(new Field { Name = "wht_amount", Value = model.wht_amount });
            parameter.Parameters.Add(new Field { Name = "temination_value", Value = model.temination_value });
            parameter.Parameters.Add(new Field { Name = "dirty_price_after_hc", Value = model.dirty_price_after_hc });
            parameter.Parameters.Add(new Field { Name = "haircut_rate", Value = model.haircut_rate });
            parameter.Parameters.Add(new Field { Name = "haircut", Value = model.haircut });
            parameter.Parameters.Add(new Field { Name = "variation", Value = model.variation });
            parameter.Parameters.Add(new Field { Name = "dm", Value = model.dm });
            parameter.Parameters.Add(new Field { Name = "birat_flag", Value = model.birat_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<RPTransCollateralModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPTransCollateralModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPTransCollateralModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Coll_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            //TODO change ResultModelNames 'RPTransColateralResultModel' to 'RPTransCollateralResultModel'
            parameter.ResultModelNames.Add("RPTransColateralResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPTransCollateralModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Coll_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });

            //if (model.colateral_id != null)
            //{
            //    parameter.Parameters.Add(new Field { Name = "colateral_id", Value = model.colateral_id });
            //}

            if (model.instrument_id != null)
            {
                parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            }

            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(RPTransCollateralModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Deal_110002_Coll_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "colateral_id", Value = model.colateral_id });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "par", Value = model.par });
            parameter.Parameters.Add(new Field { Name = "unit", Value = model.unit });
            parameter.Parameters.Add(new Field { Name = "ytm", Value = model.ytm });
            parameter.Parameters.Add(new Field { Name = "clean_price", Value = model.clean_price });
            parameter.Parameters.Add(new Field { Name = "dirty_price", Value = model.dirty_price });
            parameter.Parameters.Add(new Field { Name = "cash_amount", Value = model.cash_amount });
            parameter.Parameters.Add(new Field { Name = "market_value", Value = model.market_value });
            parameter.Parameters.Add(new Field { Name = "interest_amount", Value = model.interest_amount });
            parameter.Parameters.Add(new Field { Name = "wht_amount", Value = model.wht_amount });
            parameter.Parameters.Add(new Field { Name = "temination_value", Value = model.temination_value });
            parameter.Parameters.Add(new Field { Name = "dirty_price_after_hc", Value = model.dirty_price_after_hc });
            parameter.Parameters.Add(new Field { Name = "haircut_rate", Value = model.haircut_rate });
            parameter.Parameters.Add(new Field { Name = "haircut", Value = model.haircut });
            parameter.Parameters.Add(new Field { Name = "variation", Value = model.variation });
            parameter.Parameters.Add(new Field { Name = "dm", Value = model.dm });
            parameter.Parameters.Add(new Field { Name = "birat_flag", Value = model.birat_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RPTransCollateralModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
