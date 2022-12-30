using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPCallMarginRepository : IRPCallMarginRepository
    {
        private readonly IUnitOfWork _uow;

        public RPCallMarginRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get(string callDateFrom, string callDateTo, string ctpyID, string cur)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = callDateFrom });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = callDateTo });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = ctpyID });
            parameter.Parameters.Add(new Field { Name = "cur", Value = cur });
            parameter.ResultModelNames.Add("RPCallMarginPRPResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetDetail(string asOfDate, int ctpyID)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_Detail_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = asOfDate });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = asOfDate });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = ctpyID });
            parameter.ResultModelNames.Add("RPCallMarginDetailResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetDetailBRP(string asOfDate, int ctpyID, string cur)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = asOfDate });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = asOfDate });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = ctpyID });
            parameter.Parameters.Add(new Field { Name = "cur", Value = cur });
            parameter.ResultModelNames.Add("RPCallMarginBRPResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = int.MaxValue;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetList(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Daily_List_Proc";
            parameter.Parameters.Add(new Field { Name = "businessDate", Value = model.call_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.ResultModelNames.Add("RPCallMarginResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Add(string transDate, string cur,decimal? holiday_int_rate)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Cal_Proc";
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = transDate });
            parameter.Parameters.Add(new Field { Name = "cur", Value = cur });
            parameter.Parameters.Add(new Field { Name = "margin_int_rate_holiday", Value = holiday_int_rate });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddAdjustPRP(RPCallMarginPRPModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_PRP_Adjust_Proc";
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "todayExposure", Value = model.exposure });
            parameter.Parameters.Add(new Field { Name = "totalIntRec", Value = model.TOTAL_INT_REC });
            parameter.Parameters.Add(new Field { Name = "totalIntPay", Value = model.TOTAL_INT_PAY });
            parameter.Parameters.Add(new Field { Name = "intTax", Value = model.INT_REC_TAX });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "client_margin", Value = model.client_margin });
            parameter.Parameters.Add(new Field { Name = "is_call", Value = model.isCall });
            parameter.Parameters.Add(new Field { Name = "eom_int_flag", Value = model.eom_int_flag });

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddAdjustBRP(RPCallMarginBRPModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_BRP_Adjust_Proc";
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "transNo", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "todayExposure", Value = model.exposure });
            parameter.Parameters.Add(new Field { Name = "totalIntRec", Value = model.Int_Recv_Disp });
            parameter.Parameters.Add(new Field { Name = "totalIntPay", Value = model.Int_Paid_Disp });
            parameter.Parameters.Add(new Field { Name = "intTax", Value = model.Int_Tax_Disp });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "bond_id", Value = model.bond_id });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel ActionInterestRate(string transDate, string cur, decimal interestRate)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_interest_Action_Proc";
            parameter.Parameters.Add(new Field { Name = "TRANSDATE", Value = transDate });
            parameter.Parameters.Add(new Field { Name = "CUR", Value = cur });
            parameter.Parameters.Add(new Field { Name = "RATE", Value = interestRate });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel CheckMarginIntRate(RPCallMarginModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Check_IntRateFCY_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "call_date", Value = model.call_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("RPCallMarginResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }
    }
}
