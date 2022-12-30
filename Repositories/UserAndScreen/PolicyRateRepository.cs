using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class PolicyRateRepository : IRepository<PolicyRateModel>
    {
        private readonly IUnitOfWork _uow;

        public PolicyRateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(PolicyRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Policy_Rate_930002_Insert_Proc";
            parameter.Parameters.Add(new Field { Name = "policy_date", Value = model.policy_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund_date", Value = model.cost_of_fund_date });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund_rate", Value = model.cost_of_fund_rate });
            parameter.Parameters.Add(new Field { Name = "remark", Value = model.remark });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("PolicyRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<PolicyRateModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(PolicyRateModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(PolicyRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Policy_Rate_930002_List_Proc";
            parameter.Parameters.Add(new Field { Name = "policy_date", Value = model.policy_date });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund_date ", Value = model.cost_of_fund_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.ResultModelNames.Add("PolicyRateResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(PolicyRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Policy_Rate_930002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "policy_date", Value = model.policy_date });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.ResultModelNames.Add("PolicyRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(PolicyRateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Policy_Rate_930002_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "policy_date", Value = model.policy_date });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund_date", Value = model.cost_of_fund_date });
            parameter.Parameters.Add(new Field { Name = "cost_of_fund_rate", Value = model.cost_of_fund_rate });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "remark", Value = model.remark });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.ResultModelNames.Add("PolicyRateResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<PolicyRateModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
