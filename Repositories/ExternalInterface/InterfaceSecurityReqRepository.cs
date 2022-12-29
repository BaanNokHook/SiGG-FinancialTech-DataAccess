using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceSecurity;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceSecurityReqRepository : IRepository<ReqSecurityHeader>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceSecurityReqRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqSecurityHeader model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Interface_Fits_Request_Log_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "channel_id", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = "Security" });
            parameter.Parameters.Add(new Field { Name = "trans_date", Value = model.request_date });
            parameter.Parameters.Add(new Field { Name = "trans_time", Value = DateTime.Now.ToString("HH:mm:ss") });
            parameter.Parameters.Add(new Field { Name = "mode", Value = model.mode });
            parameter.Parameters.Add(new Field { Name = "value", Value = model.jsonValues });
            parameter.Parameters.Add(new Field { Name = "count_data", Value = model.count_data });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("FitsRequestLogResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ReqSecurityHeader> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ReqSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ReqSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(ReqSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ReqSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<ReqSecurityHeader> models)
        {
            throw new NotImplementedException();
        }
    }
}
