using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceDWHRepository : IInterfaceDWHRepository
    {
        private readonly IUnitOfWork _uow;

        public InterfaceDWHRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceDwhSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DWH_Proc";
            parameter.Parameters.Add(new Field { Name = "file_type", Value = model.file_type });
            parameter.Parameters.Add(new Field { Name = "interface_date", Value = model.asof_date });
            parameter.ResultModelNames.Add("InterfaceDwhSftpResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel GetSftp(InterfaceDwhSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DWH_List_Sftp_Proc";
            parameter.Parameters.Add(new Field { Name = "type", Value = model.type });
            parameter.Parameters.Add(new Field { Name = "curtype", Value = model.cur_type });
            parameter.ResultModelNames.Add("InterfaceDwhSftpResultModel");
            parameter.Paging = model.paging;
            parameter.Orders = model.ordersby;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel GetList(InterfaceDwhSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DWH_List_Proc";
            parameter.Parameters.Add(new Field { Name = "file_type", Value = model.file_type });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("InterfaceDwhResultModel");
            parameter.Paging = new PagingModel(){ PageNumber = 1 , RecordPerPage = 100000 };
            parameter.Orders = new List<OrderByModel>();
            return _uow.ExecDataProc(parameter);
        }
    }
}
