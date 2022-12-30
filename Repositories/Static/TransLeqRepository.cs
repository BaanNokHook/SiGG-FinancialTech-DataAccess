using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class TransLeqRepository : IRepository<TransLeqModel>
    {
        private readonly IUnitOfWork _uow;

        public TransLeqRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(TransLeqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<TransLeqModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(TransLeqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(TransLeqModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "LEQ";
            parameter.Parameters.Add(new Field { Name = "asof", Value = model.asof_date });
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(TransLeqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(TransLeqModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<TransLeqModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
