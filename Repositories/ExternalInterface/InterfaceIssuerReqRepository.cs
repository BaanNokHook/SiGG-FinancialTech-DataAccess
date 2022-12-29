using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceIssuer;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceIssuerReqRepository : IRepository<reqIssuerHeader>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceIssuerReqRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(reqIssuerHeader model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Interface_Fits_Request_Log_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "channel_id", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = "Issuer" });
            parameter.Parameters.Add(new Field { Name = "trans_date", Value = model.request_date });
            parameter.Parameters.Add(new Field { Name = "trans_time", Value = DateTime.Now.ToString("HH:mm:ss") });
            parameter.Parameters.Add(new Field { Name = "mode", Value = model.mode });
            parameter.Parameters.Add(new Field { Name = "value", Value = model.JsonValues });
            parameter.Parameters.Add(new Field { Name = "count_data", Value = model.CountData });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("FitsRequestLogResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<reqIssuerHeader> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(reqIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(reqIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(reqIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(reqIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<reqIssuerHeader> models)
        {
            throw new NotImplementedException();
        }
    }
}
