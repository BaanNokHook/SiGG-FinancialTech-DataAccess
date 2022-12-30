using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPCouponRepository: IRPCouponRepository
    {
        private readonly IUnitOfWork _uow;

        public RPCouponRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Coupon_210001_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_code", Value = model.fund_code });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.ResultModelNames.Add("RPCouponResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetList(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Coupon_210001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_code", Value = model.fund_code });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.ResultModelNames.Add("RPCouponResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetDetail(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Coupon_210001_Detail_Proc";
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_code", Value = model.fund_code });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.ResultModelNames.Add("RPCouponDetailResultModel");

            return _uow.ExecDataProc(parameter);
        }
    }
}
