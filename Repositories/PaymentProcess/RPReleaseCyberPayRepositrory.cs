using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPReleaseCyberPayRepositrory : IRepository<RPReleaseCyberPayModel>
    {
        private readonly IUnitOfWork _uow;

        public RPReleaseCyberPayRepositrory(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPReleaseCyberPayModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_CyberPay_210002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "message_no", Value = model.message_no });
            parameter.Parameters.Add(new Field { Name = "RefCode", Value = model.RefCode });
            parameter.Parameters.Add(new Field { Name = "Seq", Value = model.Seq });
            parameter.Parameters.Add(new Field { Name = "SourceSystem", Value = model.SourceSystem });
            parameter.Parameters.Add(new Field { Name = "DealNo", Value = model.DealNo });
            parameter.Parameters.Add(new Field { Name = "DealType", Value = model.DealType });
            parameter.Parameters.Add(new Field { Name = "Product", Value = model.Product });
            parameter.Parameters.Add(new Field { Name = "ProductGroup", Value = model.ProductGroup });
            parameter.Parameters.Add(new Field { Name = "MTType", Value = model.MTType });
            parameter.Parameters.Add(new Field { Name = "ValueDate", Value = model.ValueDate });
            parameter.Parameters.Add(new Field { Name = "ReleaseDate", Value = model.ReleaseDate });
            parameter.Parameters.Add(new Field { Name = "SettlementStatus", Value = model.SettlementStatus });
            parameter.Parameters.Add(new Field { Name = "BankIndication", Value = model.BankIndication });
            parameter.Parameters.Add(new Field { Name = "TransactionType", Value = model.TransactionType });
            parameter.Parameters.Add(new Field { Name = "DebitAccount", Value = model.DebitAccount });
            parameter.Parameters.Add(new Field { Name = "BaseCurrency", Value = model.BaseCurrency });
            parameter.Parameters.Add(new Field { Name = "OrderCustAccount", Value = model.OrderCustAccount });
            parameter.Parameters.Add(new Field { Name = "OrderCustName", Value = model.OrderCustName });
            parameter.Parameters.Add(new Field { Name = "OrderCustAddrLine1", Value = model.OrderCustAddrLine1 });
            parameter.Parameters.Add(new Field { Name = "OrderCustAddrLine2", Value = model.OrderCustAddrLine2 });
            parameter.Parameters.Add(new Field { Name = "OrderCustAddrLine3", Value = model.OrderCustAddrLine3 });
            parameter.Parameters.Add(new Field { Name = "OrderInstName", Value = model.OrderInstName });
            parameter.Parameters.Add(new Field { Name = "OrderInstAddrLine1", Value = model.OrderInstAddrLine1 });
            parameter.Parameters.Add(new Field { Name = "OrderInstAddrLine2", Value = model.OrderInstAddrLine2 });
            parameter.Parameters.Add(new Field { Name = "OrderInstAddrLine3", Value = model.OrderInstAddrLine3 });
            parameter.Parameters.Add(new Field { Name = "TransferCurrency", Value = model.TransferCurrency });
            parameter.Parameters.Add(new Field { Name = "TransferAmount", Value = model.TransferAmount });
            parameter.Parameters.Add(new Field { Name = "CustomerRef", Value = model.CustomerRef });
            parameter.Parameters.Add(new Field { Name = "BeneInstRef", Value = model.BeneInstRef });
            parameter.Parameters.Add(new Field { Name = "PayeeCountry", Value = model.PayeeCountry });
            parameter.Parameters.Add(new Field { Name = "Charges", Value = model.Charges });
            parameter.Parameters.Add(new Field { Name = "BeneCustAccount", Value = model.BeneCustAccount });
            parameter.Parameters.Add(new Field { Name = "BeneCustIBAN", Value = model.BeneCustIBAN });
            parameter.Parameters.Add(new Field { Name = "BeneCustName", Value = model.BeneCustName });
            parameter.Parameters.Add(new Field { Name = "BeneCustAddrLine1", Value = model.BeneCustAddrLine1 });
            parameter.Parameters.Add(new Field { Name = "BeneCustAddrLine2", Value = model.BeneCustAddrLine2 });
            parameter.Parameters.Add(new Field { Name = "BeneCustAddrLine3", Value = model.BeneCustAddrLine3 });
            parameter.Parameters.Add(new Field { Name = "BeneInstRouteType", Value = model.BeneInstRouteType });
            parameter.Parameters.Add(new Field { Name = "BeneInstBankIdent", Value = model.BeneInstBankIdent });
            parameter.Parameters.Add(new Field { Name = "BeneInstAccount", Value = model.BeneInstAccount });
            parameter.Parameters.Add(new Field { Name = "BeneInstIBAN", Value = model.BeneInstIBAN });
            parameter.Parameters.Add(new Field { Name = "BeneInstName", Value = model.BeneInstName });
            parameter.Parameters.Add(new Field { Name = "BeneInstAddrLine1", Value = model.BeneInstAddrLine1 });
            parameter.Parameters.Add(new Field { Name = "BeneInstAddrLine2", Value = model.BeneInstAddrLine2 });
            parameter.Parameters.Add(new Field { Name = "BeneInstAddrLine3", Value = model.BeneInstAddrLine3 });
            parameter.Parameters.Add(new Field { Name = "AcctInstRouteType", Value = model.AcctInstRouteType });
            parameter.Parameters.Add(new Field { Name = "AcctInstBankIdent", Value = model.AcctInstBankIdent });
            parameter.Parameters.Add(new Field { Name = "AcctInstAccount", Value = model.AcctInstAccount });
            parameter.Parameters.Add(new Field { Name = "AcctInstName", Value = model.AcctInstName });
            parameter.Parameters.Add(new Field { Name = "AcctInstAddrLine1", Value = model.AcctInstAddrLine1 });
            parameter.Parameters.Add(new Field { Name = "AcctInstAddrLine2", Value = model.AcctInstAddrLine2 });
            parameter.Parameters.Add(new Field { Name = "AcctInstAddrLine3", Value = model.AcctInstAddrLine3 });
            parameter.Parameters.Add(new Field { Name = "InterInstRouteType", Value = model.InterInstRouteType });
            parameter.Parameters.Add(new Field { Name = "InterInstBankIdent", Value = model.InterInstBankIdent });
            parameter.Parameters.Add(new Field { Name = "InterInstAccount", Value = model.InterInstAccount });
            parameter.Parameters.Add(new Field { Name = "InterInstName", Value = model.InterInstName });
            parameter.Parameters.Add(new Field { Name = "InterInstAddrLine1", Value = model.InterInstAddrLine1 });
            parameter.Parameters.Add(new Field { Name = "InterInstAddrLine2", Value = model.InterInstAddrLine2 });
            parameter.Parameters.Add(new Field { Name = "InterInstAddrLine3", Value = model.InterInstAddrLine3 });
            parameter.Parameters.Add(new Field { Name = "BeneRefLine1", Value = model.BeneRefLine1 });
            parameter.Parameters.Add(new Field { Name = "BeneRefLine2", Value = model.BeneRefLine2 });
            parameter.Parameters.Add(new Field { Name = "BeneRefLine3", Value = model.BeneRefLine3 });
            parameter.Parameters.Add(new Field { Name = "BeneRefLine4", Value = model.BeneRefLine4 });
            parameter.Parameters.Add(new Field { Name = "BankToBankInfoLine1", Value = model.BankToBankInfoLine1 });
            parameter.Parameters.Add(new Field { Name = "BankToBankInfoLine2", Value = model.BankToBankInfoLine2 });
            parameter.Parameters.Add(new Field { Name = "BankToBankInfoLine3", Value = model.BankToBankInfoLine3 });
            parameter.Parameters.Add(new Field { Name = "BankToBankInfoLine4", Value = model.BankToBankInfoLine4 });
            parameter.Parameters.Add(new Field { Name = "BankToBankInfoLine5", Value = model.BankToBankInfoLine5 });
            parameter.Parameters.Add(new Field { Name = "BankToBankInfoLine6", Value = model.BankToBankInfoLine6 });
            parameter.Parameters.Add(new Field { Name = "CustomerCode", Value = model.CustomerCode });
            parameter.Parameters.Add(new Field { Name = "CustomerName", Value = model.CustomerName });
            parameter.Parameters.Add(new Field { Name = "A1", Value = model.A1 });
            parameter.Parameters.Add(new Field { Name = "A2", Value = model.A2 });
            parameter.Parameters.Add(new Field { Name = "A3", Value = model.A3 });
            parameter.Parameters.Add(new Field { Name = "A4", Value = model.A4 });
            parameter.Parameters.Add(new Field { Name = "A5", Value = model.A5 });
            parameter.Parameters.Add(new Field { Name = "A6", Value = model.A6 });
            parameter.Parameters.Add(new Field { Name = "A7", Value = model.A7 });
            parameter.Parameters.Add(new Field { Name = "A8", Value = model.A8 });
            parameter.Parameters.Add(new Field { Name = "A9", Value = model.A9 });
            parameter.Parameters.Add(new Field { Name = "A10", Value = model.A10 });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "C" });
            
            parameter.ResultModelNames.Add("RPReleaseCyberPayResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<RPReleaseCyberPayModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPReleaseCyberPayModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPReleaseCyberPayModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_CyberPay_210002_Search_Proc";
            parameter.Parameters.Add(new Field { Name = "DealNo", Value = model.DealNo });
            parameter.Parameters.Add(new Field { Name = "DealType", Value = model.DealType });
            parameter.Parameters.Add(new Field { Name = "MTType", Value = model.MTType });
            parameter.Parameters.Add(new Field { Name = "ValueDate", Value = model.ValueDate });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "CustomerCode", Value = model.CustomerCode });
            parameter.Parameters.Add(new Field { Name = "Cur", Value = model.ccy });
            parameter.Parameters.Add(new Field { Name = "Seq", Value = model.Seq });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("RPReleaseCyberPayResultModel");
            parameter.Paging = null;
            parameter.Orders = null;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPReleaseCyberPayModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPReleaseCyberPayModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_CyberPay_210002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "message_no", Value = model.message_no });
            parameter.Parameters.Add(new Field { Name = "DealNo", Value = model.DealNo });
            parameter.Parameters.Add(new Field { Name = "SettlementStatus", Value = model.SettlementStatus });
            parameter.Parameters.Add(new Field { Name = "send_status", Value = model.send_status });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "U" });

            parameter.ResultModelNames.Add("RPReleaseCyberPayResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RPReleaseCyberPayModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
