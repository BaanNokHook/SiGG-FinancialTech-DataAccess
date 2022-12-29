using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceEquityPledgeRepository : IRepository<InterfaceEquityPledgeModel>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceEquityPledgeRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceEquityPledgeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<InterfaceEquityPledgeModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceEquityPledgeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceEquityPledgeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_EQUITY_Pledge_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.AsOfDate });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("PledgeEquityResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999999;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(InterfaceEquityPledgeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceEquityPledgeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceEquityPledgeModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
