using System;
using System.Collections.Generic;
using System.Text;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.ExternalInterface;

namespace GM.DataAccess.Repositories.ExternalInterface
{
    public class ExportUserProfileRepository: IExportUserProfileRepository
    {
        private readonly IUnitOfWork _uow;
        public ExportUserProfileRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultWithModel GetUserProfileMonthly(ExportUserProfileMonthlyMailModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();

            parameter.ProcedureName = "RP_Report_UserProfile_Monthly_List_Proc";

            parameter.Parameters.Add(new Field { Name = "recorded_by", Value = model.create_by });


            parameter.Paging = new PagingModel() { PageNumber = 1, RecordPerPage = 999999 };
            parameter.Orders = new List<OrderByModel>();

            return _uow.ExecDataProc(parameter);
        }
    }
}