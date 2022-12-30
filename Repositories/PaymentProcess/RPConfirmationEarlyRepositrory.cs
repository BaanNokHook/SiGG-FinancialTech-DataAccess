using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.PaymentProcess
{
    public class RPConfirmationEarlyRepositrory : IRepository<RPTransModel>
    {
        private readonly IUnitOfWork _uow;

        public RPConfirmationEarlyRepositrory(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<RPTransModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Release_Message_210002_Confirm_Early_List_Proc";
            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RPTransModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<RPTransModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
