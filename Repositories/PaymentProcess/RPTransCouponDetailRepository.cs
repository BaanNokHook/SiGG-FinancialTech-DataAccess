using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPTransCouponDetailRepository : IRepository<RPCouponDetailModel>
    {
        private readonly IUnitOfWork _uow;

        public RPTransCouponDetailRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPCouponDetailModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Trans_Coupon_Port_210001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_cno", Value = model.trans_cno });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "event_date", Value = model.event_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_id", Value = model.counter_party_fund_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "ending_par", Value = model.ending_par });
            parameter.Parameters.Add(new Field { Name = "coupon_rate", Value = model.coupon_rate });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "unit", Value = model.unit });
            parameter.Parameters.Add(new Field { Name = "interest_amount", Value = model.interest_amount });
            parameter.Parameters.Add(new Field { Name = "interest_amount_adj", Value = model.interest_amount_adj });
            parameter.Parameters.Add(new Field { Name = "wht_int_amount", Value = model.wht_int_amount });
            parameter.Parameters.Add(new Field { Name = "wht_int_amount_adj", Value = model.wht_int_amount_adj });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<RPCouponDetailModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPCouponDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPCouponDetailModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Trans_Coupon_Port_210001_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_cno", Value = model.trans_cno });
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 3 };
            parameter.ResultModelNames.Add("RPCouponDetailResultModel");

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPCouponDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPCouponDetailModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<RPCouponDetailModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
