using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class UserActiveRepository : IRepository<UserModel>
    {
        private readonly IUnitOfWork _uow;

        public UserActiveRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(UserModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<UserModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(UserModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(UserModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Report_User_Active_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.user_id });
            parameter.ResultModelNames.Add("UserResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(UserModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(UserModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<UserModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
