using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.CounterPartyFund
{

    public class CounterPartyFundPaymentRepository : IRepository<CounterPartyFundPaymentModel>   
    {
        private readonly IUnitOfWork _uow;   
        public CounterPartyFundPaymentRepository(IUnitOfWork uow)   
        {
            _uow = uow;   
        }    

        public ResultWithModel Add(CounterPartyFundPaymentModel model)   
        {
            BaseParameterModel parameter = new BaseParameterModel();  
            parameter.ProcedureName = "GM_Counter_Party_Fund_Payment_82003_Insert_Proc";   
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "bank_code", Value = model.bank_code });
            parameter.Parameters.Add(new Field { Name = "account_number", Value = model.account_number });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "nosto_vosto_code", Value = model.nosto_vosto_code });
            parameter.Parameters.Add(new Field { Name = "ca_no", Value = model.ca_no });
            parameter.Parameters.Add(new Field { Name = "sa_no", Value = model.sa_no });
            parameter.Parameters.Add(new Field { Name = "participant_id", Value = model.participant_id });
            parameter.Parameters.Add(new Field { Name = "default_flag", Value = model.default_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<>)
         public ResultWithModel AddList(List<CounterPartyFundPaymentModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CounterPartyFundPaymentModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(CounterPartyFundPaymentModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Payment_820003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.ResultModelNames.Add("CounterPartyFundPaymentResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CounterPartyFundPaymentModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Payment_820003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "bank_code", Value = model.bank_code });
            parameter.Parameters.Add(new Field { Name = "account_number", Value = model.account_number });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CounterPartyFundPaymentModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Counter_Party_Fund_Payment_820003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "fund_id", Value = model.fund_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "bank_code", Value = model.bank_code });
            parameter.Parameters.Add(new Field { Name = "account_number", Value = model.account_number });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "nosto_vosto_code", Value = model.nosto_vosto_code });
            parameter.Parameters.Add(new Field { Name = "ca_no", Value = model.ca_no });
            parameter.Parameters.Add(new Field { Name = "sa_no", Value = model.sa_no });
            parameter.Parameters.Add(new Field { Name = "participant_id", Value = model.participant_id });
            parameter.Parameters.Add(new Field { Name = "default_flag", Value = model.default_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CounterPartyFundPaymentModel> models)
        {
            throw new NotImplementedException();
        }
    }
}