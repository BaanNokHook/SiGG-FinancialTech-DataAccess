using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class ServiceInOutReqRepository : IRepository<ServiceInOutReqModel>
    {
        private readonly IUnitOfWork _uow;
        public ServiceInOutReqRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ServiceInOutReqModel model)
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

        public ResultWithModel AddList(List<ServiceInOutReqModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ServiceInOutReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ServiceInOutReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(ServiceInOutReqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ServiceInOutReqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Service_in_out_req_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "guid", Value = model.guid });
            parameter.Parameters.Add(new Field { Name = "svc_res", Value = model.svc_res });
            parameter.Parameters.Add(new Field { Name = "ref_id", Value = model.ref_id });
            parameter.Parameters.Add(new Field { Name = "status", Value = model.status });
            parameter.Parameters.Add(new Field { Name = "status_desc", Value = model.status_desc });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("LogInOutResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<ServiceInOutReqModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
