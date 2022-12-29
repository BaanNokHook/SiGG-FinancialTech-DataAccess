using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceCheckingEodRepository : IInterfaceCheckingEodRepository
    {
        private readonly IUnitOfWork _uow;
        public InterfaceCheckingEodRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Get()
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_checking_eod_List_Proc";
            //parameter.ResultModelNames.Add("InterfaceCheckingEodResultModel");
            parameter.Paging = new PagingModel(){ PageNumber = 1, RecordPerPage = 9999 };
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 9999;
            parameter.Orders = new List<OrderByModel>();
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Update(string taskName)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_checking_eod_Updatte_Proc";
            parameter.Parameters.Add(new Field { Name = "task_name", Value = taskName });
            return _uow.ExecNonQueryProc(parameter);
        }
    }
}
