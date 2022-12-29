using System;
using System.Collections.Generic;
using System.Text;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class InterfaceNesRepository : IRepository<InterfaceNesSftpModel>
    {
        private readonly IUnitOfWork _uow;
        public InterfaceNesRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel Add(InterfaceNesSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<InterfaceNesSftpModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(InterfaceNesSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Get(InterfaceNesSftpModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Interface_NES_List_Proc";

            parameter.Parameters.Add(new Field { Name = "interface_date", Value = model.AsofDate });
            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });

            parameter.ResultModelNames.Add("InterfaceNesSftpResultModel");
            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 999999 };
            parameter.Orders = new List<OrderByModel>();

            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Remove(InterfaceNesSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(InterfaceNesSftpModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<InterfaceNesSftpModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
