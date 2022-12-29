using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.GLProcess;

namespace GM.DataAccess.Repositories.GLProcess
{
    public class GLAccountCodeRepository : IRepository<GLAccountCodeModel>
    {
        private readonly IUnitOfWork _uow;

        public GLAccountCodeRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(GLAccountCodeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Account_Code_510001_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "account_num", Value = model.account_num });
            parameter.Parameters.Add(new Field { Name = "account_name", Value = model.account_name });
            parameter.Parameters.Add(new Field { Name = "acct_port", Value = model.acct_port });
            parameter.Parameters.Add(new Field { Name = "exp_acct_num", Value = model.exp_acct_num });
            parameter.Parameters.Add(new Field { Name = "acct_remark", Value = model.acct_remark });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("GLAccountCodeResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<GLAccountCodeModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(GLAccountCodeModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(GLAccountCodeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Account_Code_510001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "account_num", Value = model.account_num });
            parameter.Parameters.Add(new Field { Name = "account_name ", Value = model.account_name });
            parameter.Parameters.Add(new Field { Name = "acct_port", Value = model.acct_port });
            parameter.ResultModelNames.Add("GLAccountCodeResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(GLAccountCodeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Account_Code_510001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "account_num", Value = model.account_num });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.ResultModelNames.Add("GLAccountCodeResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(GLAccountCodeModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_GL_Account_Code_510001_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "account_num", Value = model.account_num });
            parameter.Parameters.Add(new Field { Name = "account_name", Value = model.account_name });
            parameter.Parameters.Add(new Field { Name = "acct_port", Value = model.acct_port });
            parameter.Parameters.Add(new Field { Name = "exp_acct_num", Value = model.exp_acct_num });
            parameter.Parameters.Add(new Field { Name = "acct_remark", Value = model.acct_remark });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.ResultModelNames.Add("GLAccountCodeResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<GLAccountCodeModel> models)
        {
            throw new NotImplementedException();
        }
    }
}