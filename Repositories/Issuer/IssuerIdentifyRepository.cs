using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.CounterParty;
using System;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.Issuer
{
    public class IssuerIdentifyRepository : IRepository<IssuerIdentifyModel>
    {
        private readonly IUnitOfWork _uow;
        public IssuerIdentifyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(IssuerIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Identify_820002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "unique_id", Value = model.unique_id });
            parameter.Parameters.Add(new Field { Name = "identify_no", Value = model.identify_no });
            parameter.Parameters.Add(new Field { Name = "juris_reg_date", Value = model.juris_reg_date });
            parameter.Parameters.Add(new Field { Name = "reg_bus_ename", Value = model.reg_bus_ename });
            parameter.Parameters.Add(new Field { Name = "reg_bus_tname", Value = model.reg_bus_tname });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<IssuerIdentifyModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(IssuerIdentifyModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(IssuerIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Identify_820002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.ResultModelNames.Add("IssuerIdentifyResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 100;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(IssuerIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Identify_820002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "unique_id", Value = model.unique_id });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(IssuerIdentifyModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Issuer_Identify_820002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "issuer_id", Value = model.issuer_id });
            parameter.Parameters.Add(new Field { Name = "unique_id", Value = model.unique_id });
            parameter.Parameters.Add(new Field { Name = "identify_no", Value = model.identify_no });
            parameter.Parameters.Add(new Field { Name = "juris_reg_date", Value = model.juris_reg_date });
            parameter.Parameters.Add(new Field { Name = "reg_bus_ename", Value = model.reg_bus_ename });
            parameter.Parameters.Add(new Field { Name = "reg_bus_tname", Value = model.reg_bus_tname });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<IssuerIdentifyModel> models)
        {
            throw new NotImplementedException();
        }
    }
}