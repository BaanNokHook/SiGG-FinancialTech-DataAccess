using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceIssuer;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceIssuerImportRepository : IRepository<reqIssuer>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceIssuerImportRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(reqIssuer model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_820002_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_code", Value = model.RefCode });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.Function });
            parameter.ResultModelNames.Add("IssuerResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<reqIssuer> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(reqIssuer model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(reqIssuer model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(reqIssuer model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(reqIssuer model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<reqIssuer> models)
        {
            throw new NotImplementedException();
        }
    }
}
