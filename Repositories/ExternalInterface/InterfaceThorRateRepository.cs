using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceThorRate;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceThorRateRepository : IRepository<InterfaceResRateHeaderThorRateModel>
    {
        private readonly IUnitOfWork _uow;

        public InterfaceThorRateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceResRateHeaderThorRateModel model)
        {
            ResultWithModel rwm = new ResultWithModel();
            foreach (var res in model.listResBody)
            {
                foreach (var item in res.money_market)
                {
                    BaseParameterModel parameter = new BaseParameterModel();
                    parameter.ProcedureName = "RP_Interface_Thor_Rate_Processing_Proc";
                    parameter.Parameters.Add(new Field { Name = "asof_date", Value = res.as_of_date });
                    parameter.Parameters.Add(new Field { Name = "curve_id", Value = res.curve_id });
                    parameter.Parameters.Add(new Field { Name = "ccy", Value = res.ccy });
                    parameter.Parameters.Add(new Field { Name = "index_type", Value = res.index });
                    parameter.Parameters.Add(new Field { Name = "tenor", Value = item.tenor });
                    parameter.Parameters.Add(new Field { Name = "rate", Value = item.rate });
                    parameter.Parameters.Add(new Field { Name = "spread", Value = item.spread });
                    parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "I" });
                    parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.recorded_by });
                    rwm = _uow.ExecNonQueryProc(parameter);
                }
            }
            return rwm;
        }

        public ResultWithModel AddList(List<InterfaceResRateHeaderThorRateModel> models)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Find(InterfaceResRateHeaderThorRateModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Get(InterfaceResRateHeaderThorRateModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceResRateHeaderThorRateModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Update(InterfaceResRateHeaderThorRateModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceResRateHeaderThorRateModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
