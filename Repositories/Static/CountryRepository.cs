using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Static
{
    public class CountryRepository : IRepository<CountryModel>
    {
        private readonly IUnitOfWork _uow;
        public CountryRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(CountryModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Country_830003_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "country_code", Value = model.country_code });
            parameter.Parameters.Add(new Field { Name = "country_desc", Value = model.country_desc });
            parameter.Parameters.Add(new Field { Name = "domicile_code", Value = model.domicile_code });
            parameter.Parameters.Add(new Field { Name = "domicile_desc", Value = model.domicile_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("CountryResultModel");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<CountryModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(CountryModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Country_830003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "country_id", Value = model.country_id });
            parameter.ResultModelNames.Add("CountryResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(CountryModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Country_830003_List_Proc";
            parameter.Parameters.Add(new Field { Name = "country_id", Value = model.country_id });
            parameter.Parameters.Add(new Field { Name = "country_code", Value = model.country_code });
            parameter.Parameters.Add(new Field { Name = "country_desc", Value = model.country_desc });
            parameter.Parameters.Add(new Field { Name = "domicile_code", Value = model.domicile_code });
            parameter.Parameters.Add(new Field { Name = "domicile_desc", Value = model.domicile_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.ResultModelNames.Add("CountryResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(CountryModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Country_830003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "country_id", Value = model.country_id });
            parameter.Parameters.Add(new Field { Name = "country_code", Value = model.country_code });
            parameter.Parameters.Add(new Field { Name = "country_desc", Value = model.country_desc });
            parameter.Parameters.Add(new Field { Name = "domicile_code", Value = model.domicile_code });
            parameter.Parameters.Add(new Field { Name = "domicile_desc", Value = model.domicile_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.ResultModelNames.Add("CountryResultModel");

            return _uow.ExecNonQueryProc(parameter);

        }

        public ResultWithModel Update(CountryModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Country_830003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "country_id", Value = model.country_id });
            parameter.Parameters.Add(new Field { Name = "country_code", Value = model.country_code });
            parameter.Parameters.Add(new Field { Name = "country_desc", Value = model.country_desc });
            parameter.Parameters.Add(new Field { Name = "domicile_code", Value = model.domicile_code });
            parameter.Parameters.Add(new Field { Name = "domicile_desc", Value = model.domicile_desc });
            parameter.Parameters.Add(new Field { Name = "active_flag", Value = model.active_flag });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.ResultModelNames.Add("CountryResultModels");

            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<CountryModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
