using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Security;

namespace GM.DataAccess.Repositories.Security
{
    public class SecurityGuarantorRepository : IRepository<SecurityGuarantorModel>
    {
        private readonly IUnitOfWork _uow;

        public SecurityGuarantorRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(SecurityGuarantorModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Guarantor_810001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "guarantor_code", Value = model.guarantor_code });
            parameter.Parameters.Add(new Field { Name = "guarantor_percent", Value = model.guarantor_percent });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<SecurityGuarantorModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(SecurityGuarantorModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(SecurityGuarantorModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Guarantor_810001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.ResultModelNames.Add("SecurityGuarantorsResultModel");
            parameter.Paging = new PagingModel(){PageNumber = 1, RecordPerPage = Int32.MaxValue};
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(SecurityGuarantorModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Guarantor_810001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "guarantor_code", Value = model.guarantor_code });
            parameter.Parameters.Add(new Field { Name = "guarantor_percent", Value = model.guarantor_percent });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(SecurityGuarantorModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Security_Guarantor_810001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "guarantor_code", Value = model.guarantor_code });
            parameter.Parameters.Add(new Field { Name = "guarantor_percent", Value = model.guarantor_percent });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<SecurityGuarantorModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
