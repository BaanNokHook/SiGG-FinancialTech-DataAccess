using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class CurrencyRepository : IRepository<CurrencyModel>
    {
        private readonly IUnitOfWork _uow;
        public CurrencyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(CurrencyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Currency_830001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cur_code", Value = model.cur_code });
            parameter.Parameters.Add(new Field { Name = "cur_desc", Value = model.cur_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("CurrencyResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<CurrencyModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CurrencyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Currency_830001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("CurrencyResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(CurrencyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Currency_830001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cur_code", Value = model.cur_code });
            parameter.Parameters.Add(new Field { Name = "cur_desc", Value = model.cur_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.ResultModelNames.Add("CurrencyResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CurrencyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Currency_830001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cur_code", Value = model.cur_code });
            parameter.Parameters.Add(new Field { Name = "cur_desc", Value = model.cur_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.ResultModelNames.Add("CurrencyResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(CurrencyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Currency_830001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cur_code", Value = model.cur_code });
            parameter.Parameters.Add(new Field { Name = "cur_desc", Value = model.cur_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.ResultModelNames.Add("CurrencyResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CurrencyModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
