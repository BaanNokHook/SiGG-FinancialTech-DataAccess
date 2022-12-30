using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPConfirmationBilateralRepositrory : IRepository<RPTransModel>
    {
        private readonly IUnitOfWork _uow;

        public RPConfirmationBilateralRepositrory(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<RPTransModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_210002_Confirm_Message_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "message_type", Value = model.message_type });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_210002_Confirm_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            if (model.policy_date != null)
            {
                parameter.Parameters.Add(new Field { Name = "policy_date", Value = DateTime.ParseExact(model.policy_date, "dd/MM/yyyy", null) });
            }
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });

            parameter.Parameters.Add(new Field { Name = "message_type", Value = model.message_type });

            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<RPTransModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
