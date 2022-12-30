using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Security;

namespace GM.DataAccess.Repositories.Security
{
    public class SecurityAdditionalCodeRepository : IRepository<SecurityAdditionalCodeModel>
    {
        private readonly IUnitOfWork _uow;

        public SecurityAdditionalCodeRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(SecurityAdditionalCodeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<SecurityAdditionalCodeModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(SecurityAdditionalCodeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(SecurityAdditionalCodeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Additional_Code_810001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.ResultModelNames.Add("SecurityAdditionalCodeResultModel");
            parameter.Paging = new PagingModel(){PageNumber = 1, RecordPerPage = int.MaxValue};
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(SecurityAdditionalCodeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(SecurityAdditionalCodeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<SecurityAdditionalCodeModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
