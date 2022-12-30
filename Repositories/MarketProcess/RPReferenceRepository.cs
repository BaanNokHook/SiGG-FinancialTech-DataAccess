using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.MarketProcess;

namespace GM.DataAccess.Repositories.MarketProcess
{
    public class RPReferenceRepository : IRepository<RPReferenceModel>
    {
        private readonly IUnitOfWork _uow;

        public RPReferenceRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(RPReferenceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Market_Price_310001_Insert_Proc";

            parameter.Parameters.Add(new Field { Name = "price_source", Value = model.price_source });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = model.marketdate_t });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "avgbidding", Value = model.avgbidding });
            parameter.Parameters.Add(new Field { Name = "govtinterpolatedyield", Value = model.govtinterpolatedyield });
            parameter.Parameters.Add(new Field { Name = "ttm", Value = model.ttm });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "referenceyield", Value = model.referenceyield });
            parameter.Parameters.Add(new Field { Name = "settlementdate", Value = model.settlementdate });
            parameter.Parameters.Add(new Field { Name = "ai", Value = model.ai });
            parameter.Parameters.Add(new Field { Name = "gross_price", Value = model.gross_price });
            parameter.Parameters.Add(new Field { Name = "clean_price", Value = model.clean_price });
            parameter.Parameters.Add(new Field { Name = "modifiedduration", Value = model.modifiedduration });
            parameter.Parameters.Add(new Field { Name = "convexity", Value = model.convexity });
            parameter.Parameters.Add(new Field { Name = "processdate", Value = model.processdate });
            parameter.Parameters.Add(new Field { Name = "bondtype", Value = model.bondtype });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("RPRefereceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<RPReferenceModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(RPReferenceModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(RPReferenceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "Rp_Market_Price_310001_List_Proc";
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "instrument_code", Value = model.instrument_code });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "price_source", Value = model.price_source });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = model.marketdate_t });
            parameter.ResultModelNames.Add("RPRefereceResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(RPReferenceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Market_Price_310001_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "price_source", Value = model.price_source });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = model.marketdate_t });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });

            parameter.ResultModelNames.Add("RPRefereceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(RPReferenceModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Market_Price_310001_Update_Proc";

            parameter.Parameters.Add(new Field { Name = "price_source", Value = model.price_source });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "instrument_id", Value = model.instrument_id });
            parameter.Parameters.Add(new Field { Name = "marketdate_t", Value = model.marketdate_t });
            parameter.Parameters.Add(new Field { Name = "maturity_date", Value = model.maturity_date });
            parameter.Parameters.Add(new Field { Name = "avgbidding", Value = model.avgbidding });
            parameter.Parameters.Add(new Field { Name = "govtinterpolatedyield", Value = model.govtinterpolatedyield });
            parameter.Parameters.Add(new Field { Name = "ttm", Value = model.ttm });
            parameter.Parameters.Add(new Field { Name = "spread", Value = model.spread });
            parameter.Parameters.Add(new Field { Name = "referenceyield", Value = model.referenceyield });
            parameter.Parameters.Add(new Field { Name = "settlementdate", Value = model.settlementdate });
            parameter.Parameters.Add(new Field { Name = "ai", Value = model.ai });
            parameter.Parameters.Add(new Field { Name = "gross_price", Value = model.gross_price });
            parameter.Parameters.Add(new Field { Name = "clean_price", Value = model.clean_price });
            parameter.Parameters.Add(new Field { Name = "modifiedduration", Value = model.modifiedduration });
            parameter.Parameters.Add(new Field { Name = "convexity", Value = model.convexity });
            parameter.Parameters.Add(new Field { Name = "processdate", Value = model.processdate });
            parameter.Parameters.Add(new Field { Name = "bondtype", Value = model.bondtype });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("RPRefereceResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<RPReferenceModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
