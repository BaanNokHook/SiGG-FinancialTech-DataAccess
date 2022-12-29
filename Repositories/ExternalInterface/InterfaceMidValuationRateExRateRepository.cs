using System;
using System.Collections.Generic;
using System.Text;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceMidValuationRateExRateRepository : IRepository<InterfaceMidValuationRateExRateReqModel>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceMidValuationRateExRateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceMidValuationRateExRateReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Mid_Valuation_Insert_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "channel", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "request_id", Value = model.requestID });
            parameter.Parameters.Add(new Field { Name = "service_id", Value = model.serviceID });
            parameter.Parameters.Add(new Field { Name = "return_code", Value = model.ExRateResponse.returnCode });
            parameter.Parameters.Add(new Field { Name = "error_desc", Value = model.ExRateResponse.errorDesc });
            parameter.Parameters.Add(new Field { Name = "ex_date", Value = model.exDate });
            parameter.Parameters.Add(new Field { Name = "ex_round", Value = model.exRound });

            parameter.Parameters.Add(new Field { Name = "MOS1", Value = model.ExRateResponse.mos1 });
            parameter.Parameters.Add(new Field { Name = "MOS2", Value = model.ExRateResponse.mos2 });
            parameter.Parameters.Add(new Field { Name = "MOS3", Value = model.ExRateResponse.mos3 });
            parameter.Parameters.Add(new Field { Name = "MOS6", Value = model.ExRateResponse.mos6 });
            parameter.Parameters.Add(new Field { Name = "MOS9", Value = model.ExRateResponse.mos9 });
            parameter.Parameters.Add(new Field { Name = "YR1", Value = model.ExRateResponse.yr1 });
            parameter.Parameters.Add(new Field { Name = "YR2", Value = model.ExRateResponse.yr2 });
            parameter.Parameters.Add(new Field { Name = "YR3", Value = model.ExRateResponse.yr3 });
            parameter.Parameters.Add(new Field { Name = "YR4", Value = model.ExRateResponse.yr4 });
            parameter.Parameters.Add(new Field { Name = "YR5", Value = model.ExRateResponse.yr5 });
            parameter.Parameters.Add(new Field { Name = "YR6", Value = model.ExRateResponse.yr6 });
            parameter.Parameters.Add(new Field { Name = "YR7", Value = model.ExRateResponse.yr7 });
            parameter.Parameters.Add(new Field { Name = "YR8", Value = model.ExRateResponse.yr8 });
            parameter.Parameters.Add(new Field { Name = "YR9", Value = model.ExRateResponse.yr9 });
            parameter.Parameters.Add(new Field { Name = "YR10", Value = model.ExRateResponse.yr10 });

            parameter.Parameters.Add(new Field { Name = "ex_currency", Value = model.ExRateResponse.currency });
            parameter.Parameters.Add(new Field { Name = "ex_currency2", Value = model.ExRateResponse.currency2 });
            parameter.Parameters.Add(new Field { Name = "mid_rate", Value = model.ExRateResponse.midRate });

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "Console" });

            parameter.ResultModelNames.Add("InterfaceMidValuationRateExRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<InterfaceMidValuationRateExRateReqModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceMidValuationRateExRateReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceMidValuationRateExRateReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceMidValuationRateExRateReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Mid_Valuation_Update_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "exRound", Value = model.exRound });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("InterfaceMidValuationRateExRateResult");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(InterfaceMidValuationRateExRateReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Mid_Valuation_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "request_id", Value = model.requestID });
            parameter.Parameters.Add(new Field { Name = "type", Value = model.type });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });

            parameter.ResultModelNames.Add("InterfaceCounterRateExRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<InterfaceMidValuationRateExRateReqModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
