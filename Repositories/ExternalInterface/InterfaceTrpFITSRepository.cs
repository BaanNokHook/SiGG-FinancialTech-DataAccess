using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceTrpFITSRepository : IRepository<InterfaceTrpFitsSftpModel>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceTrpFITSRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceTrpFitsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<InterfaceTrpFitsSftpModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceTrpFitsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceTrpFitsSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Trp_Fits_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("InterfaceTrpFitsSftpResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999999;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(InterfaceTrpFitsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceTrpFitsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceTrpFitsSftpModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
