using System;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Report;

namespace GM.DataAccess.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IUnitOfWork _uow;
        public ReportRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel GlSummary(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_GL_summary_500001_proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "event_date_start", Value = model.trade_date_from });
            parameter.Parameters.Add(new Field { Name = "event_date_end", Value = model.trade_date_to });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "account_code", Value = model.account_code });

            //Parameter.ResultModelNames.Add("AccountingReportResultModel");

            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GlTransaction(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_GL_detail_500002_proc";

            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "event_date_start", Value = model.trade_date_from });
            parameter.Parameters.Add(new Field { Name = "event_date_end", Value = model.trade_date_to });
            parameter.Parameters.Add(new Field { Name = "trans_from", Value = model.trans_no_from });
            parameter.Parameters.Add(new Field { Name = "trans_to", Value = model.trans_no_to });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "account_code", Value = model.account_code });
            parameter.Parameters.Add(new Field { Name = "event_type", Value = model.event_type_id });
            parameter.ResultModelNames.Add("AccountingTransactionReportResultModel");

            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Maturity(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Maturity_100002_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.instrument_type });
            parameter.Parameters.Add(new Field { Name = "trade_date", Value = model.trade_date });
            parameter.Parameters.Add(new Field { Name = "settlement_date", Value = model.settlement_date });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "counterparty_code", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.ResultModelNames.Add("MaturityReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel AverageYTM(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_AverageYTM_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.instrument_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.ResultModelNames.Add("AverageYTMReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CallMargin(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Call_Margin_400001_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.call_date_to });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "instrument", Value = model.repo_deal_type });
            parameter.ResultModelNames.Add("CallMarginReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel MarginByCounterparty(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Margin_By_Counterparty_400003_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.call_date_to });
            if (model.counterparty_code != "" && model.counterparty_code != null)
            {
                parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = System.Convert.ToInt32(model.counterparty_code) });
            }
            else 
            {
                parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = null });
            }
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_id", Value = model.counterparty_fund_id });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "instrument", Value = model.repo_deal_type });
            parameter.ResultModelNames.Add("MarginByCounterpartyReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Payment(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Payment_300003_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asof_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("PaymentReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel MarginCalResultDetail(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_Detail_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.call_date_to });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("MarginCalResultDetailReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel MarginCalResultSummary(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Trans_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.call_date_to });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("MarginCalResultSummaryReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Outstanding(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_200001_Proc";
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "counterparty_code", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "as_of_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.ResultModelNames.Add("OutstandingReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingBilateralPrivate(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_Bilateral_Private_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.ResultModelNames.Add("OutstandingBilateralPrivateReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingBorrow(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_Borrow_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.ResultModelNames.Add("OutstandingBorrowReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingCashMargin(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_Cash_Margin_400002_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "counter_party_fund_id", Value = model.counterparty_fund_id });
            parameter.Parameters.Add(new Field { Name = "instrument", Value = model.repo_deal_type });
            parameter.ResultModelNames.Add("OutstandingCashMarginReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingLoansLending(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_Loans_Lending_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.ResultModelNames.Add("OutstandingLoansLendingReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingObligatePledge(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_Obligate_Pledge_200002_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "start_date", Value = model.start_date });
            parameter.Parameters.Add(new Field { Name = "end_date", Value = model.expire_date });
            parameter.Parameters.Add(new Field { Name = "repo_type", Value = model.obligate_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.ResultModelNames.Add("OutstandingObligatePledgeReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel ProfitAndLoss(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Profit_Loss_300002_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "as_of_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "instrument", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "int_type", Value = model.int_type });
            parameter.Parameters.Add(new Field { Name = "cost_type", Value = model.cost_type });
            parameter.Parameters.Add(new Field { Name = "report_type", Value = model.excel_category });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "counterparty_id", Value = model.counterparty_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("ProfitAndLossReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel AmendCancel(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_AmendCancel_100003_Proc";
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = model.trans_status });
            parameter.Parameters.Add(new Field { Name = "cust_type", Value = model.cust_type });
            parameter.Parameters.Add(new Field { Name = "report_type", Value = model.report_type });

            //Parameter.ResultModelNames.Add("AmendCancelReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel BISINVPLDG(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_BIS_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "reportType", Value = "BISINVPLDG" });
            parameter.Parameters.Add(new Field { Name = "exeType", Value = model.execute_type });
            parameter.ResultModelNames.Add("BISINVPLDGReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel BISREVREPO(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_BIS_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "reportType", Value = "BISREVREPO" });
            parameter.Parameters.Add(new Field { Name = "exeType", Value = model.execute_type });
            parameter.ResultModelNames.Add("BISREVREPOReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel CashFlow(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Cashflow_300001_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asof_date_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("CashFlowReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 0, RecordPerPage = 0 };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel DailyTransaction(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Daily_Transaction_100001_Proc";
            parameter.Parameters.Add(new Field { Name = "trade_date_from", Value = model.trade_date_from });
            parameter.Parameters.Add(new Field { Name = "trade_date_to", Value = model.trade_date_to });
            parameter.Parameters.Add(new Field { Name = "settlement_date_from", Value = model.settlement_date_from });
            parameter.Parameters.Add(new Field { Name = "settlement_date_to", Value = model.settlement_date_to });
            parameter.Parameters.Add(new Field { Name = "maturity_date_from", Value = model.maturity_date_from });
            parameter.Parameters.Add(new Field { Name = "maturity_date_to", Value = model.maturity_date_to });
            parameter.Parameters.Add(new Field { Name = "trans_no_to", Value = model.trans_no_to });
            parameter.Parameters.Add(new Field { Name = "trans_no_from", Value = model.trans_no_from });
            parameter.Parameters.Add(new Field { Name = "counterparty_code", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "counterparty_fund_id", Value = model.counterparty_fund_id });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.instrument_type });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.ResultModelNames.Add("DailyTransactionReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel RPConfirmation(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Confirmation_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPConfirmationResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel DailyRepoOutstanding(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_DailyRepo_Outstanding_200001_Proc";
            parameter.Parameters.Add(new Field { Name = "datefrom", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "dateto", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "counterparty_code", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.instrument_type });
            parameter.Parameters.Add(new Field { Name = "report_type", Value = model.report_type });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "is_full_date", Value = model.is_full_date });
            parameter.ResultModelNames.Add("DailyRepoOutstandingResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingBorrowBondForPledge(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Outstanding_Borrow_Bond_For_Pledge_200001_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date", Value = model.asofdate });
            parameter.ResultModelNames.Add("OutstandingBorrowBornForPlegdeResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel BondXI(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_BondXI_Proc";
            parameter.Parameters.Add(new Field { Name = "xiDate", Value = model.xi_date });
            parameter.Parameters.Add(new Field { Name = "paymentDate", Value = model.payment_date });

            bool convertedCounterParty = Int32.TryParse(model.counterparty_code, out Int32 counterPartyCode);
            if(convertedCounterParty)
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = counterPartyCode });

            bool convertedInstrument = Int32.TryParse(model.instrument_id, out Int32 instrumentId);
            if (convertedInstrument)
                parameter.Parameters.Add(new Field { Name = "security_id", Value = instrumentId });

            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });

            parameter.ResultModelNames.Add("BondXIReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel BondXICovid(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_BondXI_COVID_Proc";
            parameter.Parameters.Add(new Field { Name = "xiDate", Value = model.xi_date });
            parameter.Parameters.Add(new Field { Name = "paymentDate", Value = model.payment_date });
            parameter.Parameters.Add(new Field { Name = "asofdate_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asofdate_to", Value = model.asofdate_to });

            bool convertedCounterParty = Int32.TryParse(model.counterparty_code, out Int32 counterPartyCode);
            if (convertedCounterParty)
                parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = counterPartyCode });

            bool convertedInstrument = Int32.TryParse(model.instrument_id, out Int32 instrumentId);
            if (convertedInstrument)
                parameter.Parameters.Add(new Field { Name = "security_id", Value = instrumentId });

            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });

            parameter.ResultModelNames.Add("BondXICovidReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel EodReconcile(DateTime asofdate, bool isBilateralTrade, bool isBilateralSattlementDVP, bool isBilateralSattlementRVP, 
            bool isBilateralSattlementMT202, bool isPrivateTrade, bool isPrivateSattlementDVP, bool isPrivateSattlementRVP, bool isPrivateSattlementDF,
            bool isPrivateSattlementRF,bool isPrivateSattlementMT103)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_EOD_BO_Reconcile_Proc";
            parameter.Parameters.Add(new Field { Name = "ASOF_DATE", Value = asofdate });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_TRADE", Value = isBilateralTrade });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_DVP", Value = isBilateralSattlementDVP });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_RVP", Value = isBilateralSattlementRVP });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_SATTLEMENT_MT202", Value = isBilateralSattlementMT202 });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_TRADE", Value = isPrivateTrade });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DVP", Value = isPrivateSattlementDVP });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RVP", Value = isPrivateSattlementRVP });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_DF", Value = isPrivateSattlementDF });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_RF", Value = isPrivateSattlementRF });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_SATTLEMENT_MT103", Value = isPrivateSattlementMT103 });

            parameter.ResultModelNames.Add("EodReconcileReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel EodReconcileCallMargin(DateTime asofdate, bool isBilateralMarginPay, bool isPrivateMarginPay)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_EOD_CallMargin_Reconcile_Proc";
            parameter.Parameters.Add(new Field { Name = "ASOF_DATE", Value = asofdate });
            parameter.Parameters.Add(new Field { Name = "BILATERAL_MARGIN_PAY", Value = isBilateralMarginPay });
            parameter.Parameters.Add(new Field { Name = "PRIVATE_MARGIN_PAY", Value = isPrivateMarginPay });

            parameter.ResultModelNames.Add("EodReconcileCallMarginReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel MarginTransPRPReport(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Margin_Trans_PRP_Proc";
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.call_date_to });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counterparty_id });
            parameter.Parameters.Add(new Field { Name = "transNo", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "numDays", Value = model.numDays });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("MarginTransPRPReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel MarginTransBRPReport(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Margin_Trans_BRP_Proc";
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.call_date_to });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counterparty_id });
            parameter.Parameters.Add(new Field { Name = "transNo", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "numDays", Value = model.numDays });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.currency });
            parameter.ResultModelNames.Add("MarginTransBRPReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }
        public ResultWithModel MarginTransDetailReport(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Margin_Trans_Details_Proc";
            parameter.Parameters.Add(new Field { Name = "asOfDate", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "asOfDate_from", Value = model.asofdate_from });
            parameter.Parameters.Add(new Field { Name = "asOfDate_to", Value = model.asofdate_to });
            parameter.Parameters.Add(new Field { Name = "callDate_from", Value = model.call_date_from });
            parameter.Parameters.Add(new Field { Name = "callDate_to", Value = model.call_date_to });
            parameter.Parameters.Add(new Field { Name = "ctpyID", Value = model.counterparty_id });
            parameter.ResultModelNames.Add("MarginTransDetailReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel StockReconcile(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Stock_Reconcile_Proc";
            parameter.Parameters.Add(new Field { Name = "ASOF_DATE", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "INSTRUMENT_ID", Value = model.instrument_id });
            parameter.ResultModelNames.Add("StockReconcileReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel OutstandingAccounting(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Account_Outstanding_610022_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "maturity_date_from", Value = model.maturity_date_from });
            parameter.Parameters.Add(new Field { Name = "maturity_date_to", Value = model.maturity_date_to });
            parameter.Parameters.Add(new Field { Name = "acc_no_from", Value = model.account_code_from });
            parameter.Parameters.Add(new Field { Name = "acc_no_to", Value = model.account_code_to });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "counterparty_id", Value = model.counterparty_id });
            parameter.Parameters.Add(new Field { Name = "date_type", Value = model.type_date });
            parameter.ResultModelNames.Add("OutstandingAccountingReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel HistoryEarlyTerminate(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_History_Early_Terminate_100004_Proc";
            parameter.Parameters.Add(new Field { Name = "trade_date_from", Value = model.trade_date_from });
            parameter.Parameters.Add(new Field { Name = "trade_date_to", Value = model.trade_date_to });
            parameter.Parameters.Add(new Field { Name = "settlement_date_from", Value = model.settlement_date_from });
            parameter.Parameters.Add(new Field { Name = "settlement_date_to", Value = model.settlement_date_to });
            parameter.Parameters.Add(new Field { Name = "maturity_date_from", Value = model.maturity_date_from });
            parameter.Parameters.Add(new Field { Name = "maturity_date_to", Value = model.maturity_date_to });
            parameter.Parameters.Add(new Field { Name = "trans_no_to", Value = model.trans_no_to });
            parameter.Parameters.Add(new Field { Name = "trans_no_from", Value = model.trans_no_from });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.Parameters.Add(new Field { Name = "terminate_date_from", Value = model.terminate_date_from });
            parameter.Parameters.Add(new Field { Name = "terminate_date_to", Value = model.terminate_date_to });
            parameter.ResultModelNames.Add("HistoryEarlyTerminateReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel RollOverTransaction(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_RollOver_Transaction_100005_Proc";
            parameter.Parameters.Add(new Field { Name = "trade_date_from", Value = model.trade_date_from });
            parameter.Parameters.Add(new Field { Name = "trade_date_to", Value = model.trade_date_to });
            parameter.Parameters.Add(new Field { Name = "settlement_date_from", Value = model.settlement_date_from });
            parameter.Parameters.Add(new Field { Name = "settlement_date_to", Value = model.settlement_date_to });
            parameter.Parameters.Add(new Field { Name = "maturity_date_from", Value = model.maturity_date_from });
            parameter.Parameters.Add(new Field { Name = "maturity_date_to", Value = model.maturity_date_to });
            parameter.Parameters.Add(new Field { Name = "trans_no_to", Value = model.trans_no_to });
            parameter.Parameters.Add(new Field { Name = "trans_no_from", Value = model.trans_no_from });
            parameter.Parameters.Add(new Field { Name = "counterparty_code", Value = model.counterparty_code });
            parameter.Parameters.Add(new Field { Name = "counterparty_fund_id", Value = model.counterparty_fund_id });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.instrument_type });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "currency", Value = model.currency });
            parameter.ResultModelNames.Add("RollOverTransactionReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel MarginNotice(ReportCriteriaModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Margin_Notice_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counterparty_id });
            parameter.ResultModelNames.Add("MarginNoticeReportResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = int.MaxValue };
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

    }
}
