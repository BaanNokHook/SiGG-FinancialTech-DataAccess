using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.MarketProcess;

namespace GM.DataAccess.Repositories.MarketProcess
{
    public class FloatingIndexRepository : IRepository<FloatingIndexModel>
    {
        private readonly IUnitOfWork _uow;

        public FloatingIndexRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(FloatingIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Floating_Index_History_310002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "floating_index_date", Value = model.floating_index_date });
            parameter.Parameters.Add(new Field { Name = "floating_index_code", Value = model.floating_index_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.effective_date });
            parameter.Parameters.Add(new Field { Name = "rate_on", Value = model.rate_on });
            parameter.Parameters.Add(new Field { Name = "rate_1week", Value = model.rate_1week });
            parameter.Parameters.Add(new Field { Name = "rate_1month", Value = model.rate_1month });
            parameter.Parameters.Add(new Field { Name = "rate_2month", Value = model.rate_2month });
            parameter.Parameters.Add(new Field { Name = "rate_3month", Value = model.rate_3month });
            parameter.Parameters.Add(new Field { Name = "rate_6month", Value = model.rate_6month });
            parameter.Parameters.Add(new Field { Name = "rate_9month", Value = model.rate_9month });
            parameter.Parameters.Add(new Field { Name = "rate_1year", Value = model.rate_1year });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("FloatingIndexResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<FloatingIndexModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(FloatingIndexModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(FloatingIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Floating_Index_History_310002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "floating_index_date", Value = model.floating_index_date });
            parameter.Parameters.Add(new Field { Name = "floating_index_code", Value = model.floating_index_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("FloatingIndexResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(FloatingIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Floating_Index_History_310002_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "floating_index_date", Value = model.floating_index_date });
            parameter.Parameters.Add(new Field { Name = "floating_index_code", Value = model.floating_index_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });

            parameter.ResultModelNames.Add("FloatingIndexResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(FloatingIndexModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Floating_Index_History_310002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "floating_index_date", Value = model.floating_index_date });
            parameter.Parameters.Add(new Field { Name = "floating_index_code", Value = model.floating_index_code });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "effective_date", Value = model.effective_date });
            parameter.Parameters.Add(new Field { Name = "rate_on", Value = model.rate_on });
            parameter.Parameters.Add(new Field { Name = "rate_1week", Value = model.rate_1week });
            parameter.Parameters.Add(new Field { Name = "rate_1month", Value = model.rate_1month });
            parameter.Parameters.Add(new Field { Name = "rate_2month", Value = model.rate_2month });
            parameter.Parameters.Add(new Field { Name = "rate_3month", Value = model.rate_3month });
            parameter.Parameters.Add(new Field { Name = "rate_6month", Value = model.rate_6month });
            parameter.Parameters.Add(new Field { Name = "rate_9month", Value = model.rate_9month });
            parameter.Parameters.Add(new Field { Name = "rate_1year", Value = model.rate_1year });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("FloatingIndexResultModel");
            return _uow.ExecNonQueryProc(parameter);

        }

        public ResultWithModel UpdateList(List<FloatingIndexModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
