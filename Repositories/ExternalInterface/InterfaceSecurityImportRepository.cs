using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceSecurity;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceSecurityImportRepository : IRepository<ReqSecurity>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceSecurityImportRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqSecurity model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_810001_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_code", Value = model.RefCode });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.Function });
            parameter.ResultModelNames.Add("SecurityResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ReqSecurity> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ReqSecurity model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ReqSecurity model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(ReqSecurity model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ReqSecurity model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<ReqSecurity> models)
        {
            throw new NotImplementedException();
        }
    }
}
