using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class ConfigRepository : IRepository<ConfigParameterModel>
    {
        private readonly IUnitOfWork _uow;

        public ConfigRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ConfigParameterModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<ConfigParameterModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(ConfigParameterModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(ConfigParameterModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = model.ProcedureName;
            if (model.Parameters.Count > 0)
            {
                parameter.Parameters.AddRange(model.Parameters);
            }
            parameter.ResultModelNames.Add(model.ModelResult);
            parameter.Paging = model.Paging;
            parameter.Orders = model.OrdersBy;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(ConfigParameterModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(ConfigParameterModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = model.ProcedureName;
            if (model.Parameters.Count > 0)
            {
                parameter.Parameters.AddRange(model.Parameters);
            }
            parameter.ResultModelNames.Add(model.ModelResult);
            parameter.Paging = model.Paging;
            parameter.Orders = model.OrdersBy;
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<ConfigParameterModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
