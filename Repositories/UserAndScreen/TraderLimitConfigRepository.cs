using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class TraderLimitConfigRepository : IRepository<TraderLimitConfigModel>
    {
        private readonly IUnitOfWork _uow;

        public TraderLimitConfigRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(TraderLimitConfigModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_Config_930002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "govt_short_limit", Value = model.govt_short_limit });
            parameter.Parameters.Add(new Field { Name = "govt_long_limit", Value = model.govt_long_limit });
            parameter.Parameters.Add(new Field { Name = "corp_limit", Value = model.corp_limit });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.effective_date });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("TraderLimitConfigResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<TraderLimitConfigModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(TraderLimitConfigModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_Config_930002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "limit_id", Value = model.limit_id });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.effective_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("TraderLimitConfigResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(TraderLimitConfigModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_Config_930002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "limit_id", Value = model.limit_id });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.effective_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("TraderLimitConfigResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(TraderLimitConfigModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_Config_930002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "limit_id", Value = model.limit_id });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.ResultModelNames.Add("TraderLimitConfigResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(TraderLimitConfigModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_Config_930002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "limit_id", Value = model.limit_id });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "govt_short_limit", Value = model.govt_short_limit });
            parameter.Parameters.Add(new Field { Name = "govt_long_limit", Value = model.govt_long_limit });
            parameter.Parameters.Add(new Field { Name = "corp_limit", Value = model.corp_limit });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.effective_date });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "U" });
            parameter.ResultModelNames.Add("TraderLimitConfigResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<TraderLimitConfigModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
