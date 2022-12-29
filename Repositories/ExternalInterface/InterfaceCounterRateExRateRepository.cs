using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceCounterRateExRateRepository : IRepository<InterfaceCounterRateExRateReqModel>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceCounterRateExRateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(InterfaceCounterRateExRateReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Counter_Insert_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "channel", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "request_id", Value = model.requestID });
            parameter.Parameters.Add(new Field { Name = "service_id", Value = model.serviceID });
            parameter.Parameters.Add(new Field { Name = "return_code", Value = model.ExRateResponse.returnCode });
            parameter.Parameters.Add(new Field { Name = "error_desc", Value = model.ExRateResponse.errorDesc });
            parameter.Parameters.Add(new Field { Name = "ex_date", Value = model.exDate });
            parameter.Parameters.Add(new Field { Name = "ex_round", Value = model.exRound });
            parameter.Parameters.Add(new Field { Name = "ex_currency", Value = model.exCurrency });

            parameter.Parameters.Add(new Field { Name = "bank_note_denom1", Value = model.ExRateResponse.bankNoteDenom1 });
            parameter.Parameters.Add(new Field { Name = "sight_bill_rate1", Value = model.ExRateResponse.sightBillRate1 });
            parameter.Parameters.Add(new Field { Name = "tt_rate1", Value = model.ExRateResponse.ttRate1 });
            parameter.Parameters.Add(new Field { Name = "seling_rate1", Value = model.ExRateResponse.sellingRate1 });
            parameter.Parameters.Add(new Field { Name = "bank_note_buying1", Value = model.ExRateResponse.bankNoteBuying1 });
            parameter.Parameters.Add(new Field { Name = "bank_note_seling1", Value = model.ExRateResponse.bankNoteSelling1 });

            parameter.Parameters.Add(new Field { Name = "bank_note_denom2", Value = model.ExRateResponse.bankNoteDenom2 });
            parameter.Parameters.Add(new Field { Name = "sight_bill_rate2", Value = model.ExRateResponse.sightBillRate2 });
            parameter.Parameters.Add(new Field { Name = "tt_rate2", Value = model.ExRateResponse.ttRate2 });
            parameter.Parameters.Add(new Field { Name = "seling_rate2", Value = model.ExRateResponse.sellingRate2 });
            parameter.Parameters.Add(new Field { Name = "bank_note_buying2", Value = model.ExRateResponse.bankNoteBuying2 });
            parameter.Parameters.Add(new Field { Name = "bank_note_seling2", Value = model.ExRateResponse.bankNoteSelling2 });

            parameter.Parameters.Add(new Field { Name = "bank_note_denom3", Value = model.ExRateResponse.bankNoteDenom3 });
            parameter.Parameters.Add(new Field { Name = "sight_bill_rate3", Value = model.ExRateResponse.sightBillRate3 });
            parameter.Parameters.Add(new Field { Name = "tt_rate3", Value = model.ExRateResponse.ttRate3 });
            parameter.Parameters.Add(new Field { Name = "seling_rate3", Value = model.ExRateResponse.sellingRate3 });
            parameter.Parameters.Add(new Field { Name = "bank_note_buying3", Value = model.ExRateResponse.bankNoteBuying3 });
            parameter.Parameters.Add(new Field { Name = "bank_note_seling3", Value = model.ExRateResponse.bankNoteSelling3 });

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "Console" });
            parameter.ResultModelNames.Add("InterfaceCounterRateExRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<InterfaceCounterRateExRateReqModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceCounterRateExRateReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceCounterRateExRateReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceCounterRateExRateReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Counter_Update_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("InterfaceCounterRateExRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(InterfaceCounterRateExRateReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Counter_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "request_id", Value = model.requestID });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            parameter.ResultModelNames.Add("InterfaceCounterRateExRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<InterfaceCounterRateExRateReqModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
