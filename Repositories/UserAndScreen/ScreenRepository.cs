using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class ScreenRepository: IRepository<ScreenModel>
    {
        private readonly IUnitOfWork _uow;

        public ScreenRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Screen_920001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "screen_name", Value = model.screen_name });
            parameter.Parameters.Add(new Field { Name = "controller", Value = model.controller });
            parameter.Parameters.Add(new Field { Name = "row_order", Value = model.row_order });
            parameter.Parameters.Add(new Field { Name = "operation_id", Value = model.operation_id });
            parameter.Parameters.Add(new Field { Name = "parent_screen_id", Value = model.parent_screen_id });
            parameter.Parameters.Add(new Field { Name = "icon", Value = model.icon });
            parameter.Parameters.Add(new Field { Name = "storeproc_no", Value = model.storeproc_no });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("ScreenResultModels");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ScreenModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Screen_920001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.ResultModelNames.Add("ScreenResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(ScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Screen_920001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.Parameters.Add(new Field { Name = "screen_name", Value = model.screen_name });
            parameter.Parameters.Add(new Field { Name = "controller", Value = model.controller });
            parameter.Parameters.Add(new Field { Name = "action", Value = model.action });
            parameter.Parameters.Add(new Field { Name = "operation_id", Value = model.operation_id });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "parent_screen_id", Value = model.parent_screen_id });
            parameter.Parameters.Add(new Field { Name = "icon", Value = model.icon });
            parameter.ResultModelNames.Add("RolesScreenMappingResultModels");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(ScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Screen_920001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("ScreenResultModels");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(ScreenModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Screen_920001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "screen_id", Value = model.screen_id });
            parameter.Parameters.Add(new Field { Name = "screen_name", Value = model.screen_name });
            parameter.Parameters.Add(new Field { Name = "controller", Value = model.controller });
            parameter.Parameters.Add(new Field { Name = "row_order", Value = model.row_order });
            parameter.Parameters.Add(new Field { Name = "operation_id", Value = model.operation_id });
            parameter.Parameters.Add(new Field { Name = "parent_screen_id", Value = model.parent_screen_id });
            parameter.Parameters.Add(new Field { Name = "icon", Value = model.icon });
            parameter.Parameters.Add(new Field { Name = "storeproc_no", Value = model.storeproc_no });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("ScreenResultModels");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<ScreenModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
