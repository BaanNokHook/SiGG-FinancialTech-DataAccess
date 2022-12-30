using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPTransCouponRepository : IRepository<RPCouponModel>
    {
        private readonly IUnitOfWork _uow;

        public RPTransCouponRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Trans_Coupon_210001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "event_date", Value = model.event_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_id", Value = model.counter_party_fund_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "ending_par", Value = model.ending_par });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "unit", Value = model.unit });
            parameter.Parameters.Add(new Field { Name = "interest_amount", Value = model.interest_amount });
            parameter.Parameters.Add(new Field { Name = "interest_amount_adj", Value = model.interest_amount_adj });
            parameter.Parameters.Add(new Field { Name = "wht_int_amount", Value = model.wht_int_amount });
            parameter.Parameters.Add(new Field { Name = "wht_int_amount_adj", Value = model.wht_int_amount_adj });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "remark", Value = model.remark });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            ResultWithModel rwm = _uow.ExecNonQueryProc(parameter, "trans_cno", out var outId);
            model.trans_cno = outId;
            rwm.Data = model;
            return rwm;
        }

        public ResultWithModel AddList(List<RPCouponModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPCouponModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Trans_Coupon_210001_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "trans_cno", Value = model.trans_cno });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            //parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.ResultModelNames.Add("RPCouponResultModel");

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPCouponModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPCouponModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<RPCouponModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
