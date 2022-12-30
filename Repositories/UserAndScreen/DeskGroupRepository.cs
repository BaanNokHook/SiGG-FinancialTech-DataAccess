using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class DeskGroupRepository : IRepository<DeskGroupModel>
    {
        private readonly IUnitOfWork _uow;

        public DeskGroupRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(DeskGroupModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Desk_Group_910003_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "desk_group_name", Value = model.desk_group_name != null ? model.desk_group_name.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("DeskGroupResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<DeskGroupModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(DeskGroupModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Desk_Group_910003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.ResultModelNames.Add("DeskGroupResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(DeskGroupModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Desk_Group_910003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_name", Value = model.desk_group_name });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.ResultModelNames.Add("DeskGroupResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(DeskGroupModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Desk_Group_910003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("DeskGroupResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(DeskGroupModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Desk_Group_910003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_name", Value = model.desk_group_name != null ? model.desk_group_name.Trim() : null });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("DeskGroupResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<DeskGroupModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
