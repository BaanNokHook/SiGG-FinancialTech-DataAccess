using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPReleaseMessageRepository : IRPReleaseMessageRepository
    {
        private readonly IUnitOfWork _uow;

        public RPReleaseMessageRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            if (model.cur == "THB")
            {
                parameter.ProcedureName = "RP_Release_Message_210002_THB_Proc";
            }
            else
            {
                parameter.ProcedureName = "RP_Release_Message_210002_Proc";
                parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            }

            parameter.Parameters.Add(new Field { Name = "system_type", Value = "REPO" });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetNetSettle(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_NetSettle_210002_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "system_type", Value = "REPO" });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }


        public ResultWithModel GetList(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "swift_channel", Value = model.swift_channel });
            parameter.Parameters.Add(new Field { Name = "isSyncCyberPay", Value = model.isSyncCyberPay });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetListPTI(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_PTI_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetListNetSettle(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_NetSettle_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "isSyncCyberPay", Value = model.isSyncCyberPay });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetConfirm(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Release_Message_210002_Confirm_Proc";

            parameter.Parameters.Add(new Field { Name = "CUR", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "SYSTEM_TYPE", Value = "REPO" });
            parameter.Parameters.Add(new Field { Name = "TRANS_NO", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "MESSAGE_TYPE", Value = model.message_type });
            parameter.Parameters.Add(new Field { Name = "EVENT_TYPE", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "CHANGE_DATE", Value = model.policy_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "TERMINATE_FLAG", Value = model.terminate_flag });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetAmendConfirm(RPTransModel model)
        { 
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Release_Message_210002_Confirm_Amend_Proc";

            parameter.Parameters.Add(new Field { Name = "CUR", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "SYSTEM_TYPE", Value = "REPO" });
            parameter.Parameters.Add(new Field { Name = "TRANS_NO", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "MESSAGE_TYPE", Value = model.message_type });
            parameter.Parameters.Add(new Field { Name = "EVENT_TYPE", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "CHANGE_DATE", Value = model.policy_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "TERMINATE_FLAG", Value = model.terminate_flag });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetConfirmPRP(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Release_Message_210002_Confirm_PRP_Proc";

            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "system_type", Value = "REPO" });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Add(RPReleaseMessageModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_210002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_no });
            parameter.Parameters.Add(new Field { Name = "file_name", Value = model.file_name });
            parameter.Parameters.Add(new Field { Name = "customer_ref", Value = model.customer_ref });
            parameter.Parameters.Add(new Field { Name = "swift_channel", Value = model.swift_channel });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");

            //return _uow.ExecNonQueryProc(parameter);
            ResultWithModel rwm = _uow.ExecNonQueryProc(parameter, "message_no", out var id);
            if (rwm.Success)
            {
                model.message_no = System.Convert.ToInt32(id);
                rwm.Data = model;
            }
            return rwm;

            
        }

        public ResultWithModel MtList(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_MT_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "recorded_date", Value = model.create_date });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CallMarginList(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_Margin_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.from_as_of_date });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.to_as_of_date });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.from_call_date });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.to_call_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "isSyncCyberPay", Value = model.isSyncCyberPay });
            parameter.ResultModelNames.Add("RPCallMarginResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CallMarginGet(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_Margin_210002_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "calldate", Value = model.call_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "eom_int_flag", Value = model.eom_int_flag });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CallMargin(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_Margin_210002_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "callDate", Value = model.call_date });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "brp_contract_no", Value = model.brp_contract_no });
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CheckPayment(RPReleaseMsgCheckPaymentModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_210002_CheckPaymentMethod_Proc";
            parameter.Parameters.Add(new Field { Name = "from_page", Value = model.from_page });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.ResultModelNames.Add("RPReleaseMsgCheckPaymentResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 1 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }
        public ResultWithModel DetailCoupon(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_Coupon_210002_Proc";
            parameter.Parameters.Add(new Field { Name = "system_type", Value = "REPO" });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_cno });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("RPReleaseMessageResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 100 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel RPCouponList(RPCouponModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_Coupon_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "payment_date", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_code", Value = model.fund_code });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });

            parameter.ResultModelNames.Add("RPCouponResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 100 };
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel InterestMarginList(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_MarginIntFCY_210002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "payment_date_from", Value = model.payment_date_from });
            parameter.Parameters.Add(new Field { Name = "payment_date_to", Value = model.payment_date_to });
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.from_as_of_date });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.to_as_of_date });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.from_call_date });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.to_call_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "isSyncCyberPay", Value = model.isSyncCyberPay });
            parameter.ResultModelNames.Add("RPCallMarginResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel InterestMargin(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_Margin_Interest_210002_Proc";
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "callDate", Value = model.call_date });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "brp_contract_no", Value = model.brp_contract_no });
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;
            return _uow.ExecDataProc(parameter);
        }
    }
}
