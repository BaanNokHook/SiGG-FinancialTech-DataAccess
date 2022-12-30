using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPConfirmationRepositrory : IRPConfirmationRepositrory
    {
        private readonly IUnitOfWork _uow;

        public RPConfirmationRepositrory(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPConfirmationModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<RPConfirmationModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPConfirmationModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Confirmation_Sign_Name_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = model.recorded_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPConfirmationResultModel");
            parameter.Paging = new PagingModel(){PageNumber = 0, RecordPerPage = 0};
            return _uow.ExecDataProc(parameter);
        }
        
        public ResultWithModel Get(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Confirmation_210004_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = model.trans_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });
            parameter.Parameters.Add(new Field { Name = "deal_period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = model.trans_status });
            parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(RPConfirmationModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(RPConfirmationModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPConfirmationModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Confirmation_Sign_Name_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "print_confirm_bo1_by", Value = model.print_confirm_bo1_by });
            parameter.Parameters.Add(new Field { Name = "print_confirm_bo2_by", Value = model.print_confirm_bo2_by });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });

            parameter.ResultModelNames.Add("RPConfirmationResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RPConfirmationModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
