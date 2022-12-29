using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;
using System.Collections.Generic;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceFxRepository : IInterfaceFxRepository
    {
        private readonly IUnitOfWork _uow;
        public InterfaceFxRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel GetTransaction(InterfaceFxReconcileSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Interface_FX_Reconcile_List_Proc";

            parameter.Parameters.Add(new Field { Name = "interface_date", Value = model.AsofDate });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("InterfaceFxReconcileResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 999999 };
            parameter.Orders = new List<OrderByModel>();

            return _uow.ExecDataProc(parameter);

        }

        public ResultWithModel GetPosition(InterfaceFxReconcileSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Interface_FX_Reconcile_GL_List_Proc";

            parameter.Parameters.Add(new Field { Name = "interface_date", Value = model.AsofDate });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("InterfaceFxReconcileGLResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 999999 };
            parameter.Orders = new List<OrderByModel>();

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetPostingEvent(InterfaceFxReconcileSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Interface_FX_Reconcile_PostingEvent_List_Proc";

            parameter.Parameters.Add(new Field { Name = "interface_date", Value = model.AsofDate });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("InterfaceFxReconcilePostingEventResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 999999 };
            parameter.Orders = new List<OrderByModel>();

            return _uow.ExecDataProc(parameter);
        }

    }
}
