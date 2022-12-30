using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.RPTransaction
{
    public class RPMaturityRepository : IRPMaturityRepository
    {
        private readonly IUnitOfWork _uow;

        public RPMaturityRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Maturity_120003_List_Proc";
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
            parameter.ResultModelNames.Add("RPTransResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetColl(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Transaction_Maturity_120003_Coll_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            //TODO change ResultModelNames 'RPTransColateralResultModel' to 'RPTransCollateralResultModel'
            parameter.ResultModelNames.Add("RPTransColateralResultModel");
            parameter.Paging = new PagingModel(){PageNumber = 1, RecordPerPage = 100};
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Update(RPTransModel model)
        {
            BaseParameterModel Parameter = new BaseParameterModel();
            Parameter.ProcedureName = "RP_Transaction_Maturity_120003_Update_Proc";
            Parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.update_by });
            Parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });
            Parameter.Parameters.Add(new Field { Name = "trans_state", Value = model.trans_state });
            Parameter.Parameters.Add(new Field { Name = "payment_method", Value = model.payment_method });
            Parameter.Parameters.Add(new Field { Name = "trans_mt_code", Value = model.trans_mt_code });
            Parameter.Parameters.Add(new Field { Name = "margins_payment_method", Value = model.payment_method });
            Parameter.Parameters.Add(new Field { Name = "margins_mt_code", Value = model.margins_mt_code });
            Parameter.Parameters.Add(new Field { Name = "deal_remark", Value = model.deal_remark });
            Parameter.Parameters.Add(new Field { Name = "commentaries", Value = model.commentaries });
            Parameter.Parameters.Add(new Field { Name = "nosto_vosto_code", Value = model.nosto_vosto_code });
            Parameter.ResultModelNames.Add("RPTransResultModel");
            return _uow.ExecNonQueryProc(Parameter);
        }
    }
}
