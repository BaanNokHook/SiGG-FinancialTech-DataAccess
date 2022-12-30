using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class TraderRepository : IRepository<TraderModel>
    {
        private readonly IUnitOfWork _uow;

        public TraderRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(TraderModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Trader_910004_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "trader_engname", Value = model.trader_engname });
            parameter.Parameters.Add(new Field { Name = "trader_thainame", Value = model.trader_thainame });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("TraderResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<TraderModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(TraderModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Trader_910004_List_Proc";
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.ResultModelNames.Add("TraderResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(TraderModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Trader_910004_List_Proc";
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "trader_engname", Value = model.trader_engname });
            parameter.Parameters.Add(new Field { Name = "trader_thainame", Value = model.trader_thainame });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.ResultModelNames.Add("TraderResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(TraderModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Trader_910004_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("TraderResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(TraderModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Trader_910004_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "trader_engname", Value = model.trader_engname });
            parameter.Parameters.Add(new Field { Name = "trader_thainame", Value = model.trader_thainame });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("TraderResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<TraderModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
