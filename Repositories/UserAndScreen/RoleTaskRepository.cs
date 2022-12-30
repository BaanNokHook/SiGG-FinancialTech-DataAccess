using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class RoleTaskRepository : IRepository<RoleTaskModel>
    {
        private readonly IUnitOfWork _uow;

        public RoleTaskRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RoleTaskModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<RoleTaskModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RoleTaskModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RoleTaskModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_Task_List_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "businessDate", Value = model.BusinessDate });

            parameter.ResultModelNames.Add("RoleTaskResultModel");
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RoleTaskModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(RoleTaskModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<RoleTaskModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
