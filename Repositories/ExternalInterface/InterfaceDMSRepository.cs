using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceDMSRepository : IRepository<InterfaceDmsSftpModel>
    {
        private readonly IUnitOfWork _uow;

        public InterfaceDMSRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceDmsSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DMS_Proc";

            parameter.Parameters.Add(new Field { Name = "dms_name", Value = model.dms_name });
            parameter.Parameters.Add(new Field { Name = "asof_date", Value = model.asof_date });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("InterfaceDmsSftpResultModel");
            return _uow.ExecNonQueryProc(parameter);
        }

        public ResultWithModel AddList(List<InterfaceDmsSftpModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceDmsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceDmsSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "RP_Interface_DMS_List_Proc";
            parameter.Parameters.Add(new Field { Name = "dms_name", Value = model.dms_name });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });
            parameter.ResultModelNames.Add("InterfaceDmsResultModel");
            parameter.Paging = new PagingModel(){PageNumber = 1, RecordPerPage = 999999 };
            parameter.Orders = new List<OrderByModel>();
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(InterfaceDmsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceDmsSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceDmsSftpModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
