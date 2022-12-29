using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceIssuer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceIssuerResRepository : IRepository<resIssuerHeader>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceIssuerResRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(resIssuerHeader model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Interface_Fits_Result_Log_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "channel_id", Value = model.channel });
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_code });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = "Issuer" });
            parameter.Parameters.Add(new Field { Name = "trans_date", Value = model.response_date });
            parameter.Parameters.Add(new Field { Name = "trans_time", Value = model.response_time });
            parameter.Parameters.Add(new Field { Name = "mode", Value = model.mode });
            var responseIssuer = (new { responseIssuer = model });
            parameter.Parameters.Add(new Field { Name = "value", Value = JsonConvert.SerializeObject(responseIssuer) });
            parameter.Parameters.Add(new Field { Name = "return_code", Value = model.response_code });
            parameter.Parameters.Add(new Field { Name = "return_msg", Value = model.response_message });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "WebService" });
            parameter.ResultModelNames.Add("FitsResultLogResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<resIssuerHeader> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(resIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(resIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(resIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(resIssuerHeader model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<resIssuerHeader> models)
        {
            throw new NotImplementedException();
        }
    }
}
