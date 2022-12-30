using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class TraderLimitRepository : IRepository<TraderLimitModel>
    {
        private readonly IUnitOfWork _uow;

        public TraderLimitRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(TraderLimitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_930001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "limit_amount", Value = model.limit_amount });
            parameter.Parameters.Add(new Field { Name = "used_amount", Value = model.used_amount });
            parameter.Parameters.Add(new Field { Name = "available_amount", Value = model.available_amount });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "start_date", Value = model.start_date });
            parameter.Parameters.Add(new Field { Name = "expire_date", Value = model.expire_date });
            parameter.Parameters.Add(new Field { Name = "threshold_amount", Value = model.threshold_amount });
            parameter.Parameters.Add(new Field { Name = "threshold_percent", Value = model.threshold_percent });
            parameter.Parameters.Add(new Field { Name = "active_flag ", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "last_reset_date ", Value = model.last_reset_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by ", Value = model.create_by });
            parameter.ResultModelNames.Add("TraderLimitResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<TraderLimitModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(TraderLimitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_930001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("TraderLimitResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(TraderLimitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_930001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id ", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.ResultModelNames.Add("TraderLimitResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(TraderLimitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_930001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.ResultModelNames.Add("TraderLimitResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(TraderLimitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Limit_Trader_930001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "desk_group_id", Value = model.desk_group_id });
            parameter.Parameters.Add(new Field { Name = "limit_amount", Value = model.limit_amount });
            parameter.Parameters.Add(new Field { Name = "used_amount", Value = model.used_amount });
            parameter.Parameters.Add(new Field { Name = "available_amount", Value = model.available_amount });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "start_date", Value = model.start_date });
            parameter.Parameters.Add(new Field { Name = "expire_date", Value = model.expire_date });
            parameter.Parameters.Add(new Field { Name = "threshold_amount", Value = model.threshold_amount });
            parameter.Parameters.Add(new Field { Name = "threshold_percent", Value = model.threshold_percent });
            parameter.Parameters.Add(new Field { Name = "active_flag ", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "last_reset_date ", Value = model.last_reset_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by ", Value = model.update_by });
            parameter.ResultModelNames.Add("TraderLimitResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<TraderLimitModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
