
using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.PaymentProcess;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPMarginInterestFCYRepository : IRepository<RPMarginInterestFCYModel>
    {
        private readonly IUnitOfWork _uow;

        public RPMarginInterestFCYRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPMarginInterestFCYModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<RPMarginInterestFCYModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPMarginInterestFCYModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPMarginInterestFCYModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Interest_Adjust_List_Proc";
            parameter.Parameters.Add(new Field { Name = "eom_date_from", Value = model.eom_date_from });
            parameter.Parameters.Add(new Field { Name = "eom_date_to", Value = model.eom_date_to });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "margin_status", Value = model.margin_status });
            parameter.Parameters.Add(new Field { Name = "rec_pay_status", Value = model.rec_pay_status });

            parameter.ResultModelNames.Add("RPMarginInterestFCYResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPMarginInterestFCYModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPMarginInterestFCYModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Margin_Interest_Adjust_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "eom_date", Value = model.eom_date });
            parameter.Parameters.Add(new Field { Name = "counter_party_id", Value = model.counter_party_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "int_rec_pay_date", Value = model.int_rec_pay_date });
            parameter.Parameters.Add(new Field { Name = "total_int_rec", Value = model.total_int_rec });
            parameter.Parameters.Add(new Field { Name = "total_int_pay", Value = model.total_int_pay });
            parameter.Parameters.Add(new Field { Name = "int_rec_tax", Value = model.int_rec_tax });
            parameter.Parameters.Add(new Field { Name = "margin_status", Value = model.margin_status });
            parameter.Parameters.Add(new Field { Name = "rec_pay_status", Value = model.rec_pay_status });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RPMarginInterestFCYModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
