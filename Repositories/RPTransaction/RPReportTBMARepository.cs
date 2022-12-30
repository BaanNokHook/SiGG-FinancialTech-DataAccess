using System.Data;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.RPTransaction;

namespace GM.DataAccess.Repositories.RPTransaction
{
    public class RPReportTBMARepository : IRPReportTBMARepository
    {
        private readonly IUnitOfWork _uow;

        public RPReportTBMARepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel GetList(RPTransModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Tbma_110004_List_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
            parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            parameter.ResultModelNames.Add("RPReportTBMATableResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        //exportType = Export, ExportAll, ReportTBMA
        public ResultWithModel GetDetail(RPTransModel model, string exportType)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Report_Tbma_110004_Detail_Proc";
            parameter.Parameters.Add(new Field { Name = "trans_no", Value = model.trans_no });

            if (exportType == "ExportAll")
            {
                parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = model.from_trade_date });
                parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = model.to_trade_date });
            }
            else
            {
                parameter.Parameters.Add(new Field { Name = "from_trade_date", Value = null });
                parameter.Parameters.Add(new Field { Name = "to_trade_date", Value = null });
            }

            parameter.Parameters.Add(new Field { Name = "counter_party_code", Value = model.counter_party_code });
            parameter.Parameters.Add(new Field { Name = "trans_deal_type", Value = model.trans_deal_type });
            parameter.Parameters.Add(new Field { Name = "port", Value = model.port });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.Parameters.Add(new Field { Name = "export_type", Value = exportType });
            parameter.ResultModelNames.Add("RPReportTBMADetailResultModel");
            parameter.Paging = model.paging;
            return _uow.ExecDataProc(parameter);
        }
    }
}
