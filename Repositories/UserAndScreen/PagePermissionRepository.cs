using System;
using System.Collections.Generic;
using GM.DataAccess.Infrastructure;
using GM.DataAccess.UnitOfWork;
using GM.Model.Common;
using GM.Model.UserAndScreen;

namespace GM.DataAccess.Repositories.UserAndScreen
{
    public class PagePermissionRepository : IRepository<PagePermissionModel>
    {
        private readonly IUnitOfWork _uow;

        public PagePermissionRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public ResultWithModel Add(PagePermissionModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel AddList(List<PagePermissionModel> models)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Find(PagePermissionModel model)
        {
            BaseParameterModel parameter = new BaseParameterModel();
            parameter.ProcedureName = "GM_Page_Permission_Proc";
            parameter.Parameters.Add(new Field { Name = "userID", Value = model.UserID });
            parameter.Parameters.Add(new Field { Name = "controller", Value = model.Controller });
            parameter.ResultModelNames.Add("PagePermissionResultModel");
            parameter.Paging.PageNumber = 1;
            parameter.Paging.RecordPerPage = 10;
            return _uow.ExecDataProc(parameter);
        }

        public ResultWithModel Get(PagePermissionModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Remove(PagePermissionModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel Update(PagePermissionModel model)
        {
            throw new NotImplementedException();
        }

        public ResultWithModel UpdateList(List<PagePermissionModel> models)
        {
            throw new NotImplementedException();
        }
    }
}
