using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceNavPrice;
using System;
using System.Collections.Generic;
using System.Text;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceNavPriceEquityRepository : IInterfaceNavPriceEquityRepository
    {
        private readonly IUnitOfWork _uow;

        public InterfaceNavPriceEquityRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceReqNavPriceModel reqModel, InterfaceResNavPriceListModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_EQUITY_NavPrice_Insert_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "ref_no", Value = reqModel.ref_no });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = reqModel.asof_date });
            parameter.Parameters.Add(new Field { Name = "market", Value = model.market });
            parameter.Parameters.Add(new Field { Name = "symbols", Value = model.symbols });
            parameter.Parameters.Add(new Field { Name = "last_bid", Value = model.last_bid });
            parameter.Parameters.Add(new Field { Name = "last_ask", Value = model.last_ask });
            parameter.Parameters.Add(new Field { Name = "price_close", Value = model.price_close });
            parameter.Parameters.Add(new Field { Name = "date", Value = model.date });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.Parameters.Add(new Field { Name = "create_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "update_date", Value = model.update_date });
            parameter.Parameters.Add(new Field { Name = "update_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "price_avg", Value = model.price_avg });
            parameter.Parameters.Add(new Field { Name = "price_floor", Value = model.price_floor });
            parameter.Parameters.Add(new Field { Name = "price_ceiling", Value = model.price_ceiling });
            parameter.Parameters.Add(new Field { Name = "price_highest", Value = model.price_highest });
            parameter.Parameters.Add(new Field { Name = "price_lowest", Value = model.price_lowest });
            parameter.Parameters.Add(new Field { Name = "volume_unit", Value = model.volume_unit });
            parameter.Parameters.Add(new Field { Name = "volume_amount", Value = model.volume_amount });
            parameter.Parameters.Add(new Field { Name = "volume_buy", Value = model.volume_buy });
            parameter.Parameters.Add(new Field { Name = "volume_sell", Value = model.volume_sell });
            parameter.Parameters.Add(new Field { Name = "price_open", Value = model.price_open });
            parameter.Parameters.Add(new Field { Name = "last_update", Value = model.last_update });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "nav_price", Value = model.nav_price });
            parameter.Parameters.Add(new Field { Name = "book_price", Value = model.book_price });
            parameter.Parameters.Add(new Field { Name = "import_by", Value = reqModel.create_by });

            parameter.ResultModelNames.Add("NavPriceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Check(InterfaceReqNavPriceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_EQUITY_NavPrice_Check_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.ResultModelNames.Add("InterfaceNavPriceResultModel");
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Import(InterfaceReqNavPriceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Interface_EQUITY_NavPrice_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_no });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("NavPriceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Remove(InterfaceReqNavPriceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Interface_EQUITY_NavPrice_Update_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("NavPriceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
