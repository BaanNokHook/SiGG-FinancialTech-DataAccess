using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class UserActivityLogRepository : IRepository<ActivityLogModel>
    {
        private readonly IUnitOfWork _uow;

        public UserActivityLogRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ActivityLogModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<ActivityLogModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ActivityLogModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ActivityLogModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Report_User_Activity_Log_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.user_id });
            parameter.Parameters.Add(new Field { Name = "asof_date_from", Value = model.date_from });
            parameter.Parameters.Add(new Field { Name = "asof_date_to", Value = model.date_to });
            parameter.ResultModelNames.Add("UserResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(ActivityLogModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ActivityLogModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<ActivityLogModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
