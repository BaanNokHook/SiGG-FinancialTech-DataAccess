using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class UserSignNameRepository : IRepository<UserSignNameModel>
    {
        private readonly IUnitOfWork _uow;

        public UserSignNameRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(UserSignNameModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_UserSignName_830008_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "FNAME", Value = model.fname });
            parameter.Parameters.Add(new Field { Name = "POSITION", Value = model.position });
            parameter.Parameters.Add(new Field { Name = "ACTIVE_FLAG", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("UserSignNameResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<UserSignNameModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(UserSignNameModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_UserSignName_830008_List_Proc";

            parameter.Parameters.Add(new Field { Name = "ID", Value = model.id });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("UserSignNameResultModel");
            parameter.Paging = model.paging;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(UserSignNameModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_UserSignName_830008_List_Proc";
            parameter.Parameters.Add(new Field { Name = "ID", Value = model.id });
            parameter.Parameters.Add(new Field { Name = "FNAME", Value = model.fname });
            parameter.Parameters.Add(new Field { Name = "POSITION", Value = model.position });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("UserSignNameResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(UserSignNameModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_UserSignName_830008_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "ID", Value = model.id });
            parameter.Parameters.Add(new Field { Name = "FNAME", Value = model.fname });
            parameter.Parameters.Add(new Field { Name = "POSITION", Value = model.position });
            parameter.Parameters.Add(new Field { Name = "ACTIVE_FLAG", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = 'D' });
            parameter.ResultModelNames.Add("UserSignNameResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(UserSignNameModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_UserSignName_830008_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "ID", Value = model.id });
            parameter.Parameters.Add(new Field { Name = "FNAME", Value = model.fname });
            parameter.Parameters.Add(new Field { Name = "POSITION", Value = model.position });
            parameter.Parameters.Add(new Field { Name = "ACTIVE_FLAG", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("UserSignNameResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<UserSignNameModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
