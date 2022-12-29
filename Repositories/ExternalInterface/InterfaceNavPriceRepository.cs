using System;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.InterfaceNavPrice;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceNavPriceRepository : IInterfaceNavPriceRepository
    {
        private readonly IUnitOfWork _uow;

        public InterfaceNavPriceRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(ReqNavPriceList model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Nav_Price_Insert_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.ref_no });
            parameter.Parameters.Add(new Field { Name = "source_name", Value = model.source_name });
            parameter.Parameters.Add(new Field { Name = "asofdate", Value = model.asofdate });
            parameter.Parameters.Add(new Field { Name = "fund_type", Value = model.fund_type });
            parameter.Parameters.Add(new Field { Name = "investment_type", Value = model.investment_type });
            parameter.Parameters.Add(new Field { Name = "issuer_code", Value = model.issuer_code });
            parameter.Parameters.Add(new Field { Name = "custodian_code", Value = model.custodian_code });
            parameter.Parameters.Add(new Field { Name = "fund_name_th", Value = model.fund_name_th });
            parameter.Parameters.Add(new Field { Name = "fund_name_eng", Value = model.fund_name_eng });
            parameter.Parameters.Add(new Field { Name = "symbol", Value = model.symbol });
            parameter.Parameters.Add(new Field { Name = "nav", Value = model.nav });
            parameter.Parameters.Add(new Field { Name = "nav_per_unit", Value = model.nav_per_unit });
            parameter.Parameters.Add(new Field { Name = "nav_per_unit_change", Value = model.nav_per_unit_change });
            parameter.Parameters.Add(new Field { Name = "xd_date", Value = model.xd_date });
            parameter.Parameters.Add(new Field { Name = "sell_price", Value = model.sell_price });
            parameter.Parameters.Add(new Field { Name = "buy_price", Value = model.buy_price });
            parameter.Parameters.Add(new Field { Name = "import_by", Value = model.import_by });

            parameter.ResultModelNames.Add("NavPriceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Remove(ReqNavPrice model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Nav_Price_Update_Temp_Proc";

            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.datas.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.datas.create_by });

            parameter.ResultModelNames.Add("NavPriceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Import(ReqNavPrice model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Nav_Price_Import_Proc";
            parameter.Parameters.Add(new Field { Name = "ref_no", Value = model.datas.ref_no });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.datas.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.datas.create_by });

            parameter.ResultModelNames.Add("NavPriceResultModel");
            return _uow.ExecNonQueryProc(parameter);

        }

    }


}
