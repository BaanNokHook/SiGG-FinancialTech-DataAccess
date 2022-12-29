using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.InterfaceThorRate;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class ThorRateRepository : IRepository<ThorRateModel>
    {
        private readonly IUnitOfWork _uow;

        public ThorRateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ThorRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Rate_Processing_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "curve_id", Value = model.curve_id });
            parameter.Parameters.Add(new Field { Name = "ccy", Value = model.ccy });
            parameter.Parameters.Add(new Field { Name = "index_type", Value = model.index_type });
            parameter.Parameters.Add(new Field { Name = "tenor", Value = model.tenor });
            parameter.Parameters.Add(new Field { Name = "rate", Value = model.rate });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "C" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<ThorRateModel> models)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Find(ThorRateModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Get(ThorRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Rate_List_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date_from", Value = model.asof_date_from });
            parameter.Parameters.Add(new Field { Name = "asof_date_to", Value = model.asof_date_to });
            parameter.Parameters.Add(new Field { Name = "ccy", Value = model.ccy });
            parameter.Parameters.Add(new Field { Name = "mode", Value = model.mode });
            parameter.ResultModelNames.Add("ThorRateResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(ThorRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Rate_Processing_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "curve_id", Value = model.curve_id });
            parameter.Parameters.Add(new Field { Name = "ccy", Value = model.ccy });
            parameter.Parameters.Add(new Field { Name = "index_type", Value = model.index_type });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(ThorRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Thor_Rate_Processing_Proc";
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "curve_id", Value = model.curve_id });
            parameter.Parameters.Add(new Field { Name = "ccy", Value = model.ccy });
            parameter.Parameters.Add(new Field { Name = "index_type", Value = model.index_type });
            parameter.Parameters.Add(new Field { Name = "tenor", Value = model.tenor });
            parameter.Parameters.Add(new Field { Name = "rate", Value = model.rate });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "U" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<ThorRateModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
