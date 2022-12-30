using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.Static;

namespace GM.DataAccess.Repositories.Static
{
    public class BusinessDateRepository : IBusinessDateRepository
    {
        private readonly IUnitOfWork _uow;

        public BusinessDateRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel GetBusinessDate(BusinessDateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Business_Date_List_Proc";
            parameter.ResultModelNames.Add("BusinessDateResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetBusinessDateOrSystemDate(BusinessDateModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_RpDate_List_Proc";
            parameter.ResultModelNames.Add("RpDateResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;

            return _uow.ExecDataProc(parameter);
        }
    }
}
