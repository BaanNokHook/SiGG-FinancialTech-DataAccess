using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class PaymentMethodRepository : IRepository<PaymentMethodModel>
    {
        private readonly IUnitOfWork _uow;

        public PaymentMethodRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(PaymentMethodModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_Payment_Method_830002_Insert_Proc";
                parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
                parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
                parameter.Parameters.Add(new Field { Name = "description", Value = model.description });
                parameter.Parameters.Add(new Field { Name = "system_type", Value = model.system_type });
                parameter.Parameters.Add(new Field { Name = "payment_flag", Value = model.payment_flag });
                parameter.ResultModelNames.Add("PaymentMethodResultModel");
                return _uow.ExecNonQueryProc(parameter);
            }
            catch (Exception ex)
            {
                return new ResultWithModel
                {
                    Message = ex.Message,
                    RefCode = 500
                };
            }
        }

        public ResultWithModel AddList(List<PaymentMethodModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(PaymentMethodModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(PaymentMethodModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Payment_Method_830002_List_Proc";

            parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            parameter.Parameters.Add(new Field { Name = "system_type", Value = model.system_type });
            parameter.Parameters.Add(new Field { Name = "payment_flag", Value = model.payment_flag });

            parameter.ResultModelNames.Add("PaymentMethodResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(PaymentMethodModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_Payment_Method_830002_Update_Proc";

                parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
                parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
                parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });

                parameter.ResultModelNames.Add("PaymentMethodResultModel");
                return _uow.ExecNonQueryProc(parameter);
            }
            catch (Exception ex)
            {
                return new ResultWithModel
                {
                    Message = ex.Message,
                    RefCode = 500

                };
            }
        }

        public ResultWithModel Update(PaymentMethodModel model)
        {
            try
            {
                BaseParameterModel parameter = new BaseParameterModel();
                parameter.ProcedureName = "GM_Payment_Method_830002_Update_Proc";

                parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
                parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
                parameter.Parameters.Add(new Field { Name = "description", Value = model.description });
                parameter.Parameters.Add(new Field { Name = "system_type", Value = model.system_type });
                parameter.Parameters.Add(new Field { Name = "payment_flag", Value = model.payment_flag });

                parameter.ResultModelNames.Add("PaymentMethodResultModels");
                return _uow.ExecNonQueryProc(parameter);
            }
            catch (Exception ex)
            {
                return new ResultWithModel
                {
                    Message = ex.Message,
                    RefCode = 500
                };
            }
        }

        public ResultWithModel UpdateList(List<PaymentMethodModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
