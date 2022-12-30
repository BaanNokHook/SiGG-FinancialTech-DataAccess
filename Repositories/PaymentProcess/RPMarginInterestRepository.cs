using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPMarginInterestRepository: IRepository<RPMarginInterestModel>
    {
        private readonly IUnitOfWork _uow;

        public RPMarginInterestRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPMarginInterestModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<RPMarginInterestModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPMarginInterestModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPMarginInterestModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Daily_Int_210004_Get_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });

            parameter.ResultModelNames.Add("RPMarginInterestResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPMarginInterestModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPMarginInterestModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Daily_Int_210004_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "total_int_paid_adj", Value = model.total_int_paid_adj });
            parameter.Parameters.Add(new Field { Name = "total_int_received_adj", Value = model.total_int_received_adj });
            parameter.Parameters.Add(new Field { Name = "total_int_tax_adj", Value = model.total_int_tax_adj });
            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "mt_code", Value = model.mt_code });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });

            parameter.ResultModelNames.Add(" Result.Add(new { Message = ex.Message });");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RPMarginInterestModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
