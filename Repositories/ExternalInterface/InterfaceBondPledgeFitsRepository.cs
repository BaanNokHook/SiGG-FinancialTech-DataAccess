using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{

    public class InterfaceBondPledgeFitsRepository : IRepository<InterfaceBondPledgeFitsModel>    
    {
        private readonly IUnitOfWork _uow;   
        public InterfaceBondPledgeFitsRepository(IUnitOfWork uow)     
        {
            _uow = uow;   
        }  
        
        public ResultWithModel AddList(List<InterfaceBondPledgeFitsModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceBondPledgeFitsModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceBondPledgeFitsModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_BondPledge_FITS_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.AsOfDate });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("BondPledgeFitsResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999999;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(InterfaceBondPledgeFitsModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceBondPledgeFitsModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceBondPledgeFitsModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
