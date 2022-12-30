using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class RoleRepository : IRepository<RoleModel>
    {
        private readonly IUnitOfWork _uow;

        public RoleRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RoleModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_920002_Insert_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "role_code", Value = model.role_code.Trim() });
            parameter.Parameters.Add(new Field { Name = "role_name", Value = model.role_name.Trim() });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("RoleResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<RoleModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RoleModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_920002_List_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });

            parameter.ResultModelNames.Add("RoleResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(RoleModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_920002_List_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "role_code", Value = model.role_code });
            parameter.Parameters.Add(new Field { Name = "role_name", Value = model.role_name });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });

            parameter.ResultModelNames.Add("RoleResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RoleModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_920002_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });

            parameter.ResultModelNames.Add("RoleResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(RoleModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_920002_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "role_code", Value = model.role_code.Trim() });
            parameter.Parameters.Add(new Field { Name = "role_name", Value = model.role_name.Trim() });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });

            parameter.ResultModelNames.Add("RoleResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RoleModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
