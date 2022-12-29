using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface.ExchRateSummit;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceReqExchRateSummitRepository : IRepository<InterfaceReqExchRateHeaderSummitModel>
    {
        private readonly IUnitOfWork _uow;

        public InterfaceReqExchRateSummitRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceReqExchRateHeaderSummitModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel AddList(List<InterfaceReqExchRateHeaderSummitModel> models)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Find(InterfaceReqExchRateHeaderSummitModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Get(InterfaceReqExchRateHeaderSummitModel model)
        {
            throw new System.NotImplementedException();
        }

        public ResultWithModel Remove(InterfaceReqExchRateHeaderSummitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Summit_Update_Temp_Proc";
            parameter.Parameters.Add(new Field { Name = "as_of_date", Value = model.reqbody.as_of_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "D" });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = "Console" });
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel Update(InterfaceReqExchRateHeaderSummitModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_Exchange_Rate_Summit_Import_Proc"; // RP_Interface_Exch_Rate_Summit_Temp_To_Fact_Proc
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.reqbody.as_of_date });
            parameter.Parameters.Add(new Field { Name = "recorded_flag", Value = "Import" });
            parameter.ResultModelNames.Add("InterfaceResHeaderTicketSummit");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel UpdateList(List<InterfaceReqExchRateHeaderSummitModel> models)
        {
            throw new System.NotImplementedException();
        }
    }
}
