using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceSecurity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceSecurityResRepository : IRepository<resSecurityHeader>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceSecurityResRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(resSecurityHeader model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Interface_Fits_Result_Log_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "channel_id", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = "Security" });
            parameter.Parameters.Add(new Field { Name = "trans_date", Value = model.response_date });
            parameter.Parameters.Add(new Field { Name = "trans_time", Value = model.response_time });
            parameter.Parameters.Add(new Field { Name = "mode", Value = model.mode });
            var responseSecurity = (new { responseSecurity = model });
            parameter.Parameters.Add(new Field { Name = "value", Value = JsonConvert.SerializeObject(responseSecurity) });
            parameter.Parameters.Add(new Field { Name = "return_code", Value = model.response_code });
            parameter.Parameters.Add(new Field { Name = "return_msg", Value = model.response_message });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("FitsResultLogResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<resSecurityHeader> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(resSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(resSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(resSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(resSecurityHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<resSecurityHeader> models)
        {
            throw new NotImplementedException();
        }
    }
}
