using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class ViewDWHRepository : IRepository<DWHModel>
    {
        private readonly IUnitOfWork _uow;

        public ViewDWHRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(DWHModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<DWHModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(DWHModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DWH_List_Sftp_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.recorded_by });
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 999;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(DWHModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DWH_List_Proc";
            parameter.Parameters.Add(new Field { Name = "file_type", Value = model.file_type });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.recorded_by });
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(DWHModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(DWHModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<DWHModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
