using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class ViewDMSRepository : IRepository<DMSModel>
    {
        private readonly IUnitOfWork _uow;
        public ViewDMSRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(DMSModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<DMSModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(DMSModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(DMSModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DMS_List_Proc";
            parameter.Parameters.Add(new Field { Name = "dms_name", Value = model.dms_name });
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(DMSModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(DMSModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<DMSModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
