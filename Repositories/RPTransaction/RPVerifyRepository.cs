using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.RPTransaction
{
    public class RPVerifyRepository : IRPVerifyRepository
    {
        private readonly IUnitOfWork _uow;

        public RPVerifyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Verify_110003_List_Proc";

            parameter.Parameters.Add(new Field { Name = "from_trans_no", Value = model.from_trans_no });
            parameter.Parameters.Add(new Field { Name = "to_trans_no", Value = model.to_trans_no });
            parameter.Parameters.Add(new Field { Name = "repo_deal_type", Value = model.repo_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "trans_type", Value = model.trans_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "purpose", Value = model.purpose });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.Parameters.Add(new Field { Name = "from_settlement_date", Value = model.from_settlement_date });
            parameter.Parameters.Add(new Field { Name = "to_settlement_date", Value = model.to_settlement_date });
            parameter.Parameters.Add(new Field { Name = "from_maturity_date", Value = model.from_maturity_date });
            parameter.Parameters.Add(new Field { Name = "to_maturity_date", Value = model.to_maturity_date });
            parameter.Parameters.Add(new Field { Name = "deal_period", Value = model.deal_period });
            parameter.Parameters.Add(new Field { Name = "cur", Value = model.cur });
            parameter.Parameters.Add(new Field { Name = "trans_status", Value = model.trans_status });
            parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            parameter.Parameters.Add(new Field { Name = "trader_id", Value = model.trader_id });
            parameter.Parameters.Add(new Field { Name = "user_id", Value = model.user_id });
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetColl(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Verify_110003_Coll_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.ResultModelNames.Add("RPTransColateralResultModel");
            parameter.Paging = new PagingModel(){PageNumber = 1, RecordPerPage = 100};
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Update(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Verify_110003_Update_Proc";
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            parameter.Parameters.Add(new Field { Name = "deal_remark", Value = model.deal_remark });
            parameter.Parameters.Add(new Field { Name = "commentaries", Value = model.commentaries });
            parameter.ResultModelNames.Add("RPTransResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
