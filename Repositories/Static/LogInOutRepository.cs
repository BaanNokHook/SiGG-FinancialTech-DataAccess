using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class LogInOutRepository : IRepository<LogInOutModel>
    {
        private readonly IUnitOfWork _uow;

        public LogInOutRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(LogInOutModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "GM_Service_in_out_req_Insert_Proc";

            parameter.Parameters.Add(new Field { Name = "guid", Value = model.guid });
            parameter.Parameters.Add(new Field { Name = "svc_req", Value = model.svc_req });
            parameter.Parameters.Add(new Field { Name = "svc_res", Value = model.svc_res });
            parameter.Parameters.Add(new Field { Name = "svc_type", Value = model.svc_type });
            parameter.Parameters.Add(new Field { Name = "module_name", Value = model.module_name });
            parameter.Parameters.Add(new Field { Name = "action_name", Value = model.action_name });
            parameter.Parameters.Add(new Field { Name = "ref_id", Value = model.ref_id });
            parameter.Parameters.Add(new Field { Name = "status", Value = model.status });
            parameter.Parameters.Add(new Field { Name = "status_desc", Value = model.status_desc });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("LogInOutResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<LogInOutModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(LogInOutModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(LogInOutModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Service_in_out_req_List_Proc";
            parameter.Parameters.Add(new Field { Name = "module_name", Value = model.module_name });
            parameter.Parameters.Add(new Field { Name = "action_name", Value = model.action_name });
            parameter.Parameters.Add(new Field { Name = "status", Value = model.status });
            parameter.Parameters.Add(new Field { Name = "create_date", Value = model.create_date });
            parameter.ResultModelNames.Add("LogInOutResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(LogInOutModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(LogInOutModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<LogInOutModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
