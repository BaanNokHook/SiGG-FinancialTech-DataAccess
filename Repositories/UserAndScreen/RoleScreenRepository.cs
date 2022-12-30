using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class RoleScreenRepository : IRoleScreenRepository
    {
        private readonly IUnitOfWork _uow;

        public RoleScreenRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RoleAndScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RoleAndScreen_920002_Insert_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.Parameters.Add(new Field { Name = "view_flag", Value = model.view_flag });
            parameter.Parameters.Add(new Field { Name = "create_flag", Value = model.create_flag });
            parameter.Parameters.Add(new Field { Name = "update_flag", Value = model.update_flag });
            parameter.Parameters.Add(new Field { Name = "delete_flag", Value = model.delete_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("RoleAndScreenResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<RoleAndScreenModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RoleAndScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RoleAndScreen_920002_List_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });

            parameter.ResultModelNames.Add("RoleAndScreenResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(RoleAndScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RoleAndScreen_920002_List_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "role_name", Value = model.role_name });
            parameter.Parameters.Add(new Field { Name = "screen_name", Value = model.screen_name });

            parameter.ResultModelNames.Add("RoleAndScreenResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RoleAndScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RoleAndScreen_920002_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });

            parameter.ResultModelNames.Add("RoleAndScreenResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel ScreenMenu(string username)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Role_Set_Up_920002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = username });
            parameter.ResultModelNames.Add("RolesScreenMappingResultModels");
            parameter.Paging.PageNumber = 0;
            parameter.Paging.RecordPerPage = 0;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Update(RoleAndScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RoleAndScreen_920002_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "role_id", Value = model.role_id });
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.Parameters.Add(new Field { Name = "view_flag", Value = model.view_flag });
            parameter.Parameters.Add(new Field { Name = "create_flag", Value = model.create_flag });
            parameter.Parameters.Add(new Field { Name = "update_flag", Value = model.update_flag });
            parameter.Parameters.Add(new Field { Name = "delete_flag", Value = model.delete_flag });

            parameter.ResultModelNames.Add("RoleAndScreenResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RoleAndScreenModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
