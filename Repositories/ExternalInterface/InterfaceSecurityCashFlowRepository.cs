using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceSecurity;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceSecurityCashFlowRepository : IRepository<ReqCashFlowList>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceSecurityCashFlowRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(ReqCashFlowList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Event_Temp_810001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_code", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "event_date", Value = model.event_date });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "round_no", Value = model.round_no });
            parameter.Parameters.Add(new Field { Name = "complete_flag", Value = model.complete_flag });
            parameter.Parameters.Add(new Field { Name = "coupon_date", Value = model.coupon_date });
            parameter.Parameters.Add(new Field { Name = "next_coupon_date", Value = model.next_coupon_date });
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "coupon_type", Value = model.coupon_type });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "coupon_floating_index_code", Value = model.coupon_floating_index_code });
            parameter.Parameters.Add(new Field { Name = "coupon_cur", Value = model.coupon_cur });
            parameter.Parameters.Add(new Field { Name = "coupon_spread", Value = model.coupon_spread });
            parameter.Parameters.Add(new Field { Name = "redemption_value", Value = model.redemption_value });
            parameter.Parameters.Add(new Field { Name = "redemption_percent", Value = model.redemption_percent });
            parameter.Parameters.Add(new Field { Name = "redemption_trans_no", Value = model.redemption_trans_no });
            parameter.Parameters.Add(new Field { Name = "order_index", Value = model.order_index });
            parameter.Parameters.Add(new Field { Name = "interest", Value = model.interest });
            parameter.Parameters.Add(new Field { Name = "principal", Value = model.principal });
            parameter.Parameters.Add(new Field { Name = "total_payment", Value = model.total_payment });
            parameter.Parameters.Add(new Field { Name = "begining_par", Value = model.begining_par });
            parameter.Parameters.Add(new Field { Name = "ending_par", Value = model.ending_par });
            parameter.Parameters.Add(new Field { Name = "xi_date", Value = model.xi_date });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.Parameters.Add(new Field { Name = "create_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "update_date", Value = model.update_date });
            parameter.Parameters.Add(new Field { Name = "update_by", Value = model.update_by });
            parameter.ResultModelNames.Add("CashflowResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ReqCashFlowList> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ReqCashFlowList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ReqCashFlowList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(ReqCashFlowList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ReqCashFlowList model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<ReqCashFlowList> models)
        {
            throw new NotImplementedException();
        }
    }
}
